//Maya ASCII 2018 scene
//Name: FloorLamp.ma
//Last modified: Mon, Jul 15, 2019 03:45:38 PM
//Codeset: 1252
requires maya "2018";
requires "stereoCamera" "10.0";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "724F34F9-47AF-799B-2411-4499AB4C3B30";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 3.68942823082795 -7.6052418797224703 48.900333730469065 ;
	setAttr ".r" -type "double3" -3244.4174853631575 9.5958106533674261 -69.943537364959795 ;
	setAttr ".rp" -type "double3" 0 0 4.4408920985006262e-16 ;
	setAttr ".rpt" -type "double3" -2.8207174808796425e-15 -1.6497023184282962e-16 4.919541337070399e-16 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "32DA73AE-431F-8D15-70A5-0F9489FB4399";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999979;
	setAttr ".coi" 54.729446081228978;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 5.9604644775390625e-08 6.8272395953402203 2.9802322387695313e-08 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "6C315F2A-4151-33D4-A066-B49BE9AF42CF";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -90 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "6607D97A-49C2-2D8B-0A53-F0A617F62B47";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "B863BA60-41CB-873B-AAF5-68AA12925532";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "4B8E79A7-48A9-F477-EE74-2BAAAF4893FC";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 6.5910102042396268;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "AA65E853-4665-4540-9467-45910A6B55F9";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "2FD30209-4BCC-7F71-D118-3599C531E980";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "FloorLamp_Mesh";
	rename -uid "95E85CFC-4211-D365-62D5-569A50B3243E";
	setAttr ".rp" -type "double3" -7.1490089736947482e-08 3.9155576369069895 -3.574504481296259e-08 ;
	setAttr ".sp" -type "double3" -7.1490089736947482e-08 3.9155576369069895 -3.574504481296259e-08 ;
