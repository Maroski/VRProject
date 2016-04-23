// Shader created with Shader Forge v1.10 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.10;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:3,spmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:2,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9380,x:34521,y:32298,varname:node_9380,prsc:2|diff-7515-OUT,spec-9453-OUT,gloss-1159-OUT,emission-8100-OUT,amdfl-3700-OUT;n:type:ShaderForge.SFN_VertexColor,id:2272,x:33343,y:32604,varname:node_2272,prsc:2;n:type:ShaderForge.SFN_Vector1,id:9453,x:32459,y:32767,varname:node_9453,prsc:2,v1:0.11;n:type:ShaderForge.SFN_Vector1,id:1159,x:32459,y:32817,varname:node_1159,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Fresnel,id:6317,x:32696,y:32321,varname:node_6317,prsc:2|NRM-1015-OUT,EXP-468-OUT;n:type:ShaderForge.SFN_NormalVector,id:1015,x:32458,y:32321,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:468,x:32458,y:32457,varname:node_468,prsc:2,v1:2;n:type:ShaderForge.SFN_Color,id:4549,x:32696,y:32518,ptovrint:False,ptlb:rim foliage,ptin:_rimfoliage,varname:_rimfoliage,prsc:2,glob:False,c1:0.5427992,c2:1,c3:0.2794118,c4:1;n:type:ShaderForge.SFN_Blend,id:4164,x:32947,y:32436,varname:node_4164,prsc:2,blmd:6,clmp:True|SRC-4549-RGB,DST-6317-OUT;n:type:ShaderForge.SFN_Multiply,id:6705,x:33814,y:32532,varname:node_6705,prsc:2|A-4164-OUT,B-3662-OUT,C-2272-RGB;n:type:ShaderForge.SFN_Slider,id:3662,x:32835,y:32647,ptovrint:False,ptlb:power,ptin:_power,varname:_power,prsc:2,min:0,cur:0.9517932,max:1;n:type:ShaderForge.SFN_LightColor,id:416,x:32900,y:32182,varname:node_416,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4366,x:33881,y:32005,varname:node_4366,prsc:2|A-416-RGB,B-6317-OUT,C-8087-OUT;n:type:ShaderForge.SFN_Color,id:516,x:33234,y:32091,ptovrint:False,ptlb:color a,ptin:_colora,varname:_colora,prsc:2,glob:False,c1:0.2647059,c2:1,c3:0.5131847,c4:1;n:type:ShaderForge.SFN_Color,id:7989,x:33234,y:31877,ptovrint:False,ptlb:color b,ptin:_colorb,varname:_colorb,prsc:2,glob:False,c1:0.9926471,c2:0.663644,c3:0.3649438,c4:1;n:type:ShaderForge.SFN_Lerp,id:8087,x:33759,y:32162,varname:node_8087,prsc:2|A-7989-RGB,B-516-RGB,T-1852-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:518,x:32560,y:31512,varname:node_518,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:8503,x:33609,y:31467,varname:_grassmask,prsc:2,tex:ba11c74f6993bbf49965f60d61b8d139,ntxv:0,isnm:False|UVIN-5408-OUT,TEX-4826-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:4826,x:33166,y:31680,ptovrint:False,ptlb:mask grass,ptin:_maskgrass,varname:_maskgrass,tex:ba11c74f6993bbf49965f60d61b8d139,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:5556,x:32912,y:31394,varname:node_5556,prsc:2|A-518-X,B-518-Z;n:type:ShaderForge.SFN_Divide,id:572,x:33250,y:31312,varname:node_572,prsc:2|A-5556-OUT,B-8150-OUT;n:type:ShaderForge.SFN_Vector1,id:8150,x:32893,y:31686,varname:node_8150,prsc:2,v1:64;n:type:ShaderForge.SFN_Tex2d,id:8071,x:33619,y:31263,varname:_node_1679,prsc:2,tex:ba11c74f6993bbf49965f60d61b8d139,ntxv:0,isnm:False|UVIN-572-OUT,TEX-4826-TEX;n:type:ShaderForge.SFN_Divide,id:5408,x:33250,y:31474,varname:node_5408,prsc:2|A-5556-OUT,B-3339-OUT;n:type:ShaderForge.SFN_Vector1,id:3339,x:32968,y:31607,varname:node_3339,prsc:2,v1:8;n:type:ShaderForge.SFN_Add,id:1852,x:33926,y:31510,varname:node_1852,prsc:2|A-8071-RGB,B-8503-RGB,C-959-OUT;n:type:ShaderForge.SFN_Blend,id:1567,x:33759,y:32342,varname:node_1567,prsc:2,blmd:10,clmp:True|SRC-8087-OUT,DST-2272-RGB;n:type:ShaderForge.SFN_Add,id:4980,x:34002,y:32510,varname:node_4980,prsc:2|A-1567-OUT,B-6705-OUT;n:type:ShaderForge.SFN_Blend,id:959,x:33944,y:31300,varname:node_959,prsc:2,blmd:16,clmp:True|SRC-8071-RGB,DST-8503-RGB;n:type:ShaderForge.SFN_Lerp,id:2815,x:34056,y:32219,varname:node_2815,prsc:2|A-8087-OUT,B-1567-OUT,T-7346-OUT;n:type:ShaderForge.SFN_Vector1,id:7346,x:33961,y:32378,varname:node_7346,prsc:2,v1:0.42;n:type:ShaderForge.SFN_Desaturate,id:7515,x:34298,y:32232,varname:node_7515,prsc:2|COL-2815-OUT,DES-7226-OUT;n:type:ShaderForge.SFN_Slider,id:7226,x:34141,y:32041,ptovrint:False,ptlb:desata,ptin:_desata,varname:_desata,prsc:2,min:-2,cur:0,max:2;n:type:ShaderForge.SFN_Desaturate,id:8100,x:34271,y:32486,varname:node_8100,prsc:2|COL-4980-OUT,DES-7226-OUT;n:type:ShaderForge.SFN_Desaturate,id:3700,x:34336,y:32350,varname:node_3700,prsc:2|COL-4366-OUT,DES-7226-OUT;proporder:4549-3662-516-7989-4826-7226;pass:END;sub:END;*/

