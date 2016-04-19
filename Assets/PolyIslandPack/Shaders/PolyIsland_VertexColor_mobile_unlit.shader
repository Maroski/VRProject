// Shader created with Shader Forge v1.10 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.10;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:1,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1751,x:33109,y:32463,varname:node_1751,prsc:2|emission-7605-OUT;n:type:ShaderForge.SFN_VertexColor,id:2367,x:32138,y:32723,varname:node_2367,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:7680,x:32475,y:32823,varname:node_7680,prsc:2|NRM-4951-OUT,EXP-422-OUT;n:type:ShaderForge.SFN_NormalVector,id:4951,x:32252,y:32596,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:422,x:32315,y:32857,varname:node_422,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Multiply,id:2943,x:32656,y:32862,varname:node_2943,prsc:2|A-7680-OUT,B-612-OUT;n:type:ShaderForge.SFN_Vector1,id:612,x:32526,y:33014,varname:node_612,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:9945,x:32523,y:32655,varname:node_9945,prsc:2|IN-2943-OUT;n:type:ShaderForge.SFN_Blend,id:7605,x:32691,y:32529,varname:node_7605,prsc:2,blmd:12,clmp:True|SRC-2367-RGB,DST-9945-OUT;pass:END;sub:END;*/

Shader "Almgp/PolyIsland/PolyIsland_VertexColor_mobile_unlit" {
    Properties {
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = saturate((i.vertexColor.rgb > 0.5 ?  (1.0-(1.0-2.0*(i.vertexColor.rgb-0.5))*(1.0-(1.0 - (pow(1.0-max(0,dot(i.normalDir, viewDirection)),0.7)*1.0)))) : (2.0*i.vertexColor.rgb*(1.0 - (pow(1.0-max(0,dot(i.normalDir, viewDirection)),0.7)*1.0)))) );
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
