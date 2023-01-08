﻿using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Camara_GBA.GBCamera.Example_Elements.Scripts
{
	public class FadeMaterials : MonoBehaviour {

		[FormerlySerializedAs("_materials")] public Material[] materials;
		[FormerlySerializedAs("_fadeAmountPerSecond")] public float fadeAmountPerSecond;
	
	
		public IEnumerator FadeIn ()
		{
			bool complete = false;
		
			while (!complete)
			{
				complete = true;
			
				for (int i = 0; i < materials.Length; i++)
				{
					float fade = materials[i].GetFloat ("_Fade");
				
					fade = Mathf.Min (1f, fade + (fadeAmountPerSecond * Time.deltaTime));
					if (fade < 1f)
					{
						complete = false;
					}
				
					materials[i].SetFloat ("_Fade", fade);
				}
			
				yield return null;
			}
		
			yield break;
		
		}
	
		public IEnumerator FadeOut ()
		{
			bool complete = false;
		
			while (!complete)
			{
				complete = true;
			
				for (int i = 0; i < materials.Length; i++)
				{
					float fade = materials[i].GetFloat ("_Fade");
				
					fade = Mathf.Max (0f, fade - (fadeAmountPerSecond * Time.deltaTime));
					if (fade > 0)
					{
						complete = false;
					}
				
					materials[i].SetFloat ("_Fade", fade);
				}
			
				yield return null;
			}
		
			yield break;
		
		}
	
	}
}