createNode mesh -n "FloorLamp_MeshShape" -p "FloorLamp_Mesh";
	rename -uid "C197BF53-4F36-85E3-A20A-C5AB67EDBEE5";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.42677867412567139 0.5042632669210434 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".dr" 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode mesh -n "polySurfaceShape1" -p "FloorLamp_Mesh";
	rename -uid "5BBBEF86-424E-593F-CFA7-3792AE074DC3";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 134 ".uvst[0].uvsp[0:133]" -type "float2" 0.89736307 0.73818678
		 0.80951166 0.70179749 0.72166038 0.73818678 0.68527126 0.82603806 0.72166038 0.91388935
		 0.80951166 0.95027876 0.89736307 0.91388935 0.93375212 0.82603806 0.27957049 0.1620277
		 0.35962906 0.1620277 0.44230297 0.1620277 0.5267356 0.1620277 0.61205232 0.1620277
		 0.69736958 0.1620277 0.78180349 0.1620277 0.86447966 0.1620277 0.94454134 0.1620277
		 0.28003657 0.37059262 0.35998562 0.37059262 0.44254604 0.37059262 0.5268631 0.37059262
		 0.61206299 0.37059262 0.69726324 0.37059262 0.78158152 0.37059262 0.86414421 0.37059262
		 0.94409621 0.37059262 0.83562744 0.4822911 0.76741374 0.41408336 0.6709497 0.41408744
		 0.60274184 0.48230064 0.60274589 0.57876515 0.67095912 0.64697289 0.76742351 0.64696884
		 0.83563113 0.57875532 0.71918654 0.53052789 0.71918654 0.53052783 0.52741241 0.3719916
		 0.61226213 0.3719916 0.69708991 0.3719916 0.78106523 0.3719916 0.86336422 0.3719916
		 0.94317901 0.3719916 0.36097017 0.3719916 0.44337377 0.3719916 0.83562744 0.48229128
		 0.526999 0.16062875 0.76741409 0.41408354 0.6709497 0.41408718 0.60274184 0.48230046
		 0.60274553 0.57876474 0.67095852 0.64697289 0.7674228 0.64696872 0.80951166 0.9373576
		 0.88857788 0.90460753 0.7304455 0.90460753 0.69769514 0.82554108 0.7304455 0.7464748
		 0.80951166 0.71372449 0.88857788 0.7464748 0.92132825 0.82554108 0.44307545 0.16062875
		 0.83563113 0.57875574 0.36078462 0.16062875 0.94219601 0.16062875 0.86249006 0.16062875
		 0.78030419 0.16062875 0.69644392 0.16062875 0.61173213 0.16062875 0.28100836 0.3719916
		 0.28093278 0.16062875 0.25408694 0.057918265 0.32478124 0.057917431 0.32479739 0.099339172
		 0.25410315 0.099340126 0.39547563 0.057916552 0.39549178 0.099338353 0.46616995 0.057915539
		 0.46618617 0.099337295 0.5368644 0.057914659 0.53688067 0.09933646 0.60755861 0.057913825
		 0.60757482 0.099335507 0.678253 0.057912931 0.67826915 0.099334672 0.74894726 0.057911918
		 0.74896353 0.099333838 0.81964171 0.057911038 0.8196578 0.099332899 0.89033598 0.057910204
		 0.89035213 0.099331945 0.96103048 0.05790931 0.96104652 0.099331111 0.59681332 0.65873313
		 0.63354099 0.76952797 0.46356773 0.77053666 0.45989493 0.75945723 0.59813106 0.88075048
		 0.46002692 0.78165901 0.50410825 0.94991863 0.45062461 0.78857559 0.38738739 0.950611
		 0.43895215 0.78864497 0.29255003 0.88256443 0.42946872 0.78184026 0.25582236 0.77176976
		 0.42579561 0.77076072 0.29123223 0.66054666 0.42933673 0.75963879 0.3852554 0.59137928
		 0.43873936 0.75272179 0.50197661 0.59068656 0.45041147 0.75265265 0.074986652 0.045509983
		 0.086201489 0.04550742 0.086129919 0.96132505 0.074915379 0.96132767 0.097415946
		 0.045504797 0.097344398 0.96132219 0.10863075 0.045502234 0.10855889 0.96131945 0.11984535
		 0.045499105 0.11977346 0.96131682 0.13105954 0.045496333 0.13098828 0.96131408 0.14227432
		 0.045493651 0.14220245 0.96131122 0.15348844 0.045491178 0.15341727 0.9613086 0.16470334
		 0.045488406 0.16463147 0.96130586 0.17591742 0.045485634 0.17584623 0.96130335 0.06377276
		 0.045512903 0.063700899 0.96133053;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 74 ".vt[0:73]"  0.70710671 5.8404789 -0.70710671 0 5.8404789 -0.99999988
		 -0.70710671 5.8404789 -0.70710671 -0.99999988 5.8404789 0 -0.70710671 5.8404789 0.70710671
		 0 5.8404789 0.99999994 0.70710677 5.8404789 0.70710677 1 5.8404789 0 0.51987433 7.81400013 -0.51987433
		 1.5782508e-08 7.81400013 -0.73521334 -0.51987433 7.81400013 -0.51987433 -0.73521334 7.81400013 7.8912539e-09
		 -0.51987433 7.81400013 0.51987433 1.5782508e-08 7.81400013 0.7352134 0.51987445 7.81400013 0.51987445
		 0.73521346 7.81400013 7.8912539e-09 1.5782508e-08 7.81400013 7.8912539e-09 0.63639605 5.8404789 0.63639605
		 0.89999998 5.8404789 0 0.63639605 5.8404789 -0.63639605 0 5.8404789 -0.89999986 -0.63639605 5.8404789 -0.63639605
		 -0.89999986 5.8404789 0 -0.63639605 5.8404789 0.63639605 0 5.8404789 0.89999992 0.46788687 7.66695786 0.46788687
		 0.66169196 7.66695786 7.8912539e-09 1.5782508e-08 7.66695786 7.8912539e-09 0.46788687 7.66695786 -0.46788684
		 1.5782508e-08 7.66695786 -0.66169184 -0.46788684 7.66695786 -0.46788684 -0.66169184 7.66695786 7.8912539e-09
		 -0.46788684 7.66695786 0.46788687 1.5782508e-08 7.66695786 0.6616919 0.97033894 0.017114878 -0.70499259
		 0.37063637 0.017114878 -1.14070189 -0.37063667 0.017114878 -1.14070189 -0.970339 0.017114878 -0.70499247
		 -1.19940484 0.017114878 7.1490092e-08 -0.97033894 0.017114878 0.70499253 -0.3706364 0.017114878 1.14070189
		 0.37063652 0.017114878 1.14070165 0.97033888 0.017114878 0.70499247 1.19940472 0.017114878 0
		 0.97033894 0.25221622 -0.70499259 0.37063637 0.25221622 -1.14070189 -0.37063667 0.25221622 -1.14070189
		 -0.970339 0.25221622 -0.70499247 -1.19940484 0.25221622 7.1490092e-08 -0.97033894 0.25221622 0.70499253
		 -0.3706364 0.25221622 1.14070189 0.37063652 0.25221622 1.14070165 0.97033888 0.25221622 0.70499247
		 1.19940472 0.25221622 0 0.097033903 0.25221622 0.070499264 0.1199405 0.25221622 0
		 0.09703391 0.25221622 -0.070499286 0.037063651 0.25221622 -0.11407021 -0.037063673 0.25221622 -0.11407021
		 -0.097033933 0.25221622 -0.070499264 -0.11994053 0.25221622 7.1490107e-09 -0.09703391 0.25221622 0.070499279
		 -0.037063651 0.25221622 0.11407021 0.037063662 0.25221622 0.11407021 0.09703391 7.052215576 -0.070499286
		 0.037063651 7.052215576 -0.11407172 -0.037063673 7.052215576 -0.11407021 -0.097033933 7.052215576 -0.070499264
		 -0.11994053 7.052215576 7.1490107e-09 -0.09703391 7.052215576 0.070499279 -0.037063651 7.052215576 0.11407021
		 0.037063662 7.052215576 0.11407021 0.097033903 7.052215576 0.070499264 0.1199405 7.052215576 0;
	setAttr -s 142 ".ed[0:141]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0
		 7 0 0 8 9 0 9 10 0 10 11 0 11 12 0 12 13 0 13 14 0 14 15 0 15 8 0 0 8 0 1 9 0 2 10 0
		 3 11 0 4 12 0 5 13 0 6 14 0 7 15 0 8 16 1 9 16 1 10 16 1 11 16 1 12 16 1 13 16 1
		 14 16 1 15 16 1 17 6 1 18 7 1 19 0 1 20 1 1 21 2 1 22 3 1 23 4 1 24 5 1 17 18 0 18 19 0
		 19 20 0 20 21 0 21 22 0 22 23 0 23 24 0 24 17 0 17 25 0 18 26 0 25 26 0 27 25 1 27 26 1
		 19 28 0 26 28 0 27 28 1 20 29 0 28 29 0 27 29 1 21 30 0 29 30 0 27 30 1 22 31 0 30 31 0
		 27 31 1 23 32 0 31 32 0 27 32 1 24 33 0 32 33 0 27 33 1 33 25 0 34 35 0 35 36 0 36 37 0
		 37 38 0 38 39 0 39 40 0 40 41 0 41 42 0 42 43 0 43 34 0 44 45 0 45 46 0 46 47 0 47 48 0
		 48 49 0 49 50 0 50 51 0 51 52 0 52 53 0 53 44 0 34 44 0 35 45 0 36 46 0 37 47 0 38 48 0
		 39 49 0 40 50 0 41 51 0 42 52 0 43 53 0 44 56 1 45 57 1 46 58 1 47 59 1 48 60 1 49 61 1
		 50 62 1 51 63 1 52 54 1 53 55 1 54 55 0 55 56 0 56 57 0 57 58 0 58 59 0 59 60 0 60 61 0
		 61 62 0 62 63 0 63 54 0 56 64 0 57 65 0 64 65 0 58 66 0 65 66 0 59 67 0 66 67 0 60 68 0
		 67 68 0 61 69 0 68 69 0 62 70 0 69 70 0 63 71 0 70 71 0 54 72 0 71 72 0 55 73 0 72 73 0
		 73 64 0;
	setAttr -s 70 -ch 264 ".fc[0:69]" -type "polyFaces" 
		f 4 0 17 -9 -17
		mu 0 4 8 9 18 17
		f 4 1 18 -10 -18
		mu 0 4 9 10 19 18
		f 4 2 19 -11 -19
		mu 0 4 10 11 20 19
		f 4 3 20 -12 -20
		mu 0 4 11 12 21 20
		f 4 4 21 -13 -21
		mu 0 4 12 13 22 21
		f 4 5 22 -14 -22
		mu 0 4 13 14 23 22
		f 4 6 23 -15 -23
		mu 0 4 14 15 24 23
		f 4 7 16 -16 -24
		mu 0 4 15 16 25 24
		f 4 -1 -35 42 35
		mu 0 4 1 0 58 57
		f 4 -2 -36 43 36
		mu 0 4 2 1 57 56
		f 4 -3 -37 44 37
		mu 0 4 3 2 56 55
		f 4 -4 -38 45 38
		mu 0 4 4 3 55 54
		f 4 -5 -39 46 39
		mu 0 4 5 4 54 52
		f 4 -6 -40 47 32
		mu 0 4 6 5 52 53
		f 4 -7 -33 40 33
		mu 0 4 7 6 53 59
		f 4 -8 -34 41 34
		mu 0 4 0 7 59 58
		f 3 8 25 -25
		mu 0 3 32 31 35
		f 3 9 26 -26
		mu 0 3 31 30 35
		f 3 10 27 -27
		mu 0 3 30 29 35
		f 3 11 28 -28
		mu 0 3 29 28 35
		f 3 12 29 -29
		mu 0 3 28 27 35
		f 3 13 30 -30
		mu 0 3 27 26 35
		f 3 14 31 -31
		mu 0 3 26 33 35
		f 3 15 24 -32
		mu 0 3 33 32 35
		f 3 -51 -52 52
		mu 0 3 44 61 34
		f 3 -55 -53 55
		mu 0 3 46 44 34
		f 3 -58 -56 58
		mu 0 3 47 46 34
		f 3 -61 -59 61
		mu 0 3 48 47 34
		f 3 -64 -62 64
		mu 0 3 49 48 34
		f 3 -67 -65 67
		mu 0 3 50 49 34
		f 3 -70 -68 70
		mu 0 3 51 50 34
		f 3 -72 -71 51
		mu 0 3 61 51 34
		f 4 -41 48 50 -50
		mu 0 4 37 36 45 67
		f 4 -42 49 54 -54
		mu 0 4 38 37 67 66
		f 4 -43 53 57 -57
		mu 0 4 39 38 66 65
		f 4 -44 56 60 -60
		mu 0 4 40 39 65 64
		f 4 -45 59 63 -63
		mu 0 4 41 40 64 63
		f 4 -46 62 66 -66
		mu 0 4 42 68 69 62
		f 4 -47 65 69 -69
		mu 0 4 43 42 62 60
		f 4 -48 68 71 -49
		mu 0 4 36 43 60 45
		f 4 72 93 -83 -93
		mu 0 4 70 71 72 73
		f 4 73 94 -84 -94
		mu 0 4 71 74 75 72
		f 4 74 95 -85 -95
		mu 0 4 74 76 77 75
		f 4 75 96 -86 -96
		mu 0 4 76 78 79 77
		f 4 76 97 -87 -97
		mu 0 4 78 80 81 79
		f 4 77 98 -88 -98
		mu 0 4 80 82 83 81
		f 4 78 99 -89 -99
		mu 0 4 82 84 85 83
		f 4 79 100 -90 -100
		mu 0 4 84 86 87 85
		f 4 80 101 -91 -101
		mu 0 4 86 88 89 87
		f 4 81 92 -92 -102
		mu 0 4 88 90 91 89
		f 4 90 111 -113 -111
		mu 0 4 92 93 94 95
		f 4 91 102 -114 -112
		mu 0 4 93 96 97 94
		f 4 82 103 -115 -103
		mu 0 4 96 98 99 97
		f 4 83 104 -116 -104
		mu 0 4 98 100 101 99
		f 4 84 105 -117 -105
		mu 0 4 100 102 103 101
		f 4 85 106 -118 -106
		mu 0 4 102 104 105 103
		f 4 86 107 -119 -107
		mu 0 4 104 106 107 105
		f 4 87 108 -120 -108
		mu 0 4 106 108 109 107
		f 4 88 109 -121 -109
		mu 0 4 108 110 111 109
		f 4 89 110 -122 -110
		mu 0 4 110 92 95 111
		f 4 114 123 -125 -123
		mu 0 4 112 113 114 115
		f 4 115 125 -127 -124
		mu 0 4 113 116 117 114
		f 4 116 127 -129 -126
		mu 0 4 116 118 119 117
		f 4 117 129 -131 -128
		mu 0 4 118 120 121 119
		f 4 118 131 -133 -130
		mu 0 4 120 122 123 121
		f 4 119 133 -135 -132
		mu 0 4 122 124 125 123
		f 4 120 135 -137 -134
		mu 0 4 124 126 127 125
		f 4 121 137 -139 -136
		mu 0 4 126 128 129 127
		f 4 112 139 -141 -138
		mu 0 4 128 130 131 129
		f 4 113 122 -142 -140
		mu 0 4 132 112 115 133;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "D19BEE2F-496C-B296-13ED-11AF6B4566CB";
	setAttr -s 3 ".lnk";
	setAttr -s 3 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "738CA946-452E-ECC8-C000-93A8F3510685";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "8DC250B2-4710-F77A-BBCF-898F1415A982";
