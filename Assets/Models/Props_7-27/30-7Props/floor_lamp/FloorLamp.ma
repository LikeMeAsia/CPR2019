//Maya ASCII 2018 scene
//Name: FloorLamp.ma
//Last modified: Wed, Jul 24, 2019 03:31:55 PM
//Codeset: 1252
requires maya "2018";
requires "stereoCamera" "10.0";
currentUnit -l millimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "FloorLamp_Mesh";
	rename -uid "BEE0C3B6-4C74-AD37-F007-B2A07486DED3";
	addAttr -is true -ci true -k true -sn "currentUVSet" -ln "currentUVSet" -dt "string";
	setAttr ".rp" -type "double3" -7.1490089736947482e-07 39.155576369069898 -3.574504481296259e-07 ;
	setAttr ".sp" -type "double3" -7.1490089736947482e-07 39.155576369069898 -3.574504481296259e-07 ;
	setAttr -k on ".currentUVSet" -type "string" "map1";
createNode mesh -n "FloorLamp_MeshShape" -p "FloorLamp_Mesh";
	rename -uid "1BA589F8-4293-0D6A-D0A0-AAAF7FA3CED9";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.26363431662321091 0.50340808369219303 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 188 ".uvst[0].uvsp[0:187]" -type "float2" 0.25408694 0.057918265
		 0.32478124 0.057917431 0.32479739 0.099339172 0.25410315 0.099340126 0.39547563 0.057916552
		 0.39549178 0.099338353 0.46616995 0.057915539 0.46618617 0.099337295 0.5368644 0.057914659
		 0.53688067 0.09933646 0.60755861 0.057913825 0.60757482 0.099335507 0.678253 0.057912931
		 0.67826915 0.099334672 0.74894726 0.057911918 0.74896353 0.099333838 0.81964171 0.057911038
		 0.8196578 0.099332899 0.89033598 0.057910204 0.89035213 0.099331945 0.96103048 0.05790931
		 0.96104652 0.099331111 0.59681332 0.65873313 0.63354099 0.76952797 0.46356773 0.77053666
		 0.45989493 0.75945723 0.59813106 0.88075048 0.46002692 0.78165901 0.50410825 0.94991863
		 0.45062461 0.78857559 0.38738739 0.950611 0.43895215 0.78864497 0.29255003 0.88256443
		 0.42946872 0.78184026 0.25582236 0.77176976 0.42579561 0.77076072 0.29123223 0.66054666
		 0.42933673 0.75963879 0.3852554 0.59137928 0.43873936 0.75272179 0.50197661 0.59068656
		 0.45041147 0.75265265 0.074986652 0.045509983 0.086201489 0.04550742 0.086129919
		 0.96132505 0.074915379 0.96132767 0.097415946 0.045504797 0.097344398 0.96132219
		 0.10863075 0.045502234 0.10855889 0.96131945 0.11984535 0.045499105 0.11977346 0.96131682
		 0.13105954 0.045496333 0.13098828 0.96131408 0.14227432 0.045493651 0.14220245 0.96131122
		 0.15348844 0.045491178 0.15341727 0.9613086 0.16470334 0.045488406 0.16463147 0.96130586
		 0.17591742 0.045485634 0.17584623 0.96130335 0.06377276 0.045512903 0.063700899 0.96133053
		 0.92168319 0.86092913 0.7293666 0.36881462 0.89940548 0.88269985 0.54057252 0.36881462
		 0.69329691 0.16348113 0.82187837 0.46677202 0.77229077 0.53087479 0.75693935 0.49331179
		 0.9107424 0.77175385 0.65377027 0.36881462 0.91038394 0.80290079 0.61719072 0.36881462
		 0.61719072 0.16348107 0.83697569 0.55802703 0.75658458 0.56829089 0.83994961 0.71643364
		 0.57729602 0.36881462 0.86172026 0.73871136 0.69329691 0.36881462 0.54057252 0.16348113
		 0.78312427 0.63322973 0.71902204 0.5836423 0.7507742 0.72737455 0.5007143 0.36881462
		 0.78192127 0.72773302 0.76812398 0.36881462 0.46421492 0.16348113 0.6918695 0.64832753
		 0.68160558 0.5679363 0.69545412 0.79816735 0.42479771 0.36881462 0.71773171 0.77639651
		 0.84091789 0.36881462 0.38888776 0.16348113 0.61666721 0.59447598 0.66625434 0.53037333
		 0.70639491 0.88734269 0.35031146 0.36881462 0.70675349 0.85619557 0.31535065 0.36881462
		 0.91094434 0.16348113 0.60156929 0.50322115 0.6819604 0.49295729 0.77718771 0.94266272
		 0.87489229 0.36881462 0.75541705 0.92038494 0.38888776 0.36881462 0.84091789 0.16348113
		 0.6554206 0.42801833 0.71952319 0.47760558 0.86636287 0.93172204 0.80332243 0.36881462
		 0.83521593 0.93136346 0.46421489 0.36881462 0.76812398 0.16348113 0.74667561 0.41292074
		 0.35031146 0.16348113 0.42479774 0.16348113 0.5007143 0.16348113 0.57729602 0.16348113
		 0.65377027 0.16348113 0.7293666 0.16348113 0.80332243 0.16348113 0.87489229 0.16348113
		 0.7293666 0.16348113 0.78409153 0.42862684 0.80332243 0.16348113 0.69298363 0.41266698
		 0.87489229 0.16348113 0.61727548 0.46580467 0.35031146 0.16348113 0.60131526 0.55691296
		 0.42479771 0.16348113 0.65445316 0.63262147 0.5007143 0.16348113 0.74556136 0.64858103
		 0.57729602 0.16348113 0.82126975 0.59544337 0.65377027 0.16348113 0.83722943 0.50433534
		 0.76812398 0.36881462 0.91071665 0.88738811 0.84091789 0.36881462 0.83989912 0.94267666
		 0.31535065 0.36881462 0.75072891 0.93169606 0.38888776 0.36881462 0.69544011 0.86087871
		 0.46421492 0.36881462 0.70642066 0.77170831 0.54057252 0.36881462 0.77723807 0.71641976
		 0.61719072 0.36881462 0.86640865 0.72740018 0.69329691 0.36881462 0.9216972 0.79821754
		 0.86167991 0.92040849 0.5007143 0.36881462 0.78187591 0.93135154 0.42479774 0.36881462
		 0.71770811 0.88265949 0.35031146 0.36881462 0.70676529 0.80285543 0.87489229 0.36881462
		 0.75545734 0.73868752 0.80332243 0.36881462 0.8352614 0.72774488 0.7293666 0.36881462
		 0.89942896 0.7764371 0.65377027 0.36881462 0.91037202 0.85624099 0.57729602 0.36881462
		 0.91094434 0.16348113 0.84091789 0.16348113 0.76812398 0.16348113 0.69329691 0.16348113
		 0.61719072 0.16348113 0.54057252 0.16348113 0.46421486 0.16348113 0.38888776 0.16348113
		 0.91094434 0.36881462 0.31535065 0.16348113 0.31535065 0.16348113 0.91094434 0.36881462;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr -s 20 ".pt[20:39]" -type "float3"  -0.66984749 0.096704915 -0.48667789 
		-0.82797754 0.096704915 -5.2204578e-06 -0.66984761 0.096704915 0.48666763 -0.25585911 
		0.096704915 0.78744793 0.25585902 0.096704915 0.78744793 0.66984749 0.096704915 0.48666745 
		0.82797754 0.096704915 -5.2698083e-06 0.66984725 0.096704915 -0.48667803 0.25585881 
		0.096704915 -0.78745806 -0.2558592 0.096704915 -0.78745806 -0.66984761 -0.096704893 
		0.48666763 -0.25585911 -0.096704893 0.78745806 0.25585902 -0.096704893 0.78744793 
		0.66984749 -0.096704893 0.48666745 0.82797754 -0.096704893 -5.2698083e-06 0.66984725 
		-0.096704893 -0.48667803 0.25585881 -0.096704893 -0.78745806 -0.2558592 -0.096704893 
		-0.78745806 -0.66984749 -0.096704893 -0.48667789 -0.82797754 -0.096704893 -5.2204578e-06;
	setAttr -s 112 ".vt[0:111]"  9.70338917 0.17114878 -7.049925804 3.70636368 0.17114878 -11.40701866
		 -3.70636678 0.17114878 -11.40701866 -9.70339012 0.17114878 -7.04992485 -11.99404812 0.17114878 7.1490092e-07
		 -9.70338917 0.17114878 7.049925327 -3.70636415 0.17114878 11.40701866 3.70636511 0.17114878 11.40701675
		 9.70338917 0.17114878 7.04992485 11.99404716 0.17114878 0 9.70338917 2.5221622 -7.049925804
		 3.70636368 2.5221622 -11.40701866 -3.70636678 2.5221622 -11.40701866 -9.70339012 2.5221622 -7.04992485
		 -11.99404812 2.5221622 7.1490092e-07 -9.70338917 2.5221622 7.049925327 -3.70636415 2.5221622 11.40701866
		 3.70636511 2.5221622 11.40701675 9.70338917 2.5221622 7.04992485 11.99404716 2.5221622 0
		 0.97033906 2.5221622 0.70499265 1.19940495 2.5221622 0 0.97033912 2.5221622 -0.70499289
		 0.37063652 2.5221622 -1.14070201 -0.37063673 2.5221622 -1.14070201 -0.9703393 2.5221622 -0.70499265
		 -1.19940531 2.5221622 7.1490106e-08 -0.97033912 2.5221622 0.70499277 -0.37063652 2.5221622 1.14070201
		 0.37063661 2.5221622 1.14070201 0.97033912 70.52215576 -0.70499289 0.37063652 70.52215576 -1.14071715
		 -0.37063673 70.52215576 -1.14070201 -0.9703393 70.52215576 -0.70499265 -1.19940531 70.52215576 7.1490106e-08
		 -0.97033912 70.52215576 0.70499277 -0.37063652 70.52215576 1.14070201 0.37063661 70.52215576 1.14070201
		 0.97033906 70.52215576 0.70499265 1.19940495 70.52215576 0 5.90146732 58.40478897 -7.5555315
		 7.5555315 58.40478897 -5.90146732 5.68320751 78.13999939 -4.029143333 4.029143333 78.13999939 -5.68320751
		 -1.16960001 58.40478897 -9.5155344 1.16960001 58.40478897 -9.5155344 1.16960025 78.13999939 -6.86766911
		 -1.16959989 78.13999939 -6.86766911 -7.5555315 58.40478897 -5.90146732 -5.90146732 58.40478897 -7.5555315
		 -4.029143333 78.13999939 -5.68320751 -5.68320751 78.13999939 -4.029143333 -9.5155344 58.40478897 1.16960001
		 -9.5155344 58.40478897 -1.16960001 -6.86766911 78.13999939 -1.16960001 -6.86766911 78.13999939 1.16960013
		 -5.90146732 58.40478897 7.5555315 -7.5555315 58.40478897 5.90146732 -5.68320751 78.13999939 4.029143333
		 -4.029143333 78.13999939 5.68320751 1.16960001 58.40478897 9.51553535 -1.16960001 58.40478897 9.51553535
		 -1.16959977 78.13999939 6.86767006 1.16960025 78.13999939 6.86767006 7.55553198 58.40478897 5.9014678
		 5.9014678 58.40478897 7.55553198 4.029144287 78.13999939 5.68320847 5.68320847 78.13999939 4.029144287
		 9.51553535 58.40478897 -1.16960001 9.51553535 58.40478897 1.16960001 6.86767054 78.13999939 1.16960025
		 6.86767054 78.13999939 -1.16959989 2.82366419 78.13999939 -1.16960001 1.16960025 78.13999939 -2.82366419
		 -1.16959989 78.13999939 -2.82366419 -2.82366395 78.13999939 -1.16960001 -2.82366419 78.13999939 1.16960013
		 -1.16959989 78.13999939 2.82366419 1.16960025 78.13999939 2.82366419 2.82366419 78.13999939 1.16960013
		 6.84842491 58.40478897 5.19436073 5.19436073 58.40478897 6.84842491 8.51553535 58.40478897 -1.16960001
		 8.51553535 58.40478897 1.16960001 5.19436073 58.40478897 -6.84842491 6.84842491 58.40478897 -5.19436073
		 -1.16960001 58.40478897 -8.5155344 1.16960001 58.40478897 -8.5155344 -6.84842491 58.40478897 -5.19436073
		 -5.19436073 58.40478897 -6.84842491 -8.5155344 58.40478897 1.16960001 -8.5155344 58.40478897 -1.16960001
		 -5.19436073 58.40478897 6.84842491 -6.84842491 58.40478897 5.19436073 1.16960001 58.40478897 8.51553535
		 -1.16960001 58.40478897 8.51553535 5.16333294 78.01574707 3.50926876 3.50926852 78.01574707 5.16333294
		 6.13245535 78.01574707 1.16960013 6.13245535 78.01574707 -1.16960001 5.16333294 78.01574707 -3.50926852
		 3.50926852 78.01574707 -5.16333199 1.16960025 78.01574707 -6.1324544 -1.16959989 78.01574707 -6.1324544
		 -3.50926828 78.01574707 -5.16333199 -5.16333199 78.01574707 -3.50926828 -6.1324544 78.01574707 -1.16960001
		 -6.1324544 78.01574707 1.16960013 -5.16333199 78.01574707 3.50926852 -3.50926828 78.01574707 5.16333294
		 -1.16959989 78.01574707 6.13245487 1.16960025 78.01574707 6.13245487;
	setAttr -s 206 ".ed";
	setAttr ".ed[0:165]"  0 1 0 1 11 1 11 10 1 10 0 1 1 2 0 2 12 1 12 11 1 2 3 0
		 3 13 1 13 12 1 3 4 0 4 14 1 14 13 1 4 5 0 5 15 1 15 14 1 5 6 0 6 16 1 16 15 1 6 7 0
		 7 17 1 17 16 1 7 8 0 8 18 1 18 17 1 8 9 0 9 19 1 19 18 1 9 0 0 10 19 1 19 21 1 21 20 1
		 20 18 1 10 22 1 22 21 1 11 23 1 23 22 1 12 24 1 24 23 1 13 25 1 25 24 1 14 26 1 26 25 1
		 15 27 1 27 26 1 16 28 1 28 27 1 17 29 1 29 28 1 20 29 1 23 31 1 31 30 0 30 22 1 24 32 1
		 32 31 0 25 33 1 33 32 0 26 34 1 34 33 0 27 35 1 35 34 0 28 36 1 36 35 0 29 37 1 37 36 0
		 20 38 1 38 37 0 21 39 1 39 38 0 30 39 0 40 41 1 41 85 1 85 84 1 84 40 1 40 43 1 43 42 1
		 42 41 1 43 73 1 73 72 1 72 42 1 44 45 1 45 87 1 87 86 1 86 44 1 44 47 1 47 46 1 46 45 1
		 47 74 1 74 73 1 73 46 1 48 49 1 49 89 1 89 88 1 88 48 1 48 51 1 51 50 1 50 49 1 51 75 1
		 75 74 1 74 50 1 52 53 1 53 91 1 91 90 1 90 52 1 52 55 1 55 54 1 54 53 1 55 76 1 76 75 1
		 75 54 1 56 57 1 57 93 1 93 92 1 92 56 1 56 59 1 59 58 1 58 57 1 59 77 1 77 76 1 76 58 1
		 60 61 1 61 95 1 95 94 1 94 60 1 60 63 1 63 62 1 62 61 1 63 78 1 78 77 1 77 62 1 64 65 1
		 65 81 1 81 80 1 80 64 1 64 67 1 67 66 1 66 65 1 67 79 1 79 78 1 78 66 1 68 69 1 69 83 1
		 83 82 1 82 68 1 68 71 1 71 70 1 70 69 1 71 72 1 72 79 1 79 70 1 81 97 1 97 96 0 96 80 1
		 83 98 1 98 99 0 99 82 1 85 100 1 100 101 0 101 84 1 87 102 1 102 103 0 103 86 1 89 104 1
		 104 105 0 105 88 1 91 106 1;
	setAttr ".ed[166:205]" 106 107 0 107 90 1 93 108 1 108 109 0 109 92 1 95 110 1
		 110 111 0 111 94 1 40 45 1 46 43 1 44 49 1 50 47 1 48 53 1 54 51 1 52 57 1 58 55 1
		 56 61 1 62 59 1 60 65 1 66 63 1 64 69 1 70 67 1 68 41 1 42 71 1 84 87 1 86 89 1 88 91 1
		 90 93 1 92 95 1 94 81 1 80 83 1 82 85 1 96 98 0 99 100 0 101 102 0 103 104 0 105 106 0
		 107 108 0 109 110 0 111 97 0;
	setAttr -s 112 ".n[0:111]" -type "float3"  0.80901706 0 -0.58778524 0.30901694
		 0 -0.9510566 0.13708487 0.89621699 -0.42190394 0.35889304 0.89621681 -0.26075098
		 -0.30901703 0 -0.95105648 -0.13708492 0.89621693 -0.42190394 -0.809017 0 -0.58778512
		 -0.35889292 0.89621693 -0.26075092 -1 0 4.2926143e-08 -0.443616 0.89621693 3.4995928e-08
		 -0.80901694 0 0.5877853 -0.35889292 0.89621693 0.26075098 -0.30901682 0 0.95105654
		 -0.13708484 0.89621681 0.42190403 0.30901706 0 0.95105648 0.13708492 0.89621693 0.42190388
		 0.809017 0 0.58778518 0.35889304 0.89621687 0.26075098 1 0 2.8617427e-08 0.44361609
		 0.89621693 -3.2580496e-09 0.69044268 0.72338706 2.0493946e-08 0.55857992 0.72338718
		 0.40583193 0.55858237 0.72338575 -0.40583104 0.21335842 0.72338718 -0.65665001 -0.21336204
		 0.7233867 -0.65664941 -0.55857986 0.72338724 -0.40583193 -0.6904425 0.72338718 1.3662628e-07
		 -0.55857968 0.72338724 0.40583199 -0.21335842 0.72338724 0.65664995 0.21335852 0.72338724
		 0.65664995 0.30901682 -1.0582043e-07 -0.95105654 0.80901891 -4.7353204e-08 -0.58778262
		 -0.30902186 -5.8466924e-08 -0.95105493 -0.809017 0 -0.58778518 -1 0 1.7809398e-07
		 -0.80901688 0 0.58778536 -0.30901688 0 0.95105654 0.309017 0 0.95105648 0.809017
		 0 0.58778512 1 0 4.9470547e-08 0.51023585 0.083829314 -0.85593927 0.85593921 0.083829328
		 -0.51023591 -0.8355661 -0.18638536 0.51680732 -0.51680714 -0.18638535 0.8355661 0.49314663
		 0.23153535 -0.83856893 0.83856881 0.23153538 -0.49314684 0 1 -8.7309826e-07 0 1 -8.7309826e-07
		 -0.24444921 0.083829321 -0.96603167 0.24444921 0.083829321 -0.96603167 -0.22539665
		 -0.18638544 0.95627242 0.22539659 -0.18638542 0.95627236 -0.24425039 0.23153538 -0.94166511
		 0.24425039 0.23153536 -0.94166505 0 1 -8.7309826e-07 -0.85593921 0.083829314 -0.51023591
		 -0.51023579 0.083829299 -0.85593921 0.51680726 -0.18638545 0.83556616 0.83556616
		 -0.18638544 0.51680702 -0.83856881 0.23153532 -0.49314666 -0.49314666 0.23153533
		 -0.83856881 0 1 -8.7309837e-07 -0.96603161 0.083829314 0.24444926 -0.96603161 0.083829314
		 -0.24444927 0.9562723 -0.18638541 0.22539659 0.9562723 -0.18638541 -0.22539662 -0.94166511
		 0.2315354 0.24425048 -0.94166511 0.2315354 -0.24425048 0 0.99999994 -8.730982e-07
		 -0.51023579 0.083829299 0.85593933 -0.85593915 0.083829321 0.51023585 0.83556616
		 -0.18638541 -0.5168072 0.5168072 -0.18638541 -0.83556616 -0.49314657 0.23153533 0.83856893
		 -0.83856881 0.23153535 0.49314672 0 1 -9.6785379e-07 0.24444906 0.083829276 0.96603167
		 -0.24444917 0.083829321 0.96603173 0.22539665 -0.18638542 -0.9562723 -0.22539669
		 -0.18638545 -0.95627236 0.2442503 0.23153538 0.94166505 -0.24425036 0.23153538 0.94166511
		 0 1 -1.4032751e-06 0.85593921 0.083829291 0.51023597 0.51023567 0.083829254 0.85593939
		 -0.51680726 -0.18638545 -0.83556616 -0.83556616 -0.18638544 -0.51680714 0.83856893
		 0.2315354 0.49314657 0.49314663 0.23153538 0.83856887 0 1 -1.261142e-06 0.96603161
		 0.083829343 -0.24444936 0.96603161 0.083829328 0.24444929 -0.9562723 -0.18638544
		 -0.22539659 -0.95627236 -0.18638541 0.22539674 0.94166499 0.23153542 -0.24425055
		 0.94166499 0.2315354 0.24425045 -0.51763171 -0.11730245 -0.84752429 -0.84752429 -0.11730247
		 -0.51763183 -0.96531111 -0.11730248 -0.2332692 -0.96531111 -0.11730247 0.2332693
		 -0.84752423 -0.11730247 0.51763189 -0.51763183 -0.11730246 0.84752434 -0.23326923
		 -0.11730248 0.96531117 0.23326921 -0.11730249 0.96531117 0.51763183 -0.11730249 0.84752434
		 0.84752429 -0.11730249 0.51763165 0.96531111 -0.11730249 0.2332692 0.96531111 -0.11730249
		 -0.2332692 0.84752429 -0.11730249 -0.51763165 0.51763183 -0.11730249 -0.84752429
		 0.23326926 -0.11730248 -0.96531117 -0.23326927 -0.11730247 -0.96531117;
	setAttr -s 95 -ch 376 ".fc[0:94]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 0 1 2 3
		f 4 4 5 6 -2
		mu 0 4 1 4 5 2
		f 4 7 8 9 -6
		mu 0 4 4 6 7 5
		f 4 10 11 12 -9
		mu 0 4 6 8 9 7
		f 4 13 14 15 -12
		mu 0 4 8 10 11 9
		f 4 16 17 18 -15
		mu 0 4 10 12 13 11
		f 4 19 20 21 -18
		mu 0 4 12 14 15 13
		f 4 22 23 24 -21
		mu 0 4 14 16 17 15
		f 4 25 26 27 -24
		mu 0 4 16 18 19 17
		f 4 28 -4 29 -27
		mu 0 4 18 20 21 19
		f 4 -28 30 31 32
		mu 0 4 22 23 24 25
		f 4 -30 33 34 -31
		mu 0 4 23 26 27 24
		f 4 -3 35 36 -34
		mu 0 4 26 28 29 27
		f 4 -7 37 38 -36
		mu 0 4 28 30 31 29
		f 4 -10 39 40 -38
		mu 0 4 30 32 33 31
		f 4 -13 41 42 -40
		mu 0 4 32 34 35 33
		f 4 -16 43 44 -42
		mu 0 4 34 36 37 35
		f 4 -19 45 46 -44
		mu 0 4 36 38 39 37
		f 4 -22 47 48 -46
		mu 0 4 38 40 41 39
		f 4 -25 -33 49 -48
		mu 0 4 40 22 25 41
		f 4 -37 50 51 52
		mu 0 4 42 43 44 45
		f 4 -39 53 54 -51
		mu 0 4 43 46 47 44
		f 4 -41 55 56 -54
		mu 0 4 46 48 49 47
		f 4 -43 57 58 -56
		mu 0 4 48 50 51 49
		f 4 -45 59 60 -58
		mu 0 4 50 52 53 51
		f 4 -47 61 62 -60
		mu 0 4 52 54 55 53
		f 4 -49 63 64 -62
		mu 0 4 54 56 57 55
		f 4 -50 65 66 -64
		mu 0 4 56 58 59 57
		f 4 -32 67 68 -66
		mu 0 4 58 60 61 59
		f 4 -35 -53 69 -68
		mu 0 4 62 42 45 63
		f 4 70 71 72 73
		mu 0 4 64 145 66 174
		f 4 -71 74 75 76
		mu 0 4 65 158 68 128
		f 4 -76 77 78 79
		mu 0 4 69 143 70 71
		f 4 80 81 82 83
		mu 0 4 72 159 74 172
		f 4 -81 84 85 86
		mu 0 4 73 156 76 142
		f 4 -86 87 88 89
		mu 0 4 77 141 78 70
		f 4 90 91 92 93
		mu 0 4 79 157 81 170
		f 4 -91 94 95 96
		mu 0 4 80 154 83 140
		f 4 -96 97 98 99
		mu 0 4 84 139 85 78
		f 4 100 101 102 103
		mu 0 4 86 155 88 168
		f 4 -101 104 105 106
		mu 0 4 87 152 90 138
		f 4 -106 107 108 109
		mu 0 4 91 137 92 85
		f 4 110 111 112 113
		mu 0 4 93 153 95 166
		f 4 -111 114 115 116
		mu 0 4 94 150 97 136
		f 4 -116 117 118 119
		mu 0 4 98 135 99 92
		f 4 120 121 122 123
		mu 0 4 100 151 102 164
		f 4 -121 124 125 126
		mu 0 4 101 148 185 134
		f 4 -126 127 128 129
		mu 0 4 105 133 106 99
		f 4 130 131 132 133
		mu 0 4 107 149 109 162
		f 4 -131 134 135 136
		mu 0 4 108 146 111 132
		f 4 -136 137 138 139
		mu 0 4 112 131 113 106
		f 4 140 141 142 143
		mu 0 4 114 147 116 160
		f 4 -141 144 145 146
		mu 0 4 115 144 118 130
		f 4 -146 147 148 149
		mu 0 4 119 129 71 113
		f 4 -133 150 151 152
		mu 0 4 110 165 120 183
		f 4 -143 153 154 155
		mu 0 4 117 163 121 182
		f 4 -73 156 157 158
		mu 0 4 67 161 122 181
		f 4 -83 159 160 161
		mu 0 4 75 175 123 180
		f 4 -93 162 163 164
		mu 0 4 82 173 124 179
		f 4 -103 165 166 167
		mu 0 4 89 171 125 178
		f 4 -113 168 169 170
		mu 0 4 96 169 126 177
		f 4 -123 171 172 173
		mu 0 4 187 167 127 176
		f 4 174 -87 175 -75
		mu 0 4 158 73 142 68
		f 4 176 -97 177 -85
		mu 0 4 156 80 140 76
		f 4 178 -107 179 -95
		mu 0 4 154 87 138 83
		f 4 180 -117 181 -105
		mu 0 4 152 94 136 90
		f 4 182 -127 183 -115
		mu 0 4 150 101 134 97
		f 4 184 -137 185 -125
		mu 0 4 184 108 132 104
		f 4 186 -147 187 -135
		mu 0 4 146 115 130 111
		f 4 188 -77 189 -145
		mu 0 4 144 65 128 118
		f 4 -175 -74 190 -82
		mu 0 4 159 64 174 74
		f 4 -177 -84 191 -92
		mu 0 4 157 72 172 81
		f 4 -179 -94 192 -102
		mu 0 4 155 79 170 88
		f 4 -181 -104 193 -112
		mu 0 4 153 86 168 95
		f 4 -183 -114 194 -122
		mu 0 4 151 93 166 102
		f 4 -185 -124 195 -132
		mu 0 4 149 100 164 109
		f 4 -187 -134 196 -142
		mu 0 4 147 107 162 116
		f 4 -189 -144 197 -72
		mu 0 4 145 114 160 66
		f 3 -176 -90 -78
		mu 0 3 143 77 70
		f 3 -178 -100 -88
		mu 0 3 141 84 78
		f 3 -180 -110 -98
		mu 0 3 139 91 85
		f 3 -182 -120 -108
		mu 0 3 137 98 92
		f 3 -184 -130 -118
		mu 0 3 135 105 99
		f 3 -186 -140 -128
		mu 0 3 133 112 106
		f 3 -188 -150 -138
		mu 0 3 131 119 113
		f 3 -190 -80 -148
		mu 0 3 129 69 71
		f 4 -197 -153 198 -154
		mu 0 4 163 110 183 121
		f 4 -198 -156 199 -157
		mu 0 4 161 117 182 122
		f 4 -191 -159 200 -160
		mu 0 4 175 67 181 123
		f 4 -192 -162 201 -163
		mu 0 4 173 75 180 124
		f 4 -193 -165 202 -166
		mu 0 4 171 82 179 125
		f 4 -194 -168 203 -169
		mu 0 4 169 89 178 126
		f 4 -195 -171 204 -172
		mu 0 4 167 96 177 127
		f 4 -196 -174 205 -151
		mu 0 4 165 103 186 120
		f 8 -79 -89 -99 -109 -119 -129 -139 -149
		mu 0 8 71 70 78 85 92 99 106 113;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -s -n "persp";
	rename -uid "840EB816-49EA-971D-D99F-179283AAF50C";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -126.33888221875381 81.685830110634384 27.357174875508793 ;
	setAttr ".r" -type "double3" -18.338352729644736 -80.19999999999655 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "4F0305D8-402B-2688-BB9D-54BFEE671C8D";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".ncp" 1;
	setAttr ".fcp" 100000;
	setAttr ".coi" 126.00115903593888;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "AA9C1982-4D7A-D42D-1B90-DF9487CA55D2";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "7E734FCD-45AE-DDF2-7DCE-1E894151DD00";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 1;
	setAttr ".fcp" 100000;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "B64ED956-4C0F-45B1-DB2F-0DB09667CBC7";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "CE0FE8A3-466C-01D9-21DD-1A8A24F4488F";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 1;
	setAttr ".fcp" 100000;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "F24B5433-405F-B15F-64C3-9BBED6F63E03";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "01991406-47D4-5CE5-9F24-3780E3DAA297";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 1;
	setAttr ".fcp" 100000;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode lambert -n "FloorLamp_Mat";
	rename -uid "D360D3A4-408A-0246-6B0D-8A9B46796AA2";
