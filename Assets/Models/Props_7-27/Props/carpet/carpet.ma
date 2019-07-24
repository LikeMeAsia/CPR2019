//Maya ASCII 2019 scene
//Name: carpet.ma
//Last modified: Sat, Jul 20, 2019 04:40:49 PM
//Codeset: 1252
requires maya "2019";
requires "mtoa" "3.2.0.2";
requires "stereoCamera" "10.0";
currentUnit -l millimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2019";
fileInfo "version" "2019";
fileInfo "cutIdentifier" "201905131615-158f5352ad";
fileInfo "osv" "Microsoft Windows 10 Technical Preview  (Build 18362)\n";
createNode transform -n "All_obj_blocking";
	rename -uid "631FD812-46CB-B87C-CB76-6BA393748CB1";
	setAttr ".t" -type "double3" 80.348003653066101 0 -24.887289852747898 ;
	setAttr ".s" -type "double3" 0.1 0.1 0.1 ;
	setAttr ".rp" -type "double3" -82.050438277506132 10.945854051653559 5.8274071261293567 ;
	setAttr ".sp" -type "double3" -828.6655509196305 97.782174568253467 57.969953114050981 ;
	setAttr ".spt" -type "double3" 746.61511264212425 -86.836320516599912 -52.142545987921601 ;
createNode transform -n "Carpet_mesh" -p "All_obj_blocking";
	rename -uid "42BE977C-4EE0-5CA5-58CC-A6B8BC0BBD46";
	setAttr ".rp" -type "double3" -811.64120467522889 -10.752377399015023 248.56878038023615 ;
	setAttr ".sp" -type "double3" -811.64120467522889 -10.752377399015018 248.56878038023615 ;
createNode mesh -n "Carpet_meshShape" -p "Carpet_mesh";
	rename -uid "80C91AE5-41E6-FEA3-29A7-C3875EFDAF01";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49999998509883881 0.50000001490116119 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 4 ".uvst[0].uvsp[0:3]" -type "float2" 0.99817979 0.78879106
		 0.0018201768 0.78879106 0.0018201768 0.21120897 0.99817979 0.21120897;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 4 ".pt[0:3]" -type "float3"  -871.87781 -10.752378 131.03227 
		-881.87775 -10.752378 356.10529 -741.40466 -10.752378 141.03227 -751.40466 -10.752378 
		366.10529;
	setAttr -s 4 ".vt[0:3]"  -5 0 4.99999952 5 0 4.99999952 -5 0 -5.000000476837
		 5 0 -5.000000476837;
	setAttr -s 4 ".ed[0:3]"  0 1 0 0 2 0 1 3 0 2 3 0;
	setAttr -ch 4 ".fc[0]" -type "polyFaces" 
		f 4 0 2 -4 -2
		mu 0 4 0 1 2 3;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_opaque" no;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode materialInfo -n "_model_scale_assets:pasted__materialInfo41";
	rename -uid "94DA7E50-4FC7-89B7-ACF8-7781A9870FA7";
createNode shadingEngine -n "_model_scale_assets:pasted__lambert18SG";
	rename -uid "D1FACA55-492E-8525-C231-66A70191EF72";
	setAttr ".ihi" 0;
	setAttr -s 2 ".dsm";
	setAttr ".ro" yes;
createNode lambert -n "carpet_mat";
	rename -uid "DBE4DCE7-48E5-6CF2-A397-82B9946E3DAF";
createNode file -n "_model_scale_assets:pasted__file42";
	rename -uid "09B54DDA-4A6E-6C54-AB30-3889880B344E";
	setAttr ".ftn" -type "string" "D:/workmaya/worksummer/scenes/Models/Props/fbx_export/carpet_basecolor.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "_model_scale_assets:pasted__place2dTexture43";
	rename -uid "0B23E434-44C1-1EA6-F27E-9EA736380EF0";
createNode bump2d -n "_model_scale_assets:pasted__bump2d1";
	rename -uid "9E43EFDE-4CB2-46A7-7678-668213D5995D";
	setAttr ".bi" 1;
	setAttr ".vc2" -type "float3" 9.9999997e-06 9.9999997e-06 0 ;
createNode file -n "_model_scale_assets:pasted__carpet_nomal";
	rename -uid "AC58F48C-436E-52CB-7F6B-4B81B72AF7F1";
	setAttr ".ail" yes;
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "_model_scale_assets:pasted__place2dTexture44";
	rename -uid "F711C831-4FDA-088A-1CC3-D7B737679B5A";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "C1A146B9-43B3-59B1-E1A2-C8924338298E";
	setAttr -s 101 ".lnk";
	setAttr -s 101 ".slnk";
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".ta" 5;
	setAttr ".tq" 0.5;
	setAttr ".aoon" yes;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 101 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 53 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 107 ".u";
select -ne :defaultRenderingList1;
	setAttr -s 182 ".r";
select -ne :lightList1;
select -ne :defaultTextureList1;
	setAttr -s 105 ".tx";
select -ne :lambert1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
	setAttr -s 179 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :initialMaterialInfo;
	setAttr -s 3 ".t";
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
	setAttr ".outf" 51;
	setAttr ".imfkey" -type "string" "exr";
select -ne :defaultResolution;
	setAttr ".w" 1024;
	setAttr ".h" 768;
	setAttr ".pa" 1;
	setAttr ".dar" 1.3329999446868896;
select -ne :defaultLightSet;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
select -ne :modelPanel1ViewSelectedSet;
	setAttr ".ihi" 0;
select -ne :modelPanel3ViewSelectedSet;
	setAttr ".ihi" 0;