createNode displayLayerManager -n "layerManager";
	rename -uid "53DB9614-4D27-6A32-75A9-61836AA9FAFA";
createNode displayLayer -n "defaultLayer";
	rename -uid "149EB0B2-421E-A084-3862-07BA39A7291D";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "B9986288-4789-4378-3514-668B58F14BB5";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "30CA10B9-478F-9745-3EA6-86AB6EBF8B97";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "3156DC8B-4245-0E16-AB62-2C92F6FFEAAC";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n"
		+ "            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n"
		+ "            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n"
		+ "            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"flat\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1119\n            -height 716\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n"
		+ "            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n"
		+ "            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n"
		+ "            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n"
		+ "                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n"
		+ "                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n"
		+ "                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n"
		+ "                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n"
		+ "                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n"
		+ "                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n"
		+ "                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n"
		+ "                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n"
		+ "                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n"
		+ "                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -controllers 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n"
		+ "                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n"
		+ "                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -highlightConnections 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n"
		+ "                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n"
		+ "            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n"
		+ "            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap true\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"flat\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1119\\n    -height 716\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"flat\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1119\\n    -height 716\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "6432B8C7-48BF-321F-A5FA-C1BE90053FCE";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode polyUnite -n "polyUnite1";
	rename -uid "096DC240-41C3-379A-9548-7AA9363590F2";
createNode renderLayerManager -n "pasted__renderLayerManager";
	rename -uid "A8D65BD3-4CE9-B436-3740-A09685ABA487";
createNode renderLayer -n "pasted__defaultRenderLayer";
	rename -uid "CC6FA0DC-477B-24BB-DB3C-58AA252EC222";
	setAttr ".g" yes;
createNode polyUnite -n "pasted__polyUnite1";
	rename -uid "7EBADB54-40B4-6F10-30C1-40902EA81792";
createNode lambert -n "FloorLamp_Mat";
	rename -uid "10FDDD1C-4DA2-E3E9-A195-40ADDFB2BA4E";
createNode shadingEngine -n "lambert2SG";
	rename -uid "A93D15E1-4775-0235-6006-B583F000B84C";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
	rename -uid "B3B26887-40DA-242C-6E0A-BEAD9B94384C";
createNode file -n "file1";
	rename -uid "5B9D2269-4750-39F3-FFFC-BA8E43715D88";
	setAttr ".ftn" -type "string" "C:/Users/lenovo/Downloads/Lamp/FloorLamp_Albedo.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture1";
	rename -uid "1DEF1D33-4CC0-B678-EE72-D4A0E4C2D18D";
createNode polyBevel3 -n "polyBevel1";
	rename -uid "E82DDE37-4C2B-7356-4B33-48B705F00F37";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 9 "e[16:39]" "e[48:49]" "e[51:53]" "e[55:56]" "e[58:59]" "e[61:62]" "e[64:65]" "e[67:68]" "e[70]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyPlanarProj -n "polyPlanarProj1";
	rename -uid "D5ED1DB0-4311-5AEF-7F2C-97BA11439BF0";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[30:111]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" 0.0052633862942457199 6.8241262435913086 0.019920907914638519 ;
	setAttr ".ro" -type "double3" 178.79999995798681 -14.800000278365763 -179.99999999559026 ;
	setAttr ".ps" -type "double2" 1.8997222746951885 2.0075118908093472 ;
	setAttr ".cam" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
createNode polyMapCut -n "polyMapCut1";
	rename -uid "3FF68483-4AF8-95CC-3342-E6A00CB5FDAA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 16 "e[75]" "e[85]" "e[95]" "e[105]" "e[115]" "e[125]" "e[135]" "e[145]" "e[199]" "e[201]" "e[203]" "e[205]" "e[207]" "e[209]" "e[211]" "e[213]";
	setAttr ".uic" yes;
createNode polyMapCut -n "polyMapCut2";
	rename -uid "ADE625AE-474A-863E-A88A-559D81E577EC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 16 "e[70]" "e[80]" "e[90]" "e[100]" "e[110]" "e[120]" "e[130]" "e[140]" "e[198]" "e[200]" "e[202]" "e[204]" "e[206]" "e[208]" "e[210]" "e[212]";
	setAttr ".uic" yes;
