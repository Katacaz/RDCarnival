﻿//////////////////////////////////////////////////////
// MK Toon Depth Only Program			       		//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

#ifndef MK_TOON_DEPTH_ONLY
	#define MK_TOON_DEPTH_ONLY
	
	#include "../Core.hlsl"
	#include "Data.hlsl"
	#include "../Surface.hlsl"

	/////////////////////////////////////////////////////////////////////////////////////////////
	// VERTEX SHADER
	/////////////////////////////////////////////////////////////////////////////////////////////
	VertexOutputDepthOnly DepthOnlyVert(VertexInputDepthOnly vertexInput)
	{
		UNITY_SETUP_INSTANCE_ID(vertexInput);
		VertexOutputDepthOnly vertexOutput;
		INITIALIZE_STRUCT(VertexOutputDepthOnly, vertexOutput);
		UNITY_TRANSFER_INSTANCE_ID(vertexInput, vertexOutput);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(vertexOutput);

		#ifdef MK_VERTEX_ANIMATION
			vertexInput.vertex.xyz = VertexAnimation(PASS_VERTEX_ANIMATION_ARG(_VertexAnimationMap, PASS_VERTEX_ANIMATION_UV(vertexInput.texcoord0.xy), _VertexAnimationIntensity, _VertexAnimationFrequency.xyz, vertexInput.vertex.xyz, vertexInput.normal));
		#endif

		vertexOutput.svPositionClip = mul(MATRIX_MVP, float4(vertexInput.vertex.xyz, 1.0));

		#if defined(MK_VERTCLR)
			vertexOutput.color = vertexInput.color;
		#endif

		//texcoords
		#if defined(MK_TCM)
			vertexOutput.uv = vertexInput.texcoord0.xy;
		#endif

		#if defined(MK_PARALLAX)
			vertexOutput.viewTangent = ComputeViewTangent(ComputeViewObject(vertexInput.vertex.xyz), vertexInput.normal, vertexInput.tangent, cross(vertexInput.normal, vertexInput.tangent.xyz) * vertexInput.tangent.w * unity_WorldTransformParams.w);
		#endif

		return vertexOutput;
	}

	/////////////////////////////////////////////////////////////////////////////////////////////
	// FRAGMENT SHADER
	/////////////////////////////////////////////////////////////////////////////////////////////
	half4 DepthOnlyFrag(VertexOutputDepthOnly vertexOutput) : SV_Target
	{
		UNITY_SETUP_INSTANCE_ID(vertexOutput);
		UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(vertexOutput);

		SurfaceData surfaceData = ComputeSurfaceData
		(
			PASS_POSITION_WORLD_ARG(0)
			PASS_FOG_FACTOR_WORLD_ARG(0)
			PASS_BASE_UV_ARG(float4(vertexOutput.uv, 0, 0))
			PASS_LIGHTMAP_UV_ARG(0)
			PASS_VERTEX_COLOR_ARG(vertexOutput.color)
			PASS_NORMAL_WORLD_ARG(1)
			PASS_VERTEX_LIGHTING_ARG(0)
			PASS_TANGENT_WORLD_ARG(1)
			PASS_VIEW_TANGENT_ARG(vertexOutput.viewTangent)
			PASS_BITANGENT_WORLD_ARG(1)
			PASS_POSITION_CLIP_ARG(0)
			PASS_NULL_CLIP_ARG(0)
			PASS_FLIPBOOK_UV_ARG(0)
		);
		Surface surface = InitSurface(surfaceData, PASS_TEXTURE_2D(_AlbedoMap, SAMPLER_REPEAT_MAIN), _AlbedoColor);

    	return 0;
	}
#endif