Shader "Almgp/PolyIsland/PolyIsland_VertexColor_foliage" {
    Properties {
        _rimfoliage ("rim foliage", Color) = (0.5427992,1,0.2794118,1)
        _power ("power", Range(0, 1)) = 0.9517932
        _colora ("color a", Color) = (0.2647059,1,0.5131847,1)
        _colorb ("color b", Color) = (0.9926471,0.663644,0.3649438,1)
        _maskgrass ("mask grass", 2D) = "white" {}
        _desata ("desata", Range(-2, 2)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _rimfoliage;
            uniform float _power;
            uniform float4 _colora;
            uniform float4 _colorb;
            uniform sampler2D _maskgrass; uniform float4 _maskgrass_ST;
            uniform float _desata;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
            #endif
            #ifdef DYNAMICLIGHTMAP_ON
                o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
            #endif
            o.normalDir = UnityObjectToWorldNormal(v.normal);
            o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
            o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
            o.posWorld = mul(_Object2World, v.vertex);
            float3 lightColor = _LightColor0.rgb;
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            UNITY_TRANSFER_FOG(o,o.pos);
            TRANSFER_VERTEX_TO_FRAGMENT(o)
            return o;
        }
        float4 frag(VertexOutput i) : COLOR {
            i.normalDir = normalize(i.normalDir);
            float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 normalDirection = i.normalDir;
            
            float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
            i.normalDir *= nSign;
            normalDirection *= nSign;
            
            float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
            float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
            float Pi = 3.141592654;
            float InvPi = 0.31830988618;
///// Gloss:
            float gloss = 0.1;
            float specPow = exp2( gloss * 10.0+1.0);
/// GI Data:
            UnityLight light;
            #ifdef LIGHTMAP_OFF
                light.color = lightColor;
                light.dir = lightDirection;
                light.ndotl = LambertTerm (normalDirection, light.dir);
            #else
                light.color = half3(0.f, 0.f, 0.f);
                light.ndotl = 0.0f;
                light.dir = half3(0.f, 0.f, 0.f);
            #endif
            UnityGIInput d;
            d.light = light;
            d.worldPos = i.posWorld.xyz;
            d.worldViewDir = viewDirection;
            d.atten = attenuation;
            #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                d.ambient = 0;
                d.lightmapUV = i.ambientOrLightmapUV;
            #else
                d.ambient = i.ambientOrLightmapUV;
            #endif
            d.boxMax[0] = unity_SpecCube0_BoxMax;
            d.boxMin[0] = unity_SpecCube0_BoxMin;
            d.probePosition[0] = unity_SpecCube0_ProbePosition;
            d.probeHDR[0] = unity_SpecCube0_HDR;
            d.boxMax[1] = unity_SpecCube1_BoxMax;
            d.boxMin[1] = unity_SpecCube1_BoxMin;
            d.probePosition[1] = unity_SpecCube1_ProbePosition;
            d.probeHDR[1] = unity_SpecCube1_HDR;
            UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
            lightDirection = gi.light.dir;
            lightColor = gi.light.color;
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float LdotH = max(0.0,dot(lightDirection, halfDirection));
            float node_9453 = 0.11;
            float3 specularColor = float3(node_9453,node_9453,node_9453);
            float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
            float NdotV = max(0.0,dot( normalDirection, viewDirection ));
            float NdotH = max(0.0,dot( normalDirection, halfDirection ));
            float VdotH = max(0.0,dot( viewDirection, halfDirection ));
            float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
            float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
            float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
            float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
            half grazingTerm = saturate( gloss + specularMonochrome );
            float3 indirectSpecular = (gi.indirect.specular);
            indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
            float3 specular = (directSpecular + indirectSpecular);
/// Diffuse:
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
            float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
            float3 indirectDiffuse = float3(0,0,0);
            float node_6317 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),2.0);
            float2 node_5556 = float2(i.posWorld.r,i.posWorld.b);
            float2 node_572 = (node_5556/64.0);
            float4 _node_1679 = tex2D(_maskgrass,TRANSFORM_TEX(node_572, _maskgrass));
            float2 node_5408 = (node_5556/8.0);
            float4 _grassmask = tex2D(_maskgrass,TRANSFORM_TEX(node_5408, _maskgrass));
            float3 node_8087 = lerp(_colorb.rgb,_colora.rgb,(_node_1679.rgb+_grassmask.rgb+saturate(round( 0.5*(_node_1679.rgb + _grassmask.rgb)))));
            indirectDiffuse += lerp((_LightColor0.rgb*node_6317*node_8087),dot((_LightColor0.rgb*node_6317*node_8087),float3(0.3,0.59,0.11)),_desata); // Diffuse Ambient Light
            indirectDiffuse += gi.indirect.diffuse;
            float3 node_1567 = saturate(( i.vertexColor.rgb > 0.5 ? (1.0-(1.0-2.0*(i.vertexColor.rgb-0.5))*(1.0-node_8087)) : (2.0*i.vertexColor.rgb*node_8087) ));
            float3 diffuseColor = lerp(lerp(node_8087,node_1567,0.42),dot(lerp(node_8087,node_1567,0.42),float3(0.3,0.59,0.11)),_desata);
            diffuseColor *= 1-specularMonochrome;
            float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
// Emissive:
            float3 emissive = lerp((node_1567+(saturate((1.0-(1.0-_rimfoliage.rgb)*(1.0-node_6317)))*_power*i.vertexColor.rgb)),dot((node_1567+(saturate((1.0-(1.0-_rimfoliage.rgb)*(1.0-node_6317)))*_power*i.vertexColor.rgb)),float3(0.3,0.59,0.11)),_desata);
// Final Color:
            float3 finalColor = diffuse + specular + emissive;
            fixed4 finalRGBA = fixed4(finalColor,1);
            UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
            return finalRGBA;
        }
        ENDCG
    }
    Pass {
        Name "FORWARD_DELTA"
        Tags {
            "LightMode"="ForwardAdd"
        }
        Blend One One
        Cull Off
        
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #define UNITY_PASS_FORWARDADD
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #define _GLOSSYENV 1
        #include "UnityCG.cginc"
        #include "AutoLight.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #pragma multi_compile_fwdadd_fullshadows
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma multi_compile_fog
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform float4 _rimfoliage;
        uniform float _power;
        uniform float4 _colora;
        uniform float4 _colorb;
        uniform sampler2D _maskgrass; uniform float4 _maskgrass_ST;
        uniform float _desata;
        struct VertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 tangent : TANGENT;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
            float4 vertexColor : COLOR;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv1 : TEXCOORD0;
            float2 uv2 : TEXCOORD1;
            float4 posWorld : TEXCOORD2;
            float3 normalDir : TEXCOORD3;
            float3 tangentDir : TEXCOORD4;
            float3 bitangentDir : TEXCOORD5;
            float4 vertexColor : COLOR;
            LIGHTING_COORDS(6,7)
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.vertexColor = v.vertexColor;
            o.normalDir = UnityObjectToWorldNormal(v.normal);
            o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
            o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
            o.posWorld = mul(_Object2World, v.vertex);
            float3 lightColor = _LightColor0.rgb;
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            TRANSFER_VERTEX_TO_FRAGMENT(o)
            return o;
        }
        float4 frag(VertexOutput i) : COLOR {
            i.normalDir = normalize(i.normalDir);
            float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 normalDirection = i.normalDir;
            
            float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
            i.normalDir *= nSign;
            normalDirection *= nSign;
            
            float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
            float Pi = 3.141592654;
            float InvPi = 0.31830988618;
///// Gloss:
            float gloss = 0.1;
            float specPow = exp2( gloss * 10.0+1.0);
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float LdotH = max(0.0,dot(lightDirection, halfDirection));
            float node_9453 = 0.11;
            float3 specularColor = float3(node_9453,node_9453,node_9453);
            float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
            float NdotV = max(0.0,dot( normalDirection, viewDirection ));
            float NdotH = max(0.0,dot( normalDirection, halfDirection ));
            float VdotH = max(0.0,dot( viewDirection, halfDirection ));
            float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
            float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
            float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
            float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
            float3 specular = directSpecular;
/// Diffuse:
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
            float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
            float2 node_5556 = float2(i.posWorld.r,i.posWorld.b);
            float2 node_572 = (node_5556/64.0);
            float4 _node_1679 = tex2D(_maskgrass,TRANSFORM_TEX(node_572, _maskgrass));
            float2 node_5408 = (node_5556/8.0);
            float4 _grassmask = tex2D(_maskgrass,TRANSFORM_TEX(node_5408, _maskgrass));
            float3 node_8087 = lerp(_colorb.rgb,_colora.rgb,(_node_1679.rgb+_grassmask.rgb+saturate(round( 0.5*(_node_1679.rgb + _grassmask.rgb)))));
            float3 node_1567 = saturate(( i.vertexColor.rgb > 0.5 ? (1.0-(1.0-2.0*(i.vertexColor.rgb-0.5))*(1.0-node_8087)) : (2.0*i.vertexColor.rgb*node_8087) ));
            float3 diffuseColor = lerp(lerp(node_8087,node_1567,0.42),dot(lerp(node_8087,node_1567,0.42),float3(0.3,0.59,0.11)),_desata);
            diffuseColor *= 1-specularMonochrome;
            float3 diffuse = directDiffuse * diffuseColor;
// Final Color:
            float3 finalColor = diffuse + specular;
            return fixed4(finalColor * 1,0);
        }
        ENDCG
    }
    Pass {
        Name "Meta"
        Tags {
            "LightMode"="Meta"
        }
        Cull Off
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #define UNITY_PASS_META 1
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #define _GLOSSYENV 1
        #include "UnityCG.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #include "UnityMetaPass.cginc"
        #pragma fragmentoption ARB_precision_hint_fastest
        #pragma multi_compile_shadowcaster
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma multi_compile_fog
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform float4 _rimfoliage;
        uniform float _power;
        uniform float4 _colora;
        uniform float4 _colorb;
        uniform sampler2D _maskgrass; uniform float4 _maskgrass_ST;
        uniform float _desata;
        struct VertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
            float4 vertexColor : COLOR;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv1 : TEXCOORD0;
            float2 uv2 : TEXCOORD1;
            float4 posWorld : TEXCOORD2;
            float3 normalDir : TEXCOORD3;
            float4 vertexColor : COLOR;
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.vertexColor = v.vertexColor;
            o.normalDir = UnityObjectToWorldNormal(v.normal);
            o.posWorld = mul(_Object2World, v.vertex);
            o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
            return o;
        }
        float4 frag(VertexOutput i) : SV_Target {
            i.normalDir = normalize(i.normalDir);
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 normalDirection = i.normalDir;
            
            float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
            i.normalDir *= nSign;
            normalDirection *= nSign;
            
            UnityMetaInput o;
            UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
            
            float2 node_5556 = float2(i.posWorld.r,i.posWorld.b);
            float2 node_572 = (node_5556/64.0);
            float4 _node_1679 = tex2D(_maskgrass,TRANSFORM_TEX(node_572, _maskgrass));
            float2 node_5408 = (node_5556/8.0);
            float4 _grassmask = tex2D(_maskgrass,TRANSFORM_TEX(node_5408, _maskgrass));
            float3 node_8087 = lerp(_colorb.rgb,_colora.rgb,(_node_1679.rgb+_grassmask.rgb+saturate(round( 0.5*(_node_1679.rgb + _grassmask.rgb)))));
            float3 node_1567 = saturate(( i.vertexColor.rgb > 0.5 ? (1.0-(1.0-2.0*(i.vertexColor.rgb-0.5))*(1.0-node_8087)) : (2.0*i.vertexColor.rgb*node_8087) ));
            float node_6317 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),2.0);
            o.Emission = lerp((node_1567+(saturate((1.0-(1.0-_rimfoliage.rgb)*(1.0-node_6317)))*_power*i.vertexColor.rgb)),dot((node_1567+(saturate((1.0-(1.0-_rimfoliage.rgb)*(1.0-node_6317)))*_power*i.vertexColor.rgb)),float3(0.3,0.59,0.11)),_desata);
            
            float3 diffColor = lerp(lerp(node_8087,node_1567,0.42),dot(lerp(node_8087,node_1567,0.42),float3(0.3,0.59,0.11)),_desata);
            float node_9453 = 0.11;
            float3 specColor = float3(node_9453,node_9453,node_9453);
            float specularMonochrome = max(max(specColor.r, specColor.g),specColor.b);
            diffColor *= (1.0-specularMonochrome);
            float roughness = 1.0 - 0.1;
            o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
            
            return UnityMetaFragment( o );
        }
        ENDCG
    }
}
FallBack "Diffuse"
CustomEditor "ShaderForgeMaterialInspector"
}