select -ne :modelPanel2ViewSelectedSet;
	setAttr ".ihi" 0;
connectAttr "_model_scale_assets:pasted__lambert18SG.msg" "_model_scale_assets:pasted__materialInfo41.sg"
		;
connectAttr "carpet_mat.msg" "_model_scale_assets:pasted__materialInfo41.m";
connectAttr "_model_scale_assets:pasted__file42.msg" "_model_scale_assets:pasted__materialInfo41.t"
		 -na;
connectAttr "carpet_mat.oc" "_model_scale_assets:pasted__lambert18SG.ss";
connectAttr "Carpet_meshShape.iog" "_model_scale_assets:pasted__lambert18SG.dsm"
		 -na;
connectAttr "_model_scale_assets:pasted__file42.oc" "carpet_mat.c";
connectAttr "_model_scale_assets:pasted__bump2d1.o" "carpet_mat.n";
connectAttr ":defaultColorMgtGlobals.cme" "_model_scale_assets:pasted__file42.cme"
		;
connectAttr ":defaultColorMgtGlobals.cfe" "_model_scale_assets:pasted__file42.cmcf"
		;
connectAttr ":defaultColorMgtGlobals.cfp" "_model_scale_assets:pasted__file42.cmcp"
		;
connectAttr ":defaultColorMgtGlobals.wsn" "_model_scale_assets:pasted__file42.ws"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.c" "_model_scale_assets:pasted__file42.c"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.tf" "_model_scale_assets:pasted__file42.tf"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.rf" "_model_scale_assets:pasted__file42.rf"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.mu" "_model_scale_assets:pasted__file42.mu"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.mv" "_model_scale_assets:pasted__file42.mv"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.s" "_model_scale_assets:pasted__file42.s"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.wu" "_model_scale_assets:pasted__file42.wu"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.wv" "_model_scale_assets:pasted__file42.wv"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.re" "_model_scale_assets:pasted__file42.re"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.of" "_model_scale_assets:pasted__file42.of"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.r" "_model_scale_assets:pasted__file42.ro"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.n" "_model_scale_assets:pasted__file42.n"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.vt1" "_model_scale_assets:pasted__file42.vt1"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.vt2" "_model_scale_assets:pasted__file42.vt2"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.vt3" "_model_scale_assets:pasted__file42.vt3"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.vc1" "_model_scale_assets:pasted__file42.vc1"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.o" "_model_scale_assets:pasted__file42.uv"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture43.ofs" "_model_scale_assets:pasted__file42.fs"
		;
connectAttr "_model_scale_assets:pasted__carpet_nomal.oa" "_model_scale_assets:pasted__bump2d1.bv"
		;
connectAttr ":defaultColorMgtGlobals.cme" "_model_scale_assets:pasted__carpet_nomal.cme"
		;
connectAttr ":defaultColorMgtGlobals.cfe" "_model_scale_assets:pasted__carpet_nomal.cmcf"
		;
connectAttr ":defaultColorMgtGlobals.cfp" "_model_scale_assets:pasted__carpet_nomal.cmcp"
		;
connectAttr ":defaultColorMgtGlobals.wsn" "_model_scale_assets:pasted__carpet_nomal.ws"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.c" "_model_scale_assets:pasted__carpet_nomal.c"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.tf" "_model_scale_assets:pasted__carpet_nomal.tf"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.rf" "_model_scale_assets:pasted__carpet_nomal.rf"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.mu" "_model_scale_assets:pasted__carpet_nomal.mu"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.mv" "_model_scale_assets:pasted__carpet_nomal.mv"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.s" "_model_scale_assets:pasted__carpet_nomal.s"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.wu" "_model_scale_assets:pasted__carpet_nomal.wu"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.wv" "_model_scale_assets:pasted__carpet_nomal.wv"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.re" "_model_scale_assets:pasted__carpet_nomal.re"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.of" "_model_scale_assets:pasted__carpet_nomal.of"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.r" "_model_scale_assets:pasted__carpet_nomal.ro"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.n" "_model_scale_assets:pasted__carpet_nomal.n"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.vt1" "_model_scale_assets:pasted__carpet_nomal.vt1"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.vt2" "_model_scale_assets:pasted__carpet_nomal.vt2"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.vt3" "_model_scale_assets:pasted__carpet_nomal.vt3"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.vc1" "_model_scale_assets:pasted__carpet_nomal.vc1"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.o" "_model_scale_assets:pasted__carpet_nomal.uv"
		;
connectAttr "_model_scale_assets:pasted__place2dTexture44.ofs" "_model_scale_assets:pasted__carpet_nomal.fs"
		;
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "_model_scale_assets:pasted__lambert18SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "_model_scale_assets:pasted__lambert18SG.message" ":defaultLightSet.message";
connectAttr "_model_scale_assets:pasted__lambert18SG.pa" ":renderPartition.st" -na
		;
connectAttr "carpet_mat.msg" ":defaultShaderList1.s" -na;
connectAttr "_model_scale_assets:pasted__place2dTexture43.msg" ":defaultRenderUtilityList1.u"
		 -na;
connectAttr "_model_scale_assets:pasted__place2dTexture44.msg" ":defaultRenderUtilityList1.u"
		 -na;
connectAttr "_model_scale_assets:pasted__bump2d1.msg" ":defaultRenderUtilityList1.u"
		 -na;
connectAttr "_model_scale_assets:pasted__file42.msg" ":defaultTextureList1.tx" -na
		;
connectAttr "_model_scale_assets:pasted__carpet_nomal.msg" ":defaultTextureList1.tx"
		 -na;
// End of carpet.ma
