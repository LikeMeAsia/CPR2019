//Maya ASCII 2019 scene
//Name: light.ma
//Last modified: Sat, Jul 20, 2019 03:55:16 PM
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
createNode transform -n "light1" -p "All_obj_blocking";
	rename -uid "6F88D712-43A4-B2AF-DABC-4B9636AAB722";
	setAttr ".rp" -type "double3" -811.64120467522878 260.81339635793137 248.56878038023615 ;
	setAttr ".sp" -type "double3" -811.64120467522878 260.81339635793137 248.56878038023615 ;
createNode transform -n "glass" -p "light1";
	rename -uid "88EE5268-41D2-561B-FBC9-07939986C1DC";
	setAttr ".rp" -type "double3" -811.64120467522878 261.18213028047421 248.56878038023615 ;
	setAttr ".sp" -type "double3" -811.64120467522878 261.18213028047421 248.56878038023615 ;
createNode mesh -n "glassShape" -p "|All_obj_blocking|light1|glass";
	rename -uid "76BFFBAB-4F16-7F6F-CC6B-5F93342EED90";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49821442365646362 0.53609054163098335 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 73 ".uvst[0].uvsp[0:72]" -type "float2" 0.85014766 0.83139729
		 0.77666354 0.76973695 0.83978295 0.66041124 0.92992455 0.69321996 0.72792268 0.9339565
		 0.67995918 0.85088152 0.57799131 0.98852712 0.56133378 0.89405787 0.41843766 0.98852712
		 0.43509519 0.89405787 0.26850647 0.93395662 0.31646967 0.85088164 0.14628124 0.83139765
		 0.21976537 0.76973706 0.066504508 0.69322032 0.15664604 0.66041136 0.038798213 0.53609049
		 0.13472494 0.53609049 0.066504359 0.37896103 0.15664598 0.41176999 0.14628109 0.24078354
		 0.21976522 0.30244404 0.26850623 0.13822451 0.31646952 0.22129938 0.4184376 0.083653957
		 0.43509507 0.17812324 0.57799107 0.083653957 0.56133354 0.17812324 0.7279225 0.13822442
		 0.67995894 0.22129932 0.85014766 0.24078348 0.77666354 0.30244392 0.92992431 0.37896091
		 0.83978271 0.41176969 0.95763063 0.53609043 0.86170393 0.53609043 0.69797623 0.7037105
		 0.74325854 0.62527931 0.62859976 0.76192433 0.54349685 0.79289949 0.45293215 0.79289949
		 0.36782923 0.76192439 0.29845262 0.7037105 0.25317025 0.62527943 0.23744386 0.53609049
		 0.25317013 0.44690174 0.29845253 0.36847037 0.36782905 0.31025654 0.452932 0.27928165
		 0.54349661 0.27928165 0.62859964 0.31025654 0.69797623 0.36847037 0.74325854 0.44690174
		 0.75898498 0.53609043 0.6045056 0.62527931 0.62859964 0.58354676 0.56759089 0.65625417
		 0.52230877 0.67273563 0.4741202 0.67273569 0.4288379 0.65625435 0.39192337 0.62527931
		 0.36782914 0.58354688 0.35946131 0.53609043 0.36782914 0.48863414 0.39192331 0.44690174
		 0.42883781 0.41592681 0.47412014 0.39944535 0.52230865 0.39944535 0.56759089 0.41592681
		 0.60450548 0.44690174 0.62859964 0.48863414 0.63696742 0.53609043 0.49821439 0.53609043;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 73 ".pt[0:72]" -type "float3"  -797.37048 257.14444 260.49939 
		-800.00757 257.14444 270.99097 -804.04785 257.14444 278.77814 -809.00403 257.14444 
		282.9216 -814.27832 257.14444 282.92163 -819.23456 257.14444 278.77814 -823.27484 
		257.14444 270.991 -825.91193 257.14444 260.49939 -826.82788 257.14444 248.56879 -825.91193 
		257.14444 236.63817 -823.27484 257.14444 226.14656 -819.23456 257.14444 218.35941 
		-814.27832 257.14444 214.21594 -809.00403 257.14444 214.21594 -804.04791 257.14444 
		218.35939 -800.00757 257.14444 226.14656 -797.37048 257.14444 236.63817 -796.45453 
		257.14444 248.56879 -799.09174 249.55603 259.06039 -801.41077 249.55603 268.28653 
		-804.96375 249.55603 275.13446 -809.32214 249.55603 278.77814 -813.96027 249.55603 
		278.77814 -818.3186 249.55603 275.13446 -821.87164 249.55603 268.28656 -824.19067 
		249.55603 259.06039 -824.99609 249.55603 248.56879 -824.19067 249.55603 238.07718 
		-821.87164 249.55603 228.85101 -818.3186 249.55603 222.0031 -813.96027 249.55603 
		218.35939 -809.32214 249.55603 218.35939 -804.96375 249.55603 222.0031 -801.41077 
		249.55603 228.85101 -799.09174 249.55603 238.07718 -798.28625 249.55603 248.56879 
		-802.32666 243.36992 256.35593 -804.04791 243.36992 263.20383 -806.68506 243.36992 
		268.28656 -809.91998 243.36992 270.991 -813.36249 243.36992 270.991 -816.59735 243.36992 
		268.28656 -819.23456 243.36992 263.20386 -820.95581 243.36992 256.35593 -821.55359 
		243.36992 248.56879 -820.95581 243.36992 240.78163 -819.23456 243.36992 233.93372 
		-816.59735 243.36992 228.85101 -813.36249 243.36992 226.14656 -809.91998 243.36992 
		226.14656 -806.68506 243.36992 228.85101 -804.04791 243.36992 233.93372 -802.32666 
		243.36992 240.78163 -801.72882 243.36992 248.56879 -806.68506 239.33221 252.71223 
		-807.60083 239.33221 256.35593 -809.00403 239.33221 259.06039 -810.72534 239.33221 
		260.49939 -812.55707 239.33221 260.49939 -814.27832 239.33221 259.06039 -815.68152 
		239.33221 256.35593 -816.59735 239.33221 252.71225 -816.91541 239.33221 248.56879 
		-816.59735 239.33221 244.42532 -815.68152 239.33221 240.78163 -814.27832 239.33221 
		238.07718 -812.55707 239.33221 236.63817 -810.72534 239.33221 236.63817 -809.00403 
		239.33221 238.07718 -807.60083 239.33221 240.78163 -806.68506 239.33221 244.42532 
		-806.36694 239.33221 248.56879 -811.64124 237.92993 248.56879;
	setAttr -s 73 ".vt[0:72]"  9.25416756 1.73648238 -3.36823726 7.54406691 1.73648238 -6.33022022
		 4.92404127 1.73648238 -8.52868271 1.71010375 1.73648238 -9.69846153 -1.71009791 1.73648238 -9.69846344
		 -4.92403603 1.73648238 -8.52868652 -7.54406357 1.73648238 -6.33022404 -9.2541647 1.73648238 -3.36824322
		 -9.84807777 1.73648238 -2.3479647e-06 -9.2541666 1.73648238 3.36823916 -7.54406548 1.73648238 6.3302207
		 -4.92404032 1.73648238 8.52868462 -1.71010196 1.73648238 9.69846344 1.71010005 1.73648238 9.69846344
		 4.92403841 1.73648238 8.52868652 7.544065 1.73648238 6.33022261 9.25416565 1.73648238 3.36824131
		 9.84807777 1.73648238 0 8.13797855 4.99999952 -2.96197867 6.63414097 4.99999952 -5.56670237
		 4.33012962 4.99999952 -7.49999905 1.50384009 4.99999952 -8.52868557 -1.50383484 4.99999952 -8.52868652
		 -4.33012533 4.99999952 -7.50000191 -6.63413906 4.99999952 -5.56670618 -8.13797569 4.99999952 -2.96198344
		 -8.66025448 4.99999952 -2.0647658e-06 -8.1379776 4.99999952 2.9619801 -6.63414097 4.99999952 5.56670284
		 -4.33012867 4.99999952 7.50000048 -1.50383842 4.99999952 8.52868652 1.50383687 4.99999952 8.52868652
		 4.33012676 4.99999952 7.50000048 6.63413954 4.99999952 5.56670427 8.1379776 4.99999952 2.96198153
		 8.66025543 4.99999952 0 6.040229321 7.66044426 -2.19846106 4.92404032 7.66044426 -4.13175774
		 3.21393991 7.66044426 -5.56670284 1.11619103 7.66044426 -6.33022261 -1.11618721 7.66044426 -6.33022261
		 -3.21393704 7.66044426 -5.56670475 -4.92403793 7.66044426 -4.1317606 -6.040227413 7.66044426 -2.19846463
		 -6.42787552 7.66044426 -1.5325252e-06 -6.040229321 7.66044426 2.19846201 -4.92404032 7.66044426 4.13175821
		 -3.21393919 7.66044426 5.56670427 -1.11618984 7.66044426 6.33022261 1.11618853 7.66044426 6.33022261
		 3.21393776 7.66044426 5.56670427 4.92403889 7.66044426 4.13175964 6.04022789 7.66044426 2.1984632
		 6.42787647 7.66044426 0 3.21393871 9.39692593 -1.16977668 2.62002707 9.39692593 -2.19846225
		 1.7101016 9.39692593 -2.96198082 0.59391284 9.39692593 -3.36824083 -0.59391075 9.39692593 -3.36824131
		 -1.71010017 9.39692593 -2.96198225 -2.62002611 9.39692593 -2.19846368 -3.21393776 9.39692593 -1.16977859
		 -3.4202013 9.39692593 -8.1543959e-07 -3.21393871 9.39692593 1.16977704 -2.62002707 9.39692593 2.19846272
		 -1.71010125 9.39692593 2.9619813 -0.59391218 9.39692593 3.36824131 0.59391147 9.39692593 3.36824131
		 1.71010065 9.39692593 2.96198153 2.62002611 9.39692593 2.1984632 3.21393824 9.39692593 1.16977799
		 3.42020154 9.39692593 0 0 10 0;
	setAttr -s 144 ".ed[0:143]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0
		 7 8 0 8 9 0 9 10 0 10 11 0 11 12 0 12 13 0 13 14 0 14 15 0 15 16 0 16 17 0 17 0 0
		 18 19 1 19 20 1 20 21 1 21 22 1 22 23 1 23 24 1 24 25 1 25 26 1 26 27 1 27 28 1 28 29 1
		 29 30 1 30 31 1 31 32 1 32 33 1 33 34 1 34 35 1 35 18 1 36 37 1 37 38 1 38 39 1 39 40 1
		 40 41 1 41 42 1 42 43 1 43 44 1 44 45 1 45 46 1 46 47 1 47 48 1 48 49 1 49 50 1 50 51 1
		 51 52 1 52 53 1 53 36 1 54 55 1 55 56 1 56 57 1 57 58 1 58 59 1 59 60 1 60 61 1 61 62 1
		 62 63 1 63 64 1 64 65 1 65 66 1 66 67 1 67 68 1 68 69 1 69 70 1 70 71 1 71 54 1 0 18 1
		 1 19 1 2 20 1 3 21 1 4 22 1 5 23 1 6 24 1 7 25 1 8 26 1 9 27 1 10 28 1 11 29 1 12 30 1
		 13 31 1 14 32 1 15 33 1 16 34 1 17 35 1 18 36 1 19 37 1 20 38 1 21 39 1 22 40 1 23 41 1
		 24 42 1 25 43 1 26 44 1 27 45 1 28 46 1 29 47 1 30 48 1 31 49 1 32 50 1 33 51 1 34 52 1
		 35 53 1 36 54 1 37 55 1 38 56 1 39 57 1 40 58 1 41 59 1 42 60 1 43 61 1 44 62 1 45 63 1
		 46 64 1 47 65 1 48 66 1 49 67 1 50 68 1 51 69 1 52 70 1 53 71 1 54 72 1 55 72 1 56 72 1
		 57 72 1 58 72 1 59 72 1 60 72 1 61 72 1 62 72 1 63 72 1 64 72 1 65 72 1 66 72 1 67 72 1
		 68 72 1 69 72 1 70 72 1 71 72 1;
	setAttr -s 72 -ch 270 ".fc[0:71]" -type "polyFaces" 
		f 4 73 -19 -73 0
		mu 0 4 0 1 2 3
		f 4 74 -20 -74 1
		mu 0 4 4 5 1 0
		f 4 75 -21 -75 2
		mu 0 4 6 7 5 4
		f 4 76 -22 -76 3
		mu 0 4 8 9 7 6
		f 4 77 -23 -77 4
		mu 0 4 10 11 9 8
		f 4 78 -24 -78 5
		mu 0 4 12 13 11 10
		f 4 79 -25 -79 6
		mu 0 4 14 15 13 12
		f 4 80 -26 -80 7
		mu 0 4 16 17 15 14
		f 4 81 -27 -81 8
		mu 0 4 18 19 17 16
		f 4 82 -28 -82 9
		mu 0 4 20 21 19 18
		f 4 83 -29 -83 10
		mu 0 4 22 23 21 20
		f 4 84 -30 -84 11
		mu 0 4 24 25 23 22
		f 4 85 -31 -85 12
		mu 0 4 26 27 25 24
		f 4 86 -32 -86 13
		mu 0 4 28 29 27 26
		f 4 87 -33 -87 14
		mu 0 4 30 31 29 28
		f 4 88 -34 -88 15
		mu 0 4 32 33 31 30
		f 4 89 -35 -89 16
		mu 0 4 34 35 33 32
		f 4 72 -36 -90 17
		mu 0 4 3 2 35 34
		f 4 91 -37 -91 18
		mu 0 4 1 36 37 2
		f 4 92 -38 -92 19
		mu 0 4 5 38 36 1
		f 4 93 -39 -93 20
		mu 0 4 7 39 38 5
		f 4 94 -40 -94 21
		mu 0 4 9 40 39 7
		f 4 95 -41 -95 22
		mu 0 4 11 41 40 9
		f 4 96 -42 -96 23
		mu 0 4 13 42 41 11
		f 4 97 -43 -97 24
		mu 0 4 15 43 42 13
		f 4 98 -44 -98 25
		mu 0 4 17 44 43 15
		f 4 99 -45 -99 26
		mu 0 4 19 45 44 17
		f 4 100 -46 -100 27
		mu 0 4 21 46 45 19
		f 4 101 -47 -101 28
		mu 0 4 23 47 46 21
		f 4 102 -48 -102 29
		mu 0 4 25 48 47 23
		f 4 103 -49 -103 30
		mu 0 4 27 49 48 25
		f 4 104 -50 -104 31
		mu 0 4 29 50 49 27
		f 4 105 -51 -105 32
		mu 0 4 31 51 50 29
		f 4 106 -52 -106 33
		mu 0 4 33 52 51 31
		f 4 107 -53 -107 34
		mu 0 4 35 53 52 33
		f 4 90 -54 -108 35
		mu 0 4 2 37 53 35
		f 4 109 -55 -109 36
		mu 0 4 36 54 55 37
		f 4 110 -56 -110 37
		mu 0 4 38 56 54 36
		f 4 111 -57 -111 38
		mu 0 4 39 57 56 38
		f 4 112 -58 -112 39
		mu 0 4 40 58 57 39
		f 4 113 -59 -113 40
		mu 0 4 41 59 58 40
		f 4 114 -60 -114 41
		mu 0 4 42 60 59 41
		f 4 115 -61 -115 42
		mu 0 4 43 61 60 42
		f 4 116 -62 -116 43
		mu 0 4 44 62 61 43
		f 4 117 -63 -117 44
		mu 0 4 45 63 62 44
		f 4 118 -64 -118 45
		mu 0 4 46 64 63 45
		f 4 119 -65 -119 46
		mu 0 4 47 65 64 46
		f 4 120 -66 -120 47
		mu 0 4 48 66 65 47
		f 4 121 -67 -121 48
		mu 0 4 49 67 66 48
		f 4 122 -68 -122 49
		mu 0 4 50 68 67 49
		f 4 123 -69 -123 50
		mu 0 4 51 69 68 50
		f 4 124 -70 -124 51
		mu 0 4 52 70 69 51
		f 4 125 -71 -125 52
		mu 0 4 53 71 70 52
		f 4 108 -72 -126 53
		mu 0 4 37 55 71 53
		f 3 127 -127 54
		mu 0 3 54 72 55
		f 3 128 -128 55
		mu 0 3 56 72 54
		f 3 129 -129 56
		mu 0 3 57 72 56
		f 3 130 -130 57
		mu 0 3 58 72 57
		f 3 131 -131 58
		mu 0 3 59 72 58
		f 3 132 -132 59
		mu 0 3 60 72 59
		f 3 133 -133 60
		mu 0 3 61 72 60
		f 3 134 -134 61
		mu 0 3 62 72 61
		f 3 135 -135 62
		mu 0 3 63 72 62
		f 3 136 -136 63
		mu 0 3 64 72 63
		f 3 137 -137 64
		mu 0 3 65 72 64
		f 3 138 -138 65
		mu 0 3 66 72 65
		f 3 139 -139 66
		mu 0 3 67 72 66
		f 3 140 -140 67
		mu 0 3 68 72 67
		f 3 141 -141 68
		mu 0 3 69 72 68
		f 3 142 -142 69
		mu 0 3 70 72 69
		f 3 143 -143 70
		mu 0 3 71 72 70
		f 3 126 -144 71
		mu 0 3 55 72 71;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "light_box" -p "light1";
	rename -uid "07E6D305-4A91-4721-70C2-7285BBB83DE4";
	setAttr ".rp" -type "double3" -811.64120467522878 259.74546958337208 248.56878038023615 ;
	setAttr ".sp" -type "double3" -811.64120467522878 259.74546958337208 248.56878038023615 ;
