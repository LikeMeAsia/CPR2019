using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
    public class MB_TextureArrays
    {
        internal class TexturePropertyData
        {
            public bool[] doMips;
            public int[] numMipMaps;
            public TextureFormat[] formats;
            public Vector2[] sizes;
        }

        internal static bool[] DetermineWhichPropertiesHaveTextures(MB_AtlasesAndRects[] resultAtlasesAndRectSlices)
        {
            bool[] hasTexForProperty = new bool[resultAtlasesAndRectSlices[0].texPropertyNames.Length];
            for (int i = 0; i < hasTexForProperty.Length; i++)
            {
                hasTexForProperty[i] = false;
            }

            int numSlices = resultAtlasesAndRectSlices.Length;
            for (int sliceIdx = 0; sliceIdx < numSlices; sliceIdx++)
            {
                MB_AtlasesAndRects slice = resultAtlasesAndRectSlices[sliceIdx];
                Debug.Assert(slice.texPropertyNames.Length == hasTexForProperty.Length);
                for (int propIdx = 0; propIdx < hasTexForProperty.Length; propIdx++)
                {
                    if (slice.atlases[propIdx] != null)
                    {
                        hasTexForProperty[propIdx] = true;
                    }
                }
            }

            return hasTexForProperty;
        }

        /// <summary>
        /// Creates one texture array per texture property.
        /// </summary>
        /// <returns></returns>
        internal static Texture2DArray[] CreateTextureArraysForResultMaterial(TexturePropertyData texPropertyData, MB_AtlasesAndRects[] resultAtlasesAndRectSlices,
            bool[] hasTexForProperty, MB3_TextureCombiner combiner, MB2_LogLevel LOG_LEVEL)
        {
            Debug.Assert(texPropertyData.sizes.Length == hasTexForProperty.Length);

            // ASSUMPTION all slices in the same format and the same size, alpha channel and mipMapCount
            string[] texPropertyNames = resultAtlasesAndRectSlices[0].texPropertyNames;
            Debug.Assert(texPropertyNames.Length == hasTexForProperty.Length);
            Texture2DArray[] texArrays = new Texture2DArray[texPropertyNames.Length];

            // Each texture property (_MainTex, _Bump, ...) becomes a Texture2DArray
            for (int propIdx = 0; propIdx < texPropertyNames.Length; propIdx++)
            {
                if (!hasTexForProperty[propIdx]) continue;

                int numSlices = resultAtlasesAndRectSlices.Length;
                int w = (int)texPropertyData.sizes[propIdx].x;
                int h = (int)texPropertyData.sizes[propIdx].y;
                int numMips = (int)texPropertyData.numMipMaps[propIdx];
                TextureFormat format = texPropertyData.formats[propIdx];
                bool doMipMaps = texPropertyData.doMips[propIdx];
                Texture2DArray texArray = new Texture2DArray(w, h, numSlices, format, doMipMaps);
                if (LOG_LEVEL >= MB2_LogLevel.info) Debug.LogFormat("Creating Texture2DArray for property: {0} w: {1} h: {2} format: {3} doMips: {4}", texPropertyNames[propIdx], w, h, format, doMipMaps);
                for (int sliceIdx = 0; sliceIdx < numSlices; sliceIdx++)
                {
                    Debug.Assert(resultAtlasesAndRectSlices[sliceIdx].atlases.Length == texPropertyNames.Length);
                    Debug.Assert(resultAtlasesAndRectSlices[sliceIdx].texPropertyNames[propIdx] == texPropertyNames[propIdx]);
                    Texture2D srcTex = resultAtlasesAndRectSlices[sliceIdx].atlases[propIdx];

                    if (LOG_LEVEL >= MB2_LogLevel.debug) Debug.LogFormat("Slice: {0}  texture: {1}", sliceIdx, srcTex);
                    bool isCopy = false;
                    if (srcTex == null)
                    {
                        // Slices might not have all textures create a dummy if needed.
                        srcTex = combiner._createTemporaryTexture(texPropertyNames[propIdx], w, h, format, doMipMaps);
                    }

                    Debug.Assert(srcTex.width == texArray.width, "Source texture is not the same width as the texture array " + srcTex);
                    Debug.Assert(srcTex.height == texArray.height, "Source texture is not the same height as the texture array " + srcTex);
                    Debug.Assert(srcTex.mipmapCount == numMips, "Source texture does have not the same number of mips as the texture array: " + srcTex + " numMipsTex: " + srcTex.mipmapCount + " numMipsTexArray: " + numMips + " texDims: " + srcTex.width + "x" + srcTex.height);
                    Debug.Assert(srcTex.format == format, "Formats should have been converted before this. Texture: " + srcTex + "Source: " + srcTex.format + " Targ: " + format);

                    for (int mipIdx = 0; mipIdx < numMips; mipIdx++)
                    {
                        Graphics.CopyTexture(srcTex, 0, mipIdx, texArray, sliceIdx, mipIdx);
                    }

                    if (isCopy) MB_Utility.Destroy(srcTex);
                }

                texArray.Apply();
                texArrays[propIdx] = texArray;
            }

            return texArrays;
        }

        internal static bool ConvertTexturesToReadableFormat(TexturePropertyData texturePropertyData,
                        MB_AtlasesAndRects[] resultAtlasesAndRectSlices,
                        bool[] hasTexForProperty, List<ShaderTextureProperty> textureShaderProperties,
                        MB3_TextureCombiner combiner,
                        MB2_LogLevel logLevel,
                        List<Texture2D> createdTemporaryTextureAssets,
                        MB2_EditorMethodsInterface textureEditorMethods)
        {
            for (int propIdx = 0; propIdx < hasTexForProperty.Length; propIdx++)
            {
                if (!hasTexForProperty[propIdx]) continue;

                TextureFormat format = texturePropertyData.formats[propIdx];

                if (!textureEditorMethods.TextureImporterFormatExistsForTextureFormat(format))
                {
                    Debug.LogError("Could not find target importer format matching " + format);
                    return false;
                }

                int numSlices = resultAtlasesAndRectSlices.Length;
                int targetWidth = (int)texturePropertyData.sizes[propIdx].x;
                int targetHeight = (int)texturePropertyData.sizes[propIdx].y;
                for (int sliceIdx = 0; sliceIdx < numSlices; sliceIdx++)
                {
                    Texture2D sliceTex = resultAtlasesAndRectSlices[sliceIdx].atlases[propIdx];

                    Debug.Assert(sliceTex != null, "sliceIdx " + sliceIdx + " " + propIdx);
                    if (sliceTex != null)
                    {
                        if (!MBVersion.IsTextureReadable(sliceTex))
                        {
                            textureEditorMethods.SetReadWriteFlag(sliceTex, true, true);
                        }

                        bool isAsset = textureEditorMethods.IsAnAsset(sliceTex);
                        if (logLevel >= MB2_LogLevel.trace) Debug.Log("Considering format of texture: " + sliceTex + " format:" + sliceTex.format);
                        if ((sliceTex.width != targetWidth || sliceTex.height != targetHeight) ||
                            (!isAsset && sliceTex.format != format))
                        {
                            // Do this the horrible hard way. It is only possible to resize textures in TrueColor formats,
                            // And only possible to switch formats using the Texture importer.
                            // Create a resized temporary texture asset in ARGB32 format. Then set its texture format and reimport
                            resultAtlasesAndRectSlices[sliceIdx].atlases[propIdx] = textureEditorMethods.CreateTemporaryAssetCopy(sliceTex, targetWidth, targetHeight, format, logLevel);
                            createdTemporaryTextureAssets.Add(resultAtlasesAndRectSlices[sliceIdx].atlases[propIdx]);
                        }
                        else if (sliceTex.format != format)
                        {
                            textureEditorMethods.AddTextureFormat(sliceTex, format, textureShaderProperties[propIdx].isNormalMap);
                        }
                    }
                    else
                    {

                    }

                    if (resultAtlasesAndRectSlices[sliceIdx].atlases[propIdx].format != format)
                    {
                        Debug.LogError("Could not convert texture to format " + format +
                            ". This can happen if the target build platform in build settings does not support textures in this format." +
                            " It may be necessary to switch the build platform in order to build texture arrays in this format.");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Third coord is num mipmaps.
        /// </summary>
        internal static void FindBestSizeAndMipCountAndFormatForTextureArrays(List<ShaderTextureProperty> texPropertyNames, int maxAtlasSize, MB_TextureArrayFormatSet targetFormatSet, MB_AtlasesAndRects[] resultAtlasesAndRectSlices,
                TexturePropertyData texturePropertyData)
        {
            texturePropertyData.sizes = new Vector2[texPropertyNames.Count];
            texturePropertyData.doMips = new bool[texPropertyNames.Count];
            texturePropertyData.numMipMaps = new int[texPropertyNames.Count];
            texturePropertyData.formats = new TextureFormat[texPropertyNames.Count];
            for (int propIdx = 0; propIdx < texPropertyNames.Count; propIdx++)
            {
                int numSlices = resultAtlasesAndRectSlices.Length;
                texturePropertyData.sizes[propIdx] = new Vector3(16, 16, 1);
                bool hasMips = false;
                int mipCount = 1;
                for (int sliceIdx = 0; sliceIdx < numSlices; sliceIdx++)
                {
                    Debug.Assert(resultAtlasesAndRectSlices[sliceIdx].atlases.Length == texPropertyNames.Count);
                    Debug.Assert(resultAtlasesAndRectSlices[sliceIdx].texPropertyNames[propIdx] == texPropertyNames[propIdx].name);
                    Texture2D sliceTex = resultAtlasesAndRectSlices[sliceIdx].atlases[propIdx];
                    if (sliceTex != null)
                    {
                        if (sliceTex.mipmapCount > 1) hasMips = true;
                        mipCount = Mathf.Max(mipCount, sliceTex.mipmapCount);
                        texturePropertyData.sizes[propIdx].x = Mathf.Min(Mathf.Max(texturePropertyData.sizes[propIdx].x, sliceTex.width), maxAtlasSize);
                        texturePropertyData.sizes[propIdx].y = Mathf.Min(Mathf.Max(texturePropertyData.sizes[propIdx].y, sliceTex.height), maxAtlasSize);
                        //texturePropertyData.sizes[propIdx].z = Mathf.Max(texturePropertyData.sizes[propIdx].z, sliceTex.mipmapCount);
                        texturePropertyData.formats[propIdx] = targetFormatSet.GetFormatForProperty(texPropertyNames[propIdx].name);
                    }
                }

                int numberMipsForMaxAtlasSize = Mathf.CeilToInt(Mathf.Log(maxAtlasSize, 2)) + 1;
                texturePropertyData.numMipMaps[propIdx] = Mathf.Min(numberMipsForMaxAtlasSize, mipCount);
                texturePropertyData.doMips[propIdx] = hasMips;
            }
        }

        private static IEnumerator _CreateAtlasesCoroutineSingleResultMaterial(int resMatIdx, MB_TextureArrayResultMaterial bakedMatsAndSlicesResMat, MB_MultiMaterialTexArray resMatConfig, MB3_TextureBaker tb, MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo, MB3_TextureBaker.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = .01f)
        {
            MB2_LogLevel LOG_LEVEL = tb.LOG_LEVEL;
            MB_TextureArrayFormatSet[] textureArrayOutputFormats = tb.textureArrayOutputFormats;
            MB_MultiMaterialTexArray[] resultMaterialsTexArray = tb.resultMaterialsTexArray;
            List<ShaderTextureProperty> customShaderProperties = tb.customShaderProperties;
            

            if (LOG_LEVEL >= MB2_LogLevel.debug) Debug.Log("Baking atlases for result material " + resMatIdx + " num slices:" + resMatConfig.slices.Count);
            // Each result material can be one set of slices per textureProperty. Each slice can be an atlas.
            // Create atlases for each slice.
            List<MB3_TextureCombiner.TemporaryTexture> generatedTemporaryAtlases = new List<MB3_TextureCombiner.TemporaryTexture>();
            {
                combiner.saveAtlasesAsAssets = false; // Don't want generated atlas slices to be assets
                List<MB_TexArraySlice> slicesConfig = resMatConfig.slices;
                for (int sliceIdx = 0; sliceIdx < slicesConfig.Count; sliceIdx++)
                {
                    Material resMatToPass = null;
                    List<MB_TexArraySliceRendererMatPair> srcMatAndObjPairs = slicesConfig[sliceIdx].sourceMaterials;

                    if (LOG_LEVEL >= MB2_LogLevel.trace) Debug.Log(" Baking atlases for result material:" + resMatIdx + " slice:" + sliceIdx);
                    resMatToPass = resMatConfig.combinedMaterial;
                    combiner.fixOutOfBoundsUVs = slicesConfig[sliceIdx].considerMeshUVs;
                    MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult coroutineResult2 = new MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult();
                    MB_AtlasesAndRects sliceAtlasesAndRectOutput = bakedMatsAndSlicesResMat.slices[sliceIdx];
                    List<Material> usedMats = new List<Material>();
                    slicesConfig[sliceIdx].GetAllUsedMaterials(usedMats);

                    yield return combiner.CombineTexturesIntoAtlasesCoroutine(progressInfo, sliceAtlasesAndRectOutput, resMatToPass, slicesConfig[sliceIdx].GetAllUsedRenderers(tb.objsToMesh), usedMats, editorMethods, coroutineResult2, maxTimePerFrame,
                                                onlyPackRects: false, splitAtlasWhenPackingIfTooBig: false);
                    coroutineResult.success = coroutineResult2.success;
                    if (!coroutineResult.success)
                    {
                        coroutineResult.isFinished = true;
                        yield break;
                    }

                    // Track which slices are new generated texture instances. Atlases could be original texture assets (one tex per atlas) or temporary texture instances in memory that will need to be destroyed.
                    {
                        for (int texPropIdx = 0; texPropIdx < sliceAtlasesAndRectOutput.atlases.Length; texPropIdx++)
                        {
                            Texture2D atlas = sliceAtlasesAndRectOutput.atlases[texPropIdx];
                            if (atlas != null)
                            {
                                bool atlasWasASourceTexture = false;
                                for (int srcMatIdx = 0; srcMatIdx < srcMatAndObjPairs.Count; srcMatIdx++)
                                {
                                    Material srcMat = srcMatAndObjPairs[srcMatIdx].sourceMaterial;
                                    if (srcMat.HasProperty(sliceAtlasesAndRectOutput.texPropertyNames[texPropIdx]) &&
                                        srcMat.GetTexture(sliceAtlasesAndRectOutput.texPropertyNames[texPropIdx]) == atlas)
                                    {
                                        atlasWasASourceTexture = true;
                                        break;
                                    }
                                }

                                if (!atlasWasASourceTexture)
                                {
                                    generatedTemporaryAtlases.Add(new MB3_TextureCombiner.TemporaryTexture(sliceAtlasesAndRectOutput.texPropertyNames[texPropIdx], atlas));
                                }
                            }
                        }
                    } // end visit slices

                    Debug.Assert(combiner._getNumTemporaryTextures() == 0, "Combiner should have no temporary textures.");
                }

                combiner.saveAtlasesAsAssets = saveAtlasesAsAssets; // Restore original setting.
            }

            // Generated atlas textures are temporary for texture arrays. They exist only in memory. Need to be cleaned up after we create slices.
            for (int i = 0; i < generatedTemporaryAtlases.Count; i++)
            {
                combiner.AddTemporaryTexture(generatedTemporaryAtlases[i]);
            }

            List<ShaderTextureProperty> texPropertyNames = new List<ShaderTextureProperty>();
            MB3_TextureCombinerPipeline._CollectPropertyNames(texPropertyNames, customShaderProperties, resMatConfig.combinedMaterial, LOG_LEVEL);

            // The slices are built from different source-material-lists. Each slice can have different sets of texture properties missing (nulls).
            // Build a master list of texture properties.
            bool[] hasTexForProperty = MB_TextureArrays.DetermineWhichPropertiesHaveTextures(bakedMatsAndSlicesResMat.slices);

            List<Texture2D> temporaryTextureAssets = new List<Texture2D>();
            try
            {
                MB_MultiMaterialTexArray resMaterial = resMatConfig;
                Dictionary<string, MB_TexArrayForProperty> resTexArraysByProperty = new Dictionary<string, MB_TexArrayForProperty>();
                {
                    // Initialize so I don't need to check if properties exist later.
                    for (int propIdx = 0; propIdx < texPropertyNames.Count; propIdx++)
                    {
                        if (hasTexForProperty[propIdx]) resTexArraysByProperty[texPropertyNames[propIdx].name] =
                                    new MB_TexArrayForProperty(texPropertyNames[propIdx].name, new MB_TextureArrayReference[textureArrayOutputFormats.Length]);
                    }
                }


                MB3_TextureCombinerNonTextureProperties textureBlender = null;
                textureBlender = new MB3_TextureCombinerNonTextureProperties(LOG_LEVEL, tb.considerNonTextureProperties);
                textureBlender.LoadTextureBlendersIfNeeded(resMatConfig.combinedMaterial);
                textureBlender.AdjustNonTextureProperties(resMatConfig.combinedMaterial, texPropertyNames, editorMethods);

                // Vist each TextureFormatSet
                for (int texFormatSetIdx = 0; texFormatSetIdx < textureArrayOutputFormats.Length; texFormatSetIdx++)
                {
                    MB_TextureArrayFormatSet textureArrayFormatSet = textureArrayOutputFormats[texFormatSetIdx];
                    editorMethods.Clear();

                    MB_TextureArrays.TexturePropertyData texPropertyData = new MB_TextureArrays.TexturePropertyData();
                    MB_TextureArrays.FindBestSizeAndMipCountAndFormatForTextureArrays(texPropertyNames, tb.maxAtlasSize, textureArrayFormatSet, bakedMatsAndSlicesResMat.slices, texPropertyData);

                    // Create textures we might need if they don't exist.
                    {
                        for (int propIdx = 0; propIdx < hasTexForProperty.Length; propIdx++)
                        {
                            if (hasTexForProperty[propIdx])
                            {
                                TextureFormat format = texPropertyData.formats[propIdx];
                                int numSlices = bakedMatsAndSlicesResMat.slices.Length;
                                int targetWidth = (int)texPropertyData.sizes[propIdx].x;
                                int targetHeight = (int)texPropertyData.sizes[propIdx].y;
                                for (int sliceIdx = 0; sliceIdx < numSlices; sliceIdx++)
                                {
                                    if (bakedMatsAndSlicesResMat.slices[sliceIdx].atlases[propIdx] == null)
                                    {
                                        Texture2D sliceTex = new Texture2D(targetWidth, targetHeight, format, texPropertyData.doMips[propIdx]);
                                        Color col = textureBlender.GetColorForTemporaryTexture(resMatConfig.slices[sliceIdx].sourceMaterials[0].sourceMaterial, texPropertyNames[propIdx]);
                                        MB_Utility.setSolidColor(sliceTex, col);
                                        bakedMatsAndSlicesResMat.slices[sliceIdx].atlases[propIdx] = editorMethods.CreateTemporaryAssetCopy(sliceTex, targetWidth, targetHeight, format, LOG_LEVEL);
                                        temporaryTextureAssets.Add(bakedMatsAndSlicesResMat.slices[sliceIdx].atlases[propIdx]);
                                        MB_Utility.Destroy(sliceTex);
                                    }
                                }
                            }
                        }
                    }


                    if (LOG_LEVEL >= MB2_LogLevel.debug) Debug.Log("Converting source textures to readable formats.");
                    if (MB_TextureArrays.ConvertTexturesToReadableFormat(texPropertyData, bakedMatsAndSlicesResMat.slices, hasTexForProperty, texPropertyNames, combiner, LOG_LEVEL, temporaryTextureAssets, editorMethods))
                    {

                        // We now have a set of slices (one per textureProperty). Build these into Texture2DArray's.
                        if (LOG_LEVEL >= MB2_LogLevel.debug) Debug.Log("Creating texture arrays");
                        if (LOG_LEVEL >= MB2_LogLevel.info) Debug.Log("THERE MAY BE ERRORS IN THE CONSOLE ABOUT 'Rebuilding mipmaps ... not supported'. THESE ARE PROBABLY FALSE POSITIVES AND CAN BE IGNORED.");
                        Texture2DArray[] textureArrays = MB_TextureArrays.CreateTextureArraysForResultMaterial(texPropertyData, bakedMatsAndSlicesResMat.slices, hasTexForProperty, combiner, LOG_LEVEL);


                        // Now have texture arrays for a result material, for all props. Save it.
                        for (int propIdx = 0; propIdx < textureArrays.Length; propIdx++)
                        {
                            if (hasTexForProperty[propIdx])
                            {
                                MB_TextureArrayReference texRef = new MB_TextureArrayReference(textureArrayFormatSet.name, textureArrays[propIdx]);
                                resTexArraysByProperty[texPropertyNames[propIdx].name].formats[texFormatSetIdx] = texRef;
                                if (saveAtlasesAsAssets)
                                {
                                    editorMethods.SaveTextureArrayToAssetDatabase(textureArrays[propIdx],
                                        textureArrayFormatSet.GetFormatForProperty(texPropertyNames[propIdx].name),
                                        bakedMatsAndSlicesResMat.slices[0].texPropertyNames[propIdx],
                                        propIdx, resMaterial.combinedMaterial);
                                }
                            }
                        }
                    }
                } // end vist format set

                resMaterial.textureProperties = new List<MB_TexArrayForProperty>();
                foreach (MB_TexArrayForProperty val in resTexArraysByProperty.Values)
                {
                    resMaterial.textureProperties.Add(val);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message + "\n" + e.StackTrace.ToString());
                coroutineResult.isFinished = true;
                coroutineResult.success = false;
            }
            finally
            {
                editorMethods.RestoreReadFlagsAndFormats(progressInfo);
                combiner._destroyAllTemporaryTextures();
                for (int i = 0; i < temporaryTextureAssets.Count; i++)
                {
                    editorMethods.DestroyAsset(temporaryTextureAssets[i]);
                }
                temporaryTextureAssets.Clear();
            }
        }
        internal static IEnumerator _CreateAtlasesCoroutineTextureArray(MB3_TextureBaker tb, MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo, MB3_TextureBaker.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = .01f)
        {
            MB_TextureArrayResultMaterial[] bakedMatsAndSlices = null;

            // Validate the formats
            if (tb.textureArrayOutputFormats == null || tb.textureArrayOutputFormats.Length == 0)
            {
                Debug.LogError("No Texture Array Output Formats. There must be at least one entry.");
                coroutineResult.isFinished = true;
                yield break;
            }

            for (int i = 0; i < tb.textureArrayOutputFormats.Length; i++)
            {
                if (!tb.textureArrayOutputFormats[i].ValidateTextureImporterFormatsExistsForTextureFormats(editorMethods, i))
                {
                    Debug.LogError("Could not map the selected texture format to a Texture Importer Format. Safest options are ARGB32, or RGB24.");
                    coroutineResult.isFinished = true;
                    yield break;
                }
            }

            for (int resMatIdx = 0; resMatIdx < tb.resultMaterialsTexArray.Length; resMatIdx++)
            {
                MB_MultiMaterialTexArray textureArraySliceConfig = tb.resultMaterialsTexArray[resMatIdx];
                if (textureArraySliceConfig.combinedMaterial == null)
                {
                    Debug.LogError("Material is null for Texture Array Slice Configuration: " + resMatIdx + ".");
                    coroutineResult.isFinished = true;
                    yield break;
                }


                List<MB_TexArraySlice> slices = textureArraySliceConfig.slices;
                for (int sliceIdx = 0; sliceIdx < slices.Count; sliceIdx++)
                {
                    for (int srcMatIdx = 0; srcMatIdx < slices[sliceIdx].sourceMaterials.Count; srcMatIdx++)
                    {
                        MB_TexArraySliceRendererMatPair sourceMat = slices[sliceIdx].sourceMaterials[srcMatIdx];
                        if (sourceMat.sourceMaterial == null)
                        {
                            Debug.LogError("Source material is null for Texture Array Slice Configuration: " + resMatIdx + " slice: " + sliceIdx);
                            coroutineResult.isFinished = true;
                            yield break;
                        }

                        if (slices[sliceIdx].considerMeshUVs)
                        {
                            if (sourceMat.renderer == null)
                            {
                                Debug.LogError("Renderer is null for Texture Array Slice Configuration: " + resMatIdx + " slice: " + sliceIdx + ". If considerUVs is enabled then a renderer must be supplied for each source material. The same source material can be used multiple times.");
                                coroutineResult.isFinished = true;
                                yield break;
                            }
                        } else
                        {
                            // TODO check for duplicate source mats.
                        }
                    }
                }
            }

            for (int resMatIdx = 0; resMatIdx < tb.resultMaterialsTexArray.Length; resMatIdx++)
            {
                MB_MultiMaterialTexArray textureArraySliceConfig = tb.resultMaterialsTexArray[resMatIdx];
            }

            // initialize structure to store results. For texture arrays the structure is two layers deep.
            // First layer is resultMaterial / submesh (each result material can use a different shader)
            // Second layer is a set of TextureArrays for the TextureProperties on that result material.
                int numResultMats = tb.resultMaterialsTexArray.Length;
            bakedMatsAndSlices = new MB_TextureArrayResultMaterial[numResultMats];
            for (int resMatIdx = 0; resMatIdx < bakedMatsAndSlices.Length; resMatIdx++)
            {
                bakedMatsAndSlices[resMatIdx] = new MB_TextureArrayResultMaterial();
                int numSlices = tb.resultMaterialsTexArray[resMatIdx].slices.Count;
                MB_AtlasesAndRects[] slices = bakedMatsAndSlices[resMatIdx].slices = new MB_AtlasesAndRects[numSlices];
                for (int j = 0; j < numSlices; j++) slices[j] = new MB_AtlasesAndRects();
            }

            // Some of the slices will be atlases (more than one atlas per slice).
            // Do the material combining for these. First loop over the result materials (1 per submeshes).
            for (int resMatIdx = 0; resMatIdx < bakedMatsAndSlices.Length; resMatIdx++)
            {
                yield return _CreateAtlasesCoroutineSingleResultMaterial(resMatIdx, bakedMatsAndSlices[resMatIdx], tb.resultMaterialsTexArray[resMatIdx],
                    tb, combiner, progressInfo, coroutineResult, saveAtlasesAsAssets, editorMethods, maxTimePerFrame);
                if (!coroutineResult.success) yield break;
            }

            if (coroutineResult.success)
            {
                // Save the results into the TextureBakeResults.
                tb.unpackMat2RectMap(bakedMatsAndSlices);
                tb.textureBakeResults.resultType = MB2_TextureBakeResults.ResultType.textureArray;
                tb.textureBakeResults.resultMaterials = new MB_MultiMaterial[0];
                tb.textureBakeResults.resultMaterialsTexArray = tb.resultMaterialsTexArray;
                if (tb.LOG_LEVEL >= MB2_LogLevel.info) Debug.Log("Created Texture2DArrays");
            }
            else
            {
                if (tb.LOG_LEVEL >= MB2_LogLevel.info) Debug.Log("Failed to create Texture2DArrays");
            }
        }
    }
}
