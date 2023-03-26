#ifndef SCENE_NORMALS_INCLUDED
#define SCENE_NORMALS_INCLUDED

#undef _Time
//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareNormalsTexture.hlsl"

void SceneNormals_float(float4 UV, out float3 Out)
{
    //Out = SAMPLE_TEXTURE2D_X(_CameraNormalsTexture, sampler_CameraNormalsTexture, UnityStereoTransformScreenSpaceTex(UV)).xyz;
    //Out = SampleSceneNormals(UV);
}

void SceneLoadNormals_float(float4 UV, out float3 Out)
{
    //Out = LOAD_TEXTURE2D_X(_CameraNormalsTexture, UV).xyz;
    //Out = LoadSceneNormals(UV);
}

#endif 