createNode polyMapCut -n "polyMapCut3";
	rename -uid "0BBBFF0E-47E1-56E3-27E4-D0A8B4A8A34B";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 9 "e[72]" "e[82]" "e[92]" "e[102]" "e[112]" "e[122]" "e[132]" "e[142]" "e[214:221]";
	setAttr ".uic" yes;
createNode polyMapCut -n "polyMapCut4";
	rename -uid "F517E4AC-4367-F703-10BA-2EBF3DCE746C";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 9 "e[151]" "e[154]" "e[157]" "e[160]" "e[163]" "e[166]" "e[169]" "e[172]" "e[222:229]";
	setAttr ".uic" yes;
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "F88617E2-4216-E6C0-96AC-CFAF7A529D65";
	setAttr ".uopa" yes;
	setAttr -s 208 ".uvtk[64:207]" -type "float2" 1.66678596 0.16709177 1.48080444
		 0.66964388 1.65839922 0.18713418 0.53462756 0.64244914 1.12346792 -0.34457159 1.78773236
		 -0.94158316 1.5058794 -0.89137375 1.55505943 -0.92164791 1.3247236 0.07433895 1.062548876
		 0.81512696 1.42880249 0.10629967 0.32614684 0.64047384 0.806885 -0.31615543 1.61028433
		 -0.86846173 1.37593687 -0.86181307 0.8767662 0.010125446 0.47693002 0.81381994 1.032342553
		 0.03528196 0.054440748 0.56910384 0.47270286 -0.34758103 1.29091454 -0.80947518 1.24135041
		 -0.85028172 0.58532113 0.012066532 0.066995323 0.66648883 0.70126069 0.01568263 -0.12132892
		 0.47014663 0.31668115 -0.42043972 1.016705871 -0.79917687 1.18095899 -0.86353505
		 0.62111306 0.079024799 0.072879136 0.45943782 0.62949973 0.058982365 -0.098198861
		 0.40157035 0.43021536 -0.49205196 0.94828606 -0.8435998 1.2301389 -0.89380914 0.96317542
		 0.17177764 0.49113461 0.31395483 0.85909659 0.13981681 0.11028214 0.40354571 0.74679852
		 -0.52046818 1.12573409 -0.91672122 1.36008155 -0.92336977 1.41113281 0.23599109 1.076753378
		 0.31526169 1.25555634 0.21083449 0.38198817 0.47491568 1.080980539 -0.48904264 1.44510365
		 -0.97570765 1.49466789 -0.93490136 1.70257759 0.23405026 1.48668814 0.46259287 1.58663821
		 0.23043403 0.55775791 0.57387286 1.23700213 -0.41618395 1.71931231 -0.98600602 0.29600695
		 -0.42504945 0 0 0.47027177 -0.39036882 0 0 0.49688488 -0.35407388 0 0 0.36025664
		 -0.33742547 0 0 0.14042202 -0.35017633 0 0 -0.03384291 -0.38485706 0 0 -0.060455963
		 -0.42115188 0 0 0.076172188 -0.43780026 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1.2034595
		 -0.37267482 1.77970386 -0.97275263 1.19993234 -0.44968894 1.57969022 -0.987239 0.94856477
		 -0.50832254 1.25567675 -0.94628209 0.59660405 -0.51422924 0.99746597 -0.87387389
		 0.35022411 -0.46394861 0.95631433 -0.81243014 0.3537508 -0.38693464 1.1563282 -0.79794401
		 0.60511863 -0.32830107 1.48034143 -0.8389008 0.95707941 -0.32239413 1.73855221 -0.91130883
		 1.53437543 0.52659041 1.715927 0.19312991 1.23823833 0.34859553 1.64217114 0.24254453
		 0.67182124 0.29709831 1.27656412 0.2219657 0.16692396 0.40226516 0.83327281 0.14344825
		 0.01930815 0.60249138 0.57197201 0.052986689 0.3154453 0.78048658 0.64572769 0.0035719872
		 0.88186252 0.83198363 1.011335135 0.024150666 1.38675976 0.72681653 1.45462608 0.10266817
		 1.6470449 0.22193953 0.56703806 0.62521076 1.39012516 0.22485967 0.51612222 0.53993571
		 0.98899901 0.16814618 0.29069608 0.44415995 0.67864084 0.085020743 0.022811187 0.39398727
		 0.640854 0.024177045 -0.1306091 0.41880879 0.89777386 0.021256903 -0.079693303 0.50408375
		 1.29889977 0.077970631 0.14573276 0.59985954 1.60925817 0.16109583 0.41361779 0.65003222
		 0 0 0.17911884 -0.43483552 0 0 -0.01244019 -0.43210995 0 0 -0.068885013 -0.40331826
		 0 0 0.042849194 -0.36532688 0 0 0.25730997 -0.34039032 0 0 0.44886899 -0.34311569
		 0 0 0.50531381 -0.37190747 0 0 0.39357945 -0.40989897;
createNode polyMapCut -n "polyMapCut5";
	rename -uid "01FCCFD3-4246-8B97-413D-10A7F9984557";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[124]";
	setAttr ".uic" yes;
createNode polyTweakUV -n "polyTweakUV2";
	rename -uid "63E55EAE-49D5-ADD0-3CB7-31994AC989B4";
	setAttr ".uopa" yes;
	setAttr -s 35 ".uvtk";
	setAttr ".uvtk[65]" -type "float2" -0.089486532 0.11143336 ;
	setAttr ".uvtk[68]" -type "float2" 0.0037670794 -0.10760205 ;
	setAttr ".uvtk[73]" -type "float2" -0.044578962 -0.012800835 ;
	setAttr ".uvtk[76]" -type "float2" 0.00069970521 -0.12453815 ;
	setAttr ".uvtk[80]" -type "float2" 0.056757398 -0.0056209192 ;
	setAttr ".uvtk[83]" -type "float2" -0.0045317942 -0.09313523 ;
	setAttr ".uvtk[87]" -type "float2" 0.098734684 0.13219967 ;
	setAttr ".uvtk[90]" -type "float2" -0.050026588 -0.030846648 ;
	setAttr ".uvtk[94]" -type "float2" 0.00027973088 0.31760722 ;
	setAttr ".uvtk[97]" -type "float2" -0.15018028 0.022593237 ;
	setAttr ".uvtk[101]" -type "float2" -0.23688883 0.43394235 ;
	setAttr ".uvtk[104]" -type "float2" 0.26863271 -0.012587391 ;
	setAttr ".uvtk[108]" -type "float2" 0.23598963 0.39183062 ;
	setAttr ".uvtk[111]" -type "float2" 0.13729459 -0.012513094 ;
	setAttr ".uvtk[115]" -type "float2" 0.0041266149 0.28515649 ;
	setAttr ".uvtk[118]" -type "float2" 0.043727465 -0.057369225 ;
	setAttr ".uvtk[144]" -type "float2" 0.015925115 -0.087654255 ;
	setAttr ".uvtk[146]" -type "float2" 0.078782983 -0.035309516 ;
	setAttr ".uvtk[148]" -type "float2" 0.1916526 -0.0064918026 ;
	setAttr ".uvtk[150]" -type "float2" -0.22635466 0.032307364 ;
	setAttr ".uvtk[152]" -type "float2" -0.10199314 0.0030141249 ;
	setAttr ".uvtk[154]" -type "float2" -0.025011593 -0.058673434 ;
	setAttr ".uvtk[156]" -type "float2" 0.00028330716 -0.11099955 ;
	setAttr ".uvtk[158]" -type "float2" 0.00022298726 -0.12186699 ;
	setAttr ".uvtk[160]" -type "float2" -0.041546397 0.2326043 ;
	setAttr ".uvtk[162]" -type "float2" 0.15256244 0.37175566 ;
	setAttr ".uvtk[164]" -type "float2" -0.3278532 0.44073063 ;
	setAttr ".uvtk[166]" -type "float2" -0.061961107 0.3662554 ;
	setAttr ".uvtk[168]" -type "float2" 0.084337302 0.19051883 ;
	setAttr ".uvtk[170]" -type "float2" 0.081011362 0.026296534 ;
	setAttr ".uvtk[172]" -type "float2" -0.013610178 -0.026089989 ;
	setAttr ".uvtk[174]" -type "float2" -0.087591462 0.062416412 ;
	setAttr ".uvtk[208]" -type "float2" 0.43443042 0.37980944 ;
	setAttr ".uvtk[209]" -type "float2" -0.28682715 0.028478093 ;
