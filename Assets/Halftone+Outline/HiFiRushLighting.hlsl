#ifndef HIFI_RUSH_LIGHTING_INCLUDED
#define HIFI_RUSH_LIGHTING_INCLUDED

#ifndef SHADERGRAPH_PREVIEW
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
#endif

void GetMainLightData_float(
    float3 WorldPosition,
    out float3 Direction,
    out float3 Color,
    out float DistanceAttenuation,
    out float ShadowAttenuation)
{
#ifdef SHADERGRAPH_PREVIEW
    Direction = normalize(float3(0.5, 0.5, 0.25));
    Color = float3(1.0, 1.0, 1.0);
    DistanceAttenuation = 1.0;
    ShadowAttenuation = 1.0;
#else
    float4 shadowCoord = TransformWorldToShadowCoord(WorldPosition);
    Light mainLight = GetMainLight(shadowCoord);

    Direction = mainLight.direction;
    Color = mainLight.color;
    DistanceAttenuation = mainLight.distanceAttenuation;
    ShadowAttenuation = mainLight.shadowAttenuation;
#endif
}

#endif