createNode shadingEngine -n "FloorLamp:FloorLamp_MeshSG";
	rename -uid "07212668-4874-A2E6-A435-9E9C7D9EAE1F";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
	rename -uid "BEF04893-41CE-49DB-4C44-06A2C45EB56A";
createNode file -n "FloorLamp:file1";
	rename -uid "4C8B920D-474A-8652-760D-2A8C9FC3417F";
	setAttr ".ftn" -type "string" "D:/Artique/InfographicCPR/Models-20190720T072449Z-001/Models/Props/fbx_export/floor_lamp/FloorLamp_basecolor.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture1";
	rename -uid "B7F9E8BA-4BC7-9094-2D21-87B35E0CC23D";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "E2D83E34-4408-358D-4851-24AC20068328";
	setAttr -s 3 ".lnk";
	setAttr -s 3 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "87A9A3FB-44B9-CBCC-2DF7-919A41B29D15";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "B41F86DB-4C88-B4C3-41CA-12A89F0AECCC";
createNode displayLayerManager -n "layerManager";
	rename -uid "893AE362-4311-D603-F490-CABC7DA566AF";
createNode displayLayer -n "defaultLayer";
	rename -uid "5C928F8B-4EE8-9D9E-43AE-91BA408AB3BB";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "D624C863-476F-85A9-2CF1-5CA237F75765";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "C7E42CA8-41FE-5D38-3ECF-1EAE75AC9EB7";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "F6049090-4A63-8006-6968-5CB7C97F63C1";
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
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1119\n            -height 716\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n"
		+ "            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n"
		+ "            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n"
		+ "            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n"
		+ "                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n"
		+ "                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n"
		+ "                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n"
		+ "                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n"
		+ "                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n"
		+ "                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n"
		+ "                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n"
		+ "                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n"
		+ "                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -controllers 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n"
		+ "                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n"
		+ "                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -highlightConnections 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n"
		+ "                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1119\\n    -height 716\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1119\\n    -height 716\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 50 -size 120 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "B8A0E1DF-432E-E8C6-B59B-39BC7BA56F5D";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 3 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 5 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