createNode polyLayoutUV -n "polyLayoutUV1";
	rename -uid "89093910-4284-E847-446C-2B94FEEC1D22";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "f[62:69]" "f[94:101]" "f[111]";
	setAttr ".l" 1;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
	setAttr ".rbf" 1;
	setAttr ".lm" 1;
createNode polyTweakUV -n "polyTweakUV3";
	rename -uid "B38A5340-4491-5B0E-4C5F-9FBF716ABBBA";
	setAttr ".uopa" yes;
	setAttr -s 25 ".uvtk";
	setAttr ".uvtk[121]" -type "float2" 1.8156195 -0.41979375 ;
	setAttr ".uvtk[123]" -type "float2" 1.8659486 -0.55520582 ;
	setAttr ".uvtk[125]" -type "float2" 1.9244311 -0.44860056 ;
	setAttr ".uvtk[127]" -type "float2" 1.9568094 -0.16242585 ;
	setAttr ".uvtk[129]" -type "float2" 1.9441156 0.13568082 ;
	setAttr ".uvtk[131]" -type "float2" 1.8937863 0.27109301 ;
	setAttr ".uvtk[133]" -type "float2" 1.8353038 0.16448775 ;
	setAttr ".uvtk[135]" -type "float2" 1.8029257 -0.12168686 ;
	setAttr ".uvtk[136]" -type "float2" 1.8416009 -0.1733146 ;
	setAttr ".uvtk[137]" -type "float2" 1.853493 -0.30563703 ;
	setAttr ".uvtk[138]" -type "float2" 1.8808347 -0.34213606 ;
	setAttr ".uvtk[139]" -type "float2" 1.852125 -0.022681624 ;
	setAttr ".uvtk[140]" -type "float2" 1.8789002 0.058023043 ;
	setAttr ".uvtk[141]" -type "float2" 1.9062419 0.021524049 ;
	setAttr ".uvtk[142]" -type "float2" 1.9181342 -0.11079828 ;
	setAttr ".uvtk[143]" -type "float2" 1.9076101 -0.26143125 ;
	setAttr ".uvtk[192]" -type "float2" 1.8037274 -0.28747138 ;
	setAttr ".uvtk[194]" -type "float2" 1.8134499 0.028946079 ;
	setAttr ".uvtk[196]" -type "float2" 1.8620788 0.24519248 ;
	setAttr ".uvtk[198]" -type "float2" 1.921128 0.23459384 ;
	setAttr ".uvtk[200]" -type "float2" 1.9560074 0.0033587515 ;
	setAttr ".uvtk[202]" -type "float2" 1.9462851 -0.313059 ;
	setAttr ".uvtk[204]" -type "float2" 1.8976563 -0.52930534 ;
	setAttr ".uvtk[206]" -type "float2" 1.8386068 -0.51870668 ;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "0F9E9143-46E9-FF7A-DFA6-4894F913F608";
	setAttr ".dc" -type "componentList" 3 "f[62:69]" "f[94:101]" "f[111]";
createNode polyTweakUV -n "polyTweakUV4";
	rename -uid "EBDED05B-4701-8709-3A5E-A7935670823A";
	setAttr ".uopa" yes;
	setAttr -s 57 ".uvtk";
	setAttr ".uvtk[67]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[69]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[70]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[71]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[75]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[77]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[78]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[82]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[84]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[85]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[89]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[91]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[92]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[96]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[98]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[99]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[103]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[105]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[106]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[110]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[112]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[113]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[117]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[119]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[120]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[121]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[122]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[123]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[124]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[125]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[126]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[127]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[129]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[131]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[133]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[135]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[137]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[139]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[141]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[143]" -type "float2" -0.76650923 0.31803539 ;
	setAttr ".uvtk[161]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[163]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[165]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[167]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[169]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[171]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[173]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[175]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[176]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[177]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[178]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[179]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[180]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[181]" -type "float2" 1.0401514 -0.010686751 ;
	setAttr ".uvtk[182]" -type "float2" 1.0401514 -0.010686722 ;
	setAttr ".uvtk[183]" -type "float2" 1.0401514 -0.010686722 ;
createNode polyMapCut -n "polyMapCut6";
	rename -uid "0FF07429-43C6-61B4-1FEA-1191FEA875EA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[173]";
	setAttr ".uic" yes;
createNode polyLayoutUV -n "polyLayoutUV2";
	rename -uid "7FCA547E-45C4-3941-89C0-4AAFE1D05FDC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "f[54:61]" "f[86:93]";
	setAttr ".l" 1;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
	setAttr ".rbf" 1;
	setAttr ".lm" 1;
