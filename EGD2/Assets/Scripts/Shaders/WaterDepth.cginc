#if !defined(DEPTH_NEEDED)
#define DEPTH_NEEDED

sampler2D _CameraDepthTexture, _WaterBackground;
float4 _CameraDepthTexture_TexelSize;

float3 ColorBelowWater(float4 screenPos){
	float depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, screenPos)).r;
	float foamLine = 1 - saturate((depth-screenPos.w));
	return foamLine;
}
#endif