createNode mesh -n "light_boxShape" -p "|All_obj_blocking|light1|light_box";
	rename -uid "94193B00-449A-B416-40BE-00B776811023";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50000345706939697 0.044171290011019271 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 76 ".uvst[0].uvsp[0:75]" -type "float2" 0.012894332 0.066643476
		 0.066319376 0.066643476 0.12044433 0.066643476 0.17465976 0.066643476 0.22888297
		 0.066643476 0.28310663 0.066643476 0.33732909 0.066643476 0.39154959 0.066643476
		 0.44578072 0.066643476 0.5000031 0.066643476 0.55422533 0.066643476 0.60845608 0.066643476
		 0.66267681 0.066643476 0.71689987 0.066643476 0.77112305 0.066643476 0.82534617 0.066643476
		 0.8795625 0.066643476 0.93368757 0.066643476 0.98711216 0.066643476 0.013490885 0.051662087
		 0.066300154 0.051662087 0.1204417 0.051662087 0.17465976 0.051662087 0.22888303 0.051662087
		 0.28310639 0.051662087 0.33733037 0.051662087 0.39155242 0.051662087 0.44577992 0.051662087
		 0.50000286 0.051662087 0.55422646 0.051662087 0.60845387 0.051662087 0.6626761 0.051662087
		 0.71689916 0.051662087 0.77112329 0.051662087 0.82534671 0.051662087 0.87956494 0.051662087
		 0.93370652 0.051662087 0.98651564 0.051662087 0.0098834336 0.036680549 0.06607762
		 0.036680549 0.12042674 0.036680549 0.1746586 0.036680549 0.22888297 0.036680549 0.28310728
		 0.036680549 0.33733204 0.036680549 0.39155734 0.036680549 0.4457784 0.036680549 0.50000286
		 0.036680549 0.55422747 0.036680549 0.60844827 0.036680549 0.66267371 0.036680549
		 0.7168988 0.036680549 0.77112293 0.036680549 0.82534766 0.036680549 0.87958014 0.036680549
		 0.93392909 0.036680549 0.99012327 0.036680549 0.0093636513 0.021699145 0.066021234
		 0.021699145 0.12042248 0.021699145 0.17465842 0.021699145 0.22888318 0.021699145
		 0.28310755 0.021699145 0.33733308 0.021699145 0.39155984 0.021699145 0.44577789 0.021699145
		 0.50000304 0.021699145 0.55422825 0.021699145 0.60844642 0.021699145 0.66267312 0.021699145
		 0.71689856 0.021699145 0.77112305 0.021699145 0.82534814 0.021699145 0.87958449 0.021699145
		 0.93398547 0.021699145 0.99064326 0.021699145;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 72 ".pt[0:71]" -type "float3"  -796.19946 265.30481 248.56876 
		-797.1308 265.30481 259.87332 -799.81226 265.30481 269.81433 -803.92035 265.30481 
		277.19272 -808.95984 265.30481 281.11887 -814.32263 265.30481 281.11877 -819.36206 
		265.30481 277.19281 -823.47021 265.30481 269.81433 -826.15167 265.30481 259.87329 
		-827.08282 265.30481 248.56874 -826.15167 265.30481 237.26425 -823.47021 265.30481 
		227.32327 -819.36206 265.30481 219.9447 -814.32257 265.30481 216.01874 -808.95984 
		265.30481 216.01869 -803.92035 265.30481 219.94475 -799.81213 265.30481 227.32324 
		-797.1308 265.30481 237.26428 -796.19958 254.18616 248.56876 -797.13074 254.18616 
		259.87323 -799.81226 254.18616 269.81433 -803.92035 254.18616 277.19275 -808.95984 
		254.18616 281.11884 -814.32257 254.18616 281.11884 -819.36212 254.18616 277.19281 
		-823.47021 254.18616 269.8143 -826.15167 254.18616 259.87329 -827.08289 254.18616 
		248.56882 -826.15167 254.18616 237.26419 -823.47021 254.18616 227.32327 -819.36206 
		254.18616 219.94475 -814.32263 254.18616 216.01869 -808.95984 254.18616 216.01871 
		-803.92035 254.18616 219.94475 -799.81226 254.18616 227.32324 -797.1308 254.18616 
		237.26427 -794.10431 253.67754 248.56879 -795.16187 253.67754 261.40717 -798.20715 
		253.67754 272.69702 -802.8728 253.67754 281.07669 -808.59595 253.67754 285.5354 -814.6864 
		253.67754 285.5354 -820.40961 253.67754 281.07669 -825.0752 253.67754 272.69702 -828.12048 
		253.67754 261.40714 -829.1781 253.67754 248.56876 -828.12048 253.67754 235.73041 
		-825.0752 253.67754 224.44052 -820.40961 253.67754 216.06087 -814.6864 253.67754 
		211.60216 -808.59595 253.67754 211.60216 -802.8728 253.67754 216.06088 -798.20715 
		253.67754 224.44054 -795.16187 253.67754 235.73042 -794.10431 265.81342 248.56879 
		-795.16187 265.81342 261.40717 -798.20715 265.81342 272.69702 -802.8728 265.81342 
		281.07669 -808.59595 265.81342 285.5354 -814.6864 265.81342 285.5354 -820.40961 265.81342 
		281.07669 -825.0752 265.81342 272.69702 -828.12048 265.81342 261.40714 -829.1781 
		265.81342 248.56876 -828.12048 265.81342 235.73041 -825.0752 265.81342 224.44052 
		-820.40961 265.81342 216.06087 -814.6864 265.81342 211.60216 -808.59595 265.81342 
		211.60216 -802.8728 265.81342 216.06088 -798.20715 265.81342 224.44054 -795.16187 
		265.81342 235.73042;
	setAttr -s 72 ".vt[0:71]"  8.80525684 -4.5809083 2.2681088e-06 8.27421856 -4.5809083 -3.011576653
		 6.74520493 -4.58090687 -5.65990686 4.40262604 -4.58090687 -7.62555122 1.52901292 -4.58090687 -8.67149353
		 -1.52902722 -4.58090687 -8.67146492 -4.40262508 -4.58090687 -7.62556839 -6.74521208 -4.58090687 -5.65990543
		 -8.27424145 -4.58090687 -3.011568069 -8.80523872 -4.58090687 9.8781875e-06 -8.27422905 -4.58090687 3.01157999
		 -6.74521446 -4.58090687 5.65990162 -4.40262413 -4.58090687 7.6255846 -1.52901185 -4.58090687 8.67147827
		 1.52901399 -4.58090687 8.67148781 4.40260792 -4.58090687 7.6255722 6.74521971 -4.58090067 5.65990686
		 8.27421951 -4.58090067 3.011566401 8.80524349 4.58090687 4.3674218e-06 8.27423382 4.58090687 -3.011560678
		 6.74520588 4.58090687 -5.65991449 4.4026165 4.58090687 -7.6255517 1.52901399 4.58090687 -8.67148399
		 -1.52900672 4.58090687 -8.67148304 -4.40264034 4.58090687 -7.62556934 -6.74521351 4.58090687 -5.65990257
		 -8.27423 4.58090687 -3.011571884 -8.80525017 4.58090687 -8.7533826e-06 -8.27422714 4.58090687 3.011591911
		 -6.74521208 4.58090687 5.65990353 -4.40262604 4.58090687 7.62557316 -1.52903068 4.58090687 8.67148781
		 1.52901626 4.58090305 8.6714859 4.40262365 4.58090305 7.6255722 6.74520731 4.58090305 5.65990686
		 8.27422619 4.58090305 3.011572361 10 5 1.110223e-15 9.39692593 5 -3.42020154 7.66044378 5 -6.42787647
		 4.99999952 5 -8.66025448 1.73648095 5 -9.84807777 -1.73648298 5 -9.84807777 -5.000000953674 5 -8.66025352
		 -7.66044569 5 -6.42787457 -9.39692688 5 -3.42019939 -9.99999905 5 2.3841858e-06 -9.39692497 5 3.42020369
		 -7.66044235 5 6.42787743 -4.99999762 5 8.66025543 -1.73647881 5 9.84807777 1.73648489 5 9.84807682
		 5.000002384186 5 8.66025162 7.66044617 5 6.42787361 9.39692688 5 3.42019796 10 -5 -1.110223e-15
		 9.39692593 -5 -3.42020154 7.66044378 -5 -6.42787647 4.99999952 -5 -8.66025448 1.73648095 -5 -9.84807777
		 -1.73648298 -5 -9.84807777 -5.000000953674 -5 -8.66025352 -7.66044569 -5 -6.42787457
		 -9.39692688 -5 -3.42019939 -9.99999905 -5 2.3841858e-06 -9.39692497 -5 3.42020369
		 -7.66044235 -5 6.42787743 -4.99999762 -5 8.66025543 -1.73647881 -5 9.84807777 1.73648489 -5 9.84807682
		 5.000002384186 -5 8.66025162 7.66044617 -5 6.42787361 9.39692688 -5 3.42019796;
	setAttr -s 126 ".ed[0:125]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0
		 7 8 0 8 9 0 9 10 0 10 11 0 11 12 0 12 13 0 13 14 0 14 15 0 15 16 0 16 17 0 17 0 0
		 18 19 0 19 20 0 20 21 0 21 22 0 22 23 0 23 24 0 24 25 0 25 26 0 26 27 0 27 28 0 28 29 0
		 29 30 0 30 31 0 31 32 0 32 33 0 33 34 0 34 35 0 35 18 0 36 37 0 37 38 0 38 39 0 39 40 0
		 40 41 0 41 42 0 42 43 0 43 44 0 44 45 0 45 46 0 46 47 0 47 48 0 48 49 0 49 50 0 50 51 0
		 51 52 0 52 53 0 53 36 0 54 55 0 55 56 0 56 57 0 57 58 0 58 59 0 59 60 0 60 61 0 61 62 0
		 62 63 0 63 64 0 64 65 0 65 66 0 66 67 0 67 68 0 68 69 0 69 70 0 70 71 0 71 54 0 0 18 1
		 1 19 1 2 20 1 3 21 1 4 22 1 5 23 1 6 24 1 7 25 1 8 26 1 9 27 1 10 28 1 11 29 1 12 30 1
		 13 31 1 14 32 1 15 33 1 16 34 1 17 35 1 18 36 1 19 37 1 20 38 1 21 39 1 22 40 1 23 41 1
		 24 42 1 25 43 1 26 44 1 27 45 1 28 46 1 29 47 1 30 48 1 31 49 1 32 50 1 33 51 1 34 52 1
		 35 53 1 36 54 1 37 55 1 38 56 1 39 57 1 40 58 1 41 59 1 42 60 1 43 61 1 44 62 1 45 63 1
		 46 64 1 47 65 1 48 66 1 49 67 1 50 68 1 51 69 1 52 70 1 53 71 1;
	setAttr -s 54 -ch 216 ".fc[0:53]" -type "polyFaces" 
		f 4 -1 72 18 -74
		mu 0 4 1 0 19 20
		f 4 -2 73 19 -75
		mu 0 4 2 1 20 21
		f 4 -3 74 20 -76
		mu 0 4 3 2 21 22
		f 4 -4 75 21 -77
		mu 0 4 4 3 22 23
		f 4 -5 76 22 -78
		mu 0 4 5 4 23 24
		f 4 -6 77 23 -79
		mu 0 4 6 5 24 25
		f 4 -7 78 24 -80
		mu 0 4 7 6 25 26
		f 4 -8 79 25 -81
		mu 0 4 8 7 26 27
		f 4 -9 80 26 -82
		mu 0 4 9 8 27 28
		f 4 -10 81 27 -83
		mu 0 4 10 9 28 29
		f 4 -11 82 28 -84
		mu 0 4 11 10 29 30
		f 4 -12 83 29 -85
		mu 0 4 12 11 30 31
		f 4 -13 84 30 -86
		mu 0 4 13 12 31 32
		f 4 -14 85 31 -87
		mu 0 4 14 13 32 33
		f 4 -15 86 32 -88
		mu 0 4 15 14 33 34
		f 4 -16 87 33 -89
		mu 0 4 16 15 34 35
		f 4 -17 88 34 -90
		mu 0 4 17 16 35 36
		f 4 -18 89 35 -73
		mu 0 4 18 17 36 37
		f 4 -19 90 36 -92
		mu 0 4 20 19 38 39
		f 4 -20 91 37 -93
		mu 0 4 21 20 39 40
		f 4 -21 92 38 -94
		mu 0 4 22 21 40 41
		f 4 -22 93 39 -95
		mu 0 4 23 22 41 42
		f 4 -23 94 40 -96
		mu 0 4 24 23 42 43
		f 4 -24 95 41 -97
		mu 0 4 25 24 43 44
		f 4 -25 96 42 -98
		mu 0 4 26 25 44 45
		f 4 -26 97 43 -99
		mu 0 4 27 26 45 46
		f 4 -27 98 44 -100
		mu 0 4 28 27 46 47
		f 4 -28 99 45 -101
		mu 0 4 29 28 47 48
		f 4 -29 100 46 -102
		mu 0 4 30 29 48 49
		f 4 -30 101 47 -103
		mu 0 4 31 30 49 50
		f 4 -31 102 48 -104
		mu 0 4 32 31 50 51
		f 4 -32 103 49 -105
		mu 0 4 33 32 51 52
		f 4 -33 104 50 -106
		mu 0 4 34 33 52 53
		f 4 -34 105 51 -107
		mu 0 4 35 34 53 54
		f 4 -35 106 52 -108
		mu 0 4 36 35 54 55
		f 4 -36 107 53 -91
		mu 0 4 37 36 55 56
		f 4 -37 108 54 -110
		mu 0 4 39 38 57 58
		f 4 -38 109 55 -111
		mu 0 4 40 39 58 59
		f 4 -39 110 56 -112
		mu 0 4 41 40 59 60
		f 4 -40 111 57 -113
		mu 0 4 42 41 60 61
		f 4 -41 112 58 -114
		mu 0 4 43 42 61 62
		f 4 -42 113 59 -115
		mu 0 4 44 43 62 63
		f 4 -43 114 60 -116
		mu 0 4 45 44 63 64
		f 4 -44 115 61 -117
		mu 0 4 46 45 64 65
		f 4 -45 116 62 -118
		mu 0 4 47 46 65 66
		f 4 -46 117 63 -119
		mu 0 4 48 47 66 67
		f 4 -47 118 64 -120
		mu 0 4 49 48 67 68
		f 4 -48 119 65 -121
		mu 0 4 50 49 68 69
		f 4 -49 120 66 -122
		mu 0 4 51 50 69 70
		f 4 -50 121 67 -123
		mu 0 4 52 51 70 71
		f 4 -51 122 68 -124
		mu 0 4 53 52 71 72
		f 4 -52 123 69 -125
		mu 0 4 54 53 72 73
		f 4 -53 124 70 -126
		mu 0 4 55 54 73 74
		f 4 -54 125 71 -109
		mu 0 4 56 55 74 75;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode materialInfo -n "light_27_6_20:materialInfo2";
	rename -uid "7BF3F3BA-48B6-48FC-EC00-A8A6BE871414";