createNode polyTweakUV -n "polyTweakUV5";
	rename -uid "07E18B96-41AE-04AD-EB43-2F867E8B48F3";
	setAttr ".uopa" yes;
	setAttr -s 125 ".uvtk";
	setAttr ".uvtk[64]" -type "float2" -0.8431648 0.68997616 ;
	setAttr ".uvtk[65]" -type "float2" -0.70620674 -0.4174929 ;
	setAttr ".uvtk[66]" -type "float2" -0.84061182 0.6890704 ;
	setAttr ".uvtk[67]" -type "float2" -0.43994549 -0.29907221 ;
	setAttr ".uvtk[68]" -type "float2" -0.65181178 -0.37318882 ;
	setAttr ".uvtk[69]" -type "float2" -0.3559323 0.10010734 ;
	setAttr ".uvtk[70]" -type "float2" -0.36958688 0.11398762 ;
	setAttr ".uvtk[71]" -type "float2" -0.37217957 0.1045897 ;
	setAttr ".uvtk[72]" -type "float2" -0.84555507 0.69741464 ;
	setAttr ".uvtk[73]" -type "float2" -0.68489373 -0.43339476 ;
	setAttr ".uvtk[74]" -type "float2" -0.84439027 0.69496918 ;
	setAttr ".uvtk[75]" -type "float2" -0.34100744 0.089180514 ;
	setAttr ".uvtk[76]" -type "float2" -0.65686041 -0.38208899 ;
	setAttr ".uvtk[77]" -type "float2" -0.35492909 0.12230666 ;
	setAttr ".uvtk[78]" -type "float2" -0.37439901 0.12246624 ;
	setAttr ".uvtk[79]" -type "float2" -0.84198546 0.7043646 ;
	setAttr ".uvtk[80]" -type "float2" -0.66335535 -0.43936017 ;
	setAttr ".uvtk[81]" -type "float2" -0.84289116 0.70181173 ;
	setAttr ".uvtk[82]" -type "float2" 0.025498167 0.34791157 ;
	setAttr ".uvtk[83]" -type "float2" -0.66197425 -0.38372633 ;
	setAttr ".uvtk[84]" -type "float2" -0.36991662 0.13871334 ;
	setAttr ".uvtk[85]" -type "float2" -0.38379669 0.12505892 ;
	setAttr ".uvtk[86]" -type "float2" -0.83454698 0.70675498 ;
	setAttr ".uvtk[87]" -type "float2" -0.64181495 -0.43532732 ;
	setAttr ".uvtk[88]" -type "float2" -0.8369925 0.70559019 ;
	setAttr ".uvtk[89]" -type "float2" 0.48874739 0.32556105 ;
	setAttr ".uvtk[90]" -type "float2" -0.66710031 -0.37808415 ;
	setAttr ".uvtk[91]" -type "float2" -0.39211583 0.13971691 ;
	setAttr ".uvtk[92]" -type "float2" -0.39227557 0.12024686 ;
	setAttr ".uvtk[93]" -type "float2" -0.8275969 0.70318544 ;
	setAttr ".uvtk[94]" -type "float2" -0.6204958 -0.42133799 ;
	setAttr ".uvtk[95]" -type "float2" -0.83014989 0.70409107 ;
	setAttr ".uvtk[96]" -type "float2" 0.82057327 0.035220116 ;
	setAttr ".uvtk[97]" -type "float2" -0.67218566 -0.36522064 ;
	setAttr ".uvtk[98]" -type "float2" -0.40852243 0.12472913 ;
	setAttr ".uvtk[99]" -type "float2" -0.39486808 0.1108489 ;
	setAttr ".uvtk[100]" -type "float2" -0.82520664 0.69574702 ;
	setAttr ".uvtk[101]" -type "float2" -0.59961843 -0.39753714 ;
	setAttr ".uvtk[102]" -type "float2" -0.82637143 0.69819242 ;
	setAttr ".uvtk[103]" -type "float2" 0.27257177 -0.35303104 ;
	setAttr ".uvtk[104]" -type "float2" -0.63757384 -0.30420372 ;
	setAttr ".uvtk[105]" -type "float2" -0.40952599 0.10252997 ;
	setAttr ".uvtk[106]" -type "float2" -0.39005607 0.10237029 ;
	setAttr ".uvtk[107]" -type "float2" -0.82877624 0.68879694 ;
	setAttr ".uvtk[108]" -type "float2" -0.74727893 -0.35663977 ;
	setAttr ".uvtk[109]" -type "float2" -0.82787055 0.6913498 ;
	setAttr ".uvtk[110]" -type "float2" 0.055598747 -0.61176264 ;
	setAttr ".uvtk[111]" -type "float2" -0.64211845 -0.33404347 ;
	setAttr ".uvtk[112]" -type "float2" -0.39453834 0.086123079 ;
	setAttr ".uvtk[113]" -type "float2" -0.38065815 0.09977755 ;
	setAttr ".uvtk[114]" -type "float2" -0.83621472 0.68640649 ;
	setAttr ".uvtk[115]" -type "float2" -0.72707397 -0.39181915 ;
	setAttr ".uvtk[116]" -type "float2" -0.8337692 0.68757129 ;
	setAttr ".uvtk[117]" -type "float2" -0.25747249 -0.58941209 ;
	setAttr ".uvtk[118]" -type "float2" -0.64688098 -0.3571181 ;
	setAttr ".uvtk[119]" -type "float2" -0.37233913 0.085119724 ;
	setAttr ".uvtk[120]" -type "float2" -0.010811616 -0.46678835 ;
	setAttr ".uvtk[121]" -type "float2" -0.067186028 -0.52081239 ;
	setAttr ".uvtk[122]" -type "float2" -0.12204219 -0.46644586 ;
	setAttr ".uvtk[123]" -type "float2" -0.099521771 -0.33553651 ;
	setAttr ".uvtk[124]" -type "float2" 0.031270873 -0.20476806 ;
	setAttr ".uvtk[125]" -type "float2" 0.23774087 -0.15074453 ;
	setAttr ".uvtk[126]" -type "float2" 0.44245961 -0.20511103 ;
	setAttr ".uvtk[127]" -type "float2" 0.56810218 -0.33602032 ;
	setAttr ".uvtk[128]" -type "float2" -0.65473765 -0.36714241 ;
	setAttr ".uvtk[129]" -type "float2" -0.36386055 0.089931816 ;
	setAttr ".uvtk[130]" -type "float2" -0.64973217 -0.34803233 ;
	setAttr ".uvtk[131]" -type "float2" -0.38514042 0.083530456 ;
	setAttr ".uvtk[132]" -type "float2" -0.64486527 -0.32201222 ;
	setAttr ".uvtk[133]" -type "float2" -0.40471387 0.094051123 ;
	setAttr ".uvtk[134]" -type "float2" -0.68001747 -0.35471424 ;
	setAttr ".uvtk[135]" -type "float2" -0.41111541 0.11533114 ;
	setAttr ".uvtk[136]" -type "float2" -0.67510402 -0.37163588 ;
	setAttr ".uvtk[137]" -type "float2" -0.40059459 0.13490479 ;
	setAttr ".uvtk[138]" -type "float2" -0.67006683 -0.38140306 ;
	setAttr ".uvtk[139]" -type "float2" -0.37931466 0.14130603 ;
	setAttr ".uvtk[140]" -type "float2" -0.66495812 -0.38391468 ;
	setAttr ".uvtk[141]" -type "float2" -0.35974097 0.1307853 ;
	setAttr ".uvtk[142]" -type "float2" -0.65983069 -0.37914464 ;
	setAttr ".uvtk[143]" -type "float2" -0.35333973 0.10950536 ;
	setAttr ".uvtk[144]" -type "float2" -0.7242229 -0.40090516 ;
	setAttr ".uvtk[145]" -type "float2" -0.84133363 0.68828773 ;
	setAttr ".uvtk[146]" -type "float2" -0.74453211 -0.36867109 ;
	setAttr ".uvtk[147]" -type "float2" -0.83372599 0.68650746 ;
	setAttr ".uvtk[148]" -type "float2" -0.59677839 -0.38809219 ;
	setAttr ".uvtk[149]" -type "float2" -0.82708782 0.69062799 ;
	setAttr ".uvtk[150]" -type "float2" -0.61757743 -0.41492286 ;
	setAttr ".uvtk[151]" -type "float2" -0.82530755 0.69823563 ;
	setAttr ".uvtk[152]" -type "float2" -0.63884854 -0.43200842 ;
	setAttr ".uvtk[153]" -type "float2" -0.82942808 0.7048738 ;
	setAttr ".uvtk[154]" -type "float2" -0.6603716 -0.43917188 ;
	setAttr ".uvtk[155]" -type "float2" -0.83703572 0.70665413 ;
	setAttr ".uvtk[156]" -type "float2" -0.68192345 -0.43633905 ;
	setAttr ".uvtk[157]" -type "float2" -0.84367388 0.70253354 ;
	setAttr ".uvtk[158]" -type "float2" -0.70328087 -0.42353931 ;
	setAttr ".uvtk[159]" -type "float2" -0.84545416 0.6949259 ;
	setAttr ".uvtk[160]" -type "float2" -0.83625782 0.68747026 ;
	setAttr ".uvtk[161]" -type "float2" -0.40769616 -0.42236829 ;
	setAttr ".uvtk[162]" -type "float2" -0.82955903 0.68951863 ;
	setAttr ".uvtk[163]" -type "float2" -0.1561957 -0.63192546 ;
	setAttr ".uvtk[164]" -type "float2" -0.82627058 0.69570374 ;
	setAttr ".uvtk[165]" -type "float2" 0.1489633 -0.54858971 ;
	setAttr ".uvtk[166]" -type "float2" -0.82831872 0.70240259 ;
	setAttr ".uvtk[167]" -type "float2" 0.88306797 -0.22117741 ;
	setAttr ".uvtk[168]" -type "float2" -0.83450383 0.70569092 ;
	setAttr ".uvtk[169]" -type "float2" 0.72811377 0.15851776 ;
	setAttr ".uvtk[170]" -type "float2" -0.84120268 0.7036429 ;
	setAttr ".uvtk[171]" -type "float2" 0.32675061 0.36807442 ;
	setAttr ".uvtk[172]" -type "float2" -0.84449112 0.69745773 ;
	setAttr ".uvtk[173]" -type "float2" -0.12850377 0.28473869 ;
	setAttr ".uvtk[174]" -type "float2" -0.84244299 0.69075894 ;
	setAttr ".uvtk[175]" -type "float2" -0.41448721 -0.042673595 ;
	setAttr ".uvtk[176]" -type "float2" 0.58126199 -0.40325457 ;
	setAttr ".uvtk[177]" -type "float2" 0.50869411 -0.26324609 ;
	setAttr ".uvtk[178]" -type "float2" 0.33511767 -0.1657261 ;
	setAttr ".uvtk[179]" -type "float2" 0.12011176 -0.16782066 ;
	setAttr ".uvtk[180]" -type "float2" -0.053573314 -0.26830181 ;
	setAttr ".uvtk[181]" -type "float2" -0.12806734 -0.40831083 ;
	setAttr ".uvtk[182]" -type "float2" -0.10384347 -0.50583076 ;
	setAttr ".uvtk[183]" -type "float2" -0.039015796 -0.50373721 ;
	setAttr ".uvtk[184]" -type "float2" -0.76399863 -0.327171 ;
	setAttr ".uvtk[185]" -type "float2" -0.67717731 -0.34526917 ;
	setAttr ".uvtk[186]" -type "float2" -0.014861871 -0.40325457 ;
	setAttr ".uvtk[187]" -type "float2" 0.86869562 -0.35303104 ;