select -ne :defaultRenderingList1;
select -ne :defaultTextureList1;
connectAttr "FloorLamp:file1.oc" "FloorLamp_Mat.c";
connectAttr "FloorLamp:file1.ot" "FloorLamp_Mat.it";
connectAttr "FloorLamp_Mat.oc" "FloorLamp:FloorLamp_MeshSG.ss";
connectAttr "FloorLamp_MeshShape.iog" "FloorLamp:FloorLamp_MeshSG.dsm" -na;
connectAttr "FloorLamp:FloorLamp_MeshSG.msg" "materialInfo1.sg";
connectAttr "FloorLamp_Mat.msg" "materialInfo1.m";
connectAttr "FloorLamp:file1.msg" "materialInfo1.t" -na;
connectAttr "place2dTexture1.o" "FloorLamp:file1.uv";
connectAttr "place2dTexture1.ofu" "FloorLamp:file1.ofu";
connectAttr "place2dTexture1.ofv" "FloorLamp:file1.ofv";
connectAttr "place2dTexture1.rf" "FloorLamp:file1.rf";
connectAttr "place2dTexture1.reu" "FloorLamp:file1.reu";
connectAttr "place2dTexture1.rev" "FloorLamp:file1.rev";
connectAttr "place2dTexture1.vt1" "FloorLamp:file1.vt1";
connectAttr "place2dTexture1.vt2" "FloorLamp:file1.vt2";
connectAttr "place2dTexture1.vt3" "FloorLamp:file1.vt3";
connectAttr "place2dTexture1.vc1" "FloorLamp:file1.vc1";
connectAttr "place2dTexture1.ofs" "FloorLamp:file1.fs";
connectAttr ":defaultColorMgtGlobals.cme" "FloorLamp:file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "FloorLamp:file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "FloorLamp:file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "FloorLamp:file1.ws";
relationship "link" ":lightLinker1" "FloorLamp:FloorLamp_MeshSG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "FloorLamp:FloorLamp_MeshSG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "FloorLamp:FloorLamp_MeshSG.pa" ":renderPartition.st" -na;
connectAttr "FloorLamp_Mat.msg" ":defaultShaderList1.s" -na;
connectAttr "place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "FloorLamp:file1.msg" ":defaultTextureList1.tx" -na;
// End of FloorLamp.ma