createNode shadingEngine -n "light_27_6_20:lambert2SG";
	rename -uid "32934636-4856-EC4B-E592-75A452ED252B";
	setAttr ".ihi" 0;
	setAttr -s 4 ".dsm";
	setAttr ".ro" yes;
createNode lambert -n "light_mat";
	rename -uid "02989FDA-434D-3AEB-5574-94BAA375EDEF";
createNode file -n "light_27_6_20:file1";
	rename -uid "6F225CD6-4D1C-59FA-11BC-A190A51D28F4";
	setAttr ".ftn" -type "string" "D:/workmaya/worksummer/scenes/Models/Props/fbx_export/light_basecolor.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "light_27_6_20:place2dTexture1";
	rename -uid "337E8F11-48DC-329E-4EC5-F1BA08D757BC";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "C1A146B9-43B3-59B1-E1A2-C8924338298E";
	setAttr -s 99 ".lnk";
	setAttr -s 99 ".slnk";
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".ta" 3;
	setAttr ".tq" 0.5;
	setAttr ".aoon" yes;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 99 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 93 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 103 ".u";
select -ne :defaultRenderingList1;
	setAttr -s 182 ".r";
select -ne :lightList1;
select -ne :defaultTextureList1;
	setAttr -s 101 ".tx";
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
connectAttr "light_27_6_20:lambert2SG.msg" "light_27_6_20:materialInfo2.sg";
connectAttr "light_mat.msg" "light_27_6_20:materialInfo2.m";
connectAttr "light_27_6_20:file1.msg" "light_27_6_20:materialInfo2.t" -na;
connectAttr "light_mat.oc" "light_27_6_20:lambert2SG.ss";
connectAttr "|All_obj_blocking|light1|light_box|light_boxShape.iog" "light_27_6_20:lambert2SG.dsm"
		 -na;