createNode polyLayoutUV -n "polyLayoutUV3";
	rename -uid "B586F02C-4808-219B-4BD1-ABB565D27F45";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 10 "f[31]" "f[34]" "f[37]" "f[40]" "f[43]" "f[46]" "f[49]" "f[52]" "f[54:69]" "f[86:93]";
	setAttr ".fr" no;
	setAttr ".l" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".sc" 0;
	setAttr ".dl" yes;
	setAttr ".rbf" 3;
	setAttr ".lm" 1;
createNode polyTweakUV -n "polyTweakUV6";
	rename -uid "9B38ED11-4222-29E7-34D3-FF8F309CD967";
	setAttr ".uopa" yes;
	setAttr -s 69 ".uvtk";
	setAttr ".uvtk[65]" -type "float2" 0.0081320852 -0.00074023008 ;
	setAttr ".uvtk[67]" -type "float2" 0.0006814003 0.00074020028 ;
	setAttr ".uvtk[68]" -type "float2" -0.00065262616 0.00074021518 ;
	setAttr ".uvtk[73]" -type "float2" 0.0081687421 -0.00074023008 ;
	setAttr ".uvtk[75]" -type "float2" 0.00071203709 0.00074014068 ;
	setAttr ".uvtk[76]" -type "float2" -0.00071211159 0.00074021518 ;
	setAttr ".uvtk[80]" -type "float2" 0.0082164854 -0.00074023008 ;
	setAttr ".uvtk[82]" -type "float2" 0.00065261126 0.00074020028 ;
	setAttr ".uvtk[83]" -type "float2" -0.0006814748 0.00074015558 ;
	setAttr ".uvtk[87]" -type "float2" 0.0082532316 -0.00074023008 ;
	setAttr ".uvtk[89]" -type "float2" 0.00048220158 0.00074023008 ;
	setAttr ".uvtk[90]" -type "float2" -0.00058199465 0.00074021518 ;
	setAttr ".uvtk[94]" -type "float2" 0.0082579404 -0.00074023008 ;
	setAttr ".uvtk[96]" -type "float2" 0.00018179417 0.00074020028 ;
	setAttr ".uvtk[97]" -type "float2" -0.00043569505 0.00074015558 ;
	setAttr ".uvtk[101]" -type "float2" 0.0082092136 -0.00074023008 ;
	setAttr ".uvtk[103]" -type "float2" 0.00026503205 0.00074014068 ;
	setAttr ".uvtk[104]" -type "float2" 0.00026510656 0.00074018538 ;
	setAttr ".uvtk[108]" -type "float2" 0.0081756562 -0.00074023008 ;
	setAttr ".uvtk[110]" -type "float2" 0.00043570995 0.00074014068 ;
	setAttr ".uvtk[111]" -type "float2" -0.00018186867 0.00074021518 ;
	setAttr ".uvtk[115]" -type "float2" 0.0081276149 -0.00074023008 ;
	setAttr ".uvtk[117]" -type "float2" 0.00058186054 0.00074008107 ;
	setAttr ".uvtk[118]" -type "float2" -0.00048221648 0.00074015558 ;
	setAttr ".uvtk[120]" -type "float2" -0.0082091987 -0.00074015558 ;
	setAttr ".uvtk[121]" -type "float2" -0.0082578659 -0.00074021518 ;
	setAttr ".uvtk[122]" -type "float2" -0.0082531571 -0.00074015558 ;
	setAttr ".uvtk[123]" -type "float2" -0.0082164407 -0.00074018538 ;
	setAttr ".uvtk[124]" -type "float2" -0.008168757 -0.00074012578 ;
	setAttr ".uvtk[125]" -type "float2" -0.0081321001 -0.00074009597 ;
	setAttr ".uvtk[126]" -type "float2" -0.0081274509 -0.00074012578 ;
	setAttr ".uvtk[127]" -type "float2" -0.0081756711 -0.00074018538 ;
	setAttr ".uvtk[128]" -type "float2" 0.0081320852 0.00074015558 ;
	setAttr ".uvtk[130]" -type "float2" 0.0081276149 0.00074021518 ;
	setAttr ".uvtk[132]" -type "float2" 0.0081756562 0.00074018538 ;
	setAttr ".uvtk[134]" -type "float2" 0.0082091838 0.00074021518 ;
	setAttr ".uvtk[136]" -type "float2" 0.0082579404 0.00074021518 ;
	setAttr ".uvtk[138]" -type "float2" 0.0082532316 0.00074021518 ;
	setAttr ".uvtk[140]" -type "float2" 0.0082164854 0.00074021518 ;
	setAttr ".uvtk[142]" -type "float2" 0.0081687421 0.00074021518 ;
	setAttr ".uvtk[144]" -type "float2" -0.00048221648 -0.00074023008 ;
	setAttr ".uvtk[146]" -type "float2" -0.00018186867 -0.00074023008 ;
	setAttr ".uvtk[148]" -type "float2" -0.00026510656 -0.00074023008 ;
	setAttr ".uvtk[150]" -type "float2" -0.00043569505 -0.00074023008 ;
	setAttr ".uvtk[152]" -type "float2" -0.00058199465 -0.00074023008 ;
	setAttr ".uvtk[154]" -type "float2" -0.0006814748 -0.00074023008 ;
	setAttr ".uvtk[156]" -type "float2" -0.00071211159 -0.00074023008 ;
	setAttr ".uvtk[158]" -type "float2" -0.00065262616 -0.00074023008 ;
	setAttr ".uvtk[161]" -type "float2" -0.0082532167 0.00074020028 ;
	setAttr ".uvtk[163]" -type "float2" -0.0082579553 0.00074014068 ;
	setAttr ".uvtk[165]" -type "float2" -0.0082090497 0.00074014068 ;
	setAttr ".uvtk[167]" -type "float2" -0.0081756711 0.00074014068 ;
	setAttr ".uvtk[169]" -type "float2" -0.0081276298 0.00074014068 ;
	setAttr ".uvtk[171]" -type "float2" -0.0081320405 0.00074020028 ;
	setAttr ".uvtk[173]" -type "float2" -0.0081686378 0.00074014068 ;
	setAttr ".uvtk[175]" -type "float2" -0.0082162619 0.00074014068 ;
	setAttr ".uvtk[176]" -type "float2" -0.00026500225 -0.00074009597 ;
	setAttr ".uvtk[177]" -type "float2" 0.00018185377 -0.00074015558 ;
	setAttr ".uvtk[178]" -type "float2" 0.00048220158 -0.00074015558 ;
	setAttr ".uvtk[179]" -type "float2" 0.00065255165 -0.00074015558 ;
	setAttr ".uvtk[180]" -type "float2" 0.00071197748 -0.00074018538 ;
	setAttr ".uvtk[181]" -type "float2" 0.0006814003 -0.00074009597 ;
	setAttr ".uvtk[182]" -type "float2" 0.00058200955 -0.00074015558 ;
	setAttr ".uvtk[183]" -type "float2" 0.00043568015 -0.00074015558 ;
	setAttr ".uvtk[184]" -type "float2" 0.00026510656 -0.00074023008 ;
	setAttr ".uvtk[185]" -type "float2" -0.00026519597 0.00074015558 ;
	setAttr ".uvtk[186]" -type "float2" 0.00026515126 -0.00074009597 ;
	setAttr ".uvtk[187]" -type "float2" -0.00026512146 0.00074014068 ;