connectAttr "|All_obj_blocking|light1|glass|glassShape.iog" "light_27_6_20:lambert2SG.dsm"
		 -na;
connectAttr "|glassShape.iog" "light_27_6_20:lambert2SG.dsm" -na;
connectAttr "|light_boxShape.iog" "light_27_6_20:lambert2SG.dsm" -na;
connectAttr "light_27_6_20:file1.oc" "light_mat.c";
connectAttr ":defaultColorMgtGlobals.cme" "light_27_6_20:file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "light_27_6_20:file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "light_27_6_20:file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "light_27_6_20:file1.ws";
connectAttr "light_27_6_20:place2dTexture1.c" "light_27_6_20:file1.c";
connectAttr "light_27_6_20:place2dTexture1.tf" "light_27_6_20:file1.tf";
connectAttr "light_27_6_20:place2dTexture1.rf" "light_27_6_20:file1.rf";
connectAttr "light_27_6_20:place2dTexture1.mu" "light_27_6_20:file1.mu";
connectAttr "light_27_6_20:place2dTexture1.mv" "light_27_6_20:file1.mv";
connectAttr "light_27_6_20:place2dTexture1.s" "light_27_6_20:file1.s";
connectAttr "light_27_6_20:place2dTexture1.wu" "light_27_6_20:file1.wu";
connectAttr "light_27_6_20:place2dTexture1.wv" "light_27_6_20:file1.wv";
connectAttr "light_27_6_20:place2dTexture1.re" "light_27_6_20:file1.re";
connectAttr "light_27_6_20:place2dTexture1.of" "light_27_6_20:file1.of";
connectAttr "light_27_6_20:place2dTexture1.r" "light_27_6_20:file1.ro";
connectAttr "light_27_6_20:place2dTexture1.n" "light_27_6_20:file1.n";
connectAttr "light_27_6_20:place2dTexture1.vt1" "light_27_6_20:file1.vt1";
connectAttr "light_27_6_20:place2dTexture1.vt2" "light_27_6_20:file1.vt2";
connectAttr "light_27_6_20:place2dTexture1.vt3" "light_27_6_20:file1.vt3";
connectAttr "light_27_6_20:place2dTexture1.vc1" "light_27_6_20:file1.vc1";
connectAttr "light_27_6_20:place2dTexture1.o" "light_27_6_20:file1.uv";
connectAttr "light_27_6_20:place2dTexture1.ofs" "light_27_6_20:file1.fs";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "light_27_6_20:lambert2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "light_27_6_20:lambert2SG.message" ":defaultLightSet.message";
connectAttr "light_27_6_20:lambert2SG.pa" ":renderPartition.st" -na;
connectAttr "light_mat.msg" ":defaultShaderList1.s" -na;
connectAttr "light_27_6_20:place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na
		;
connectAttr "light_27_6_20:file1.msg" ":defaultTextureList1.tx" -na;
// End of light.ma