createNode polySoftEdge -n "polySoftEdge1";
	rename -uid "13437867-4732-D82C-24AD-ABB5AA1289F2";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak1";
	rename -uid "B400A656-43CE-2A6B-7AD7-23BE8FD4FD62";
	setAttr ".uopa" yes;
	setAttr -s 20 ".tk";
	setAttr ".tk[96]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[97]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[98]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[99]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[100]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[101]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[102]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[103]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[104]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[105]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[106]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[107]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[108]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[109]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[110]" -type "float3" 0 0.13461675 0 ;
	setAttr ".tk[111]" -type "float3" 0 0.13461675 0 ;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 3 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 5 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
select -ne :defaultRenderingList1;
	setAttr -s 2 ".r";
select -ne :defaultTextureList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polySoftEdge1.out" "FloorLamp_MeshShape.i";
connectAttr "polyTweakUV6.uvtk[0]" "FloorLamp_MeshShape.uvst[0].uvtw";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "pasted__renderLayerManager.rlmi[0]" "pasted__defaultRenderLayer.rlid"
		;
connectAttr "file1.oc" "FloorLamp_Mat.c";
connectAttr "FloorLamp_Mat.oc" "lambert2SG.ss";
connectAttr "FloorLamp_MeshShape.iog" "lambert2SG.dsm" -na;
connectAttr "lambert2SG.msg" "materialInfo1.sg";
connectAttr "FloorLamp_Mat.msg" "materialInfo1.m";
connectAttr "file1.msg" "materialInfo1.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file1.ws";
connectAttr "place2dTexture1.c" "file1.c";
connectAttr "place2dTexture1.tf" "file1.tf";
connectAttr "place2dTexture1.rf" "file1.rf";
connectAttr "place2dTexture1.mu" "file1.mu";
connectAttr "place2dTexture1.mv" "file1.mv";
connectAttr "place2dTexture1.s" "file1.s";
connectAttr "place2dTexture1.wu" "file1.wu";
connectAttr "place2dTexture1.wv" "file1.wv";
connectAttr "place2dTexture1.re" "file1.re";
connectAttr "place2dTexture1.of" "file1.of";
connectAttr "place2dTexture1.r" "file1.ro";
connectAttr "place2dTexture1.n" "file1.n";
connectAttr "place2dTexture1.vt1" "file1.vt1";
connectAttr "place2dTexture1.vt2" "file1.vt2";
connectAttr "place2dTexture1.vt3" "file1.vt3";
connectAttr "place2dTexture1.vc1" "file1.vc1";
connectAttr "place2dTexture1.o" "file1.uv";
connectAttr "place2dTexture1.ofs" "file1.fs";
connectAttr "polySurfaceShape1.o" "polyBevel1.ip";
connectAttr "FloorLamp_MeshShape.wm" "polyBevel1.mp";
connectAttr "polyBevel1.out" "polyPlanarProj1.ip";
connectAttr "FloorLamp_MeshShape.wm" "polyPlanarProj1.mp";
connectAttr "polyPlanarProj1.out" "polyMapCut1.ip";
connectAttr "polyMapCut1.out" "polyMapCut2.ip";
connectAttr "polyMapCut2.out" "polyMapCut3.ip";
connectAttr "polyMapCut3.out" "polyMapCut4.ip";
connectAttr "polyMapCut4.out" "polyTweakUV1.ip";
connectAttr "polyTweakUV1.out" "polyMapCut5.ip";
connectAttr "polyMapCut5.out" "polyTweakUV2.ip";
connectAttr "polyTweakUV2.out" "polyLayoutUV1.ip";
connectAttr "polyLayoutUV1.out" "polyTweakUV3.ip";
connectAttr "polyTweakUV3.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "polyTweakUV4.ip";
connectAttr "polyTweakUV4.out" "polyMapCut6.ip";
connectAttr "polyMapCut6.out" "polyLayoutUV2.ip";
connectAttr "polyLayoutUV2.out" "polyTweakUV5.ip";
connectAttr "polyTweakUV5.out" "polyLayoutUV3.ip";
connectAttr "polyLayoutUV3.out" "polyTweakUV6.ip";
connectAttr "polyTweak1.out" "polySoftEdge1.ip";
connectAttr "FloorLamp_MeshShape.wm" "polySoftEdge1.mp";
connectAttr "polyTweakUV6.out" "polyTweak1.ip";
connectAttr "lambert2SG.pa" ":renderPartition.st" -na;
connectAttr "FloorLamp_Mat.msg" ":defaultShaderList1.s" -na;
connectAttr "place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pasted__defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "file1.msg" ":defaultTextureList1.tx" -na;
// End of FloorLamp.ma
