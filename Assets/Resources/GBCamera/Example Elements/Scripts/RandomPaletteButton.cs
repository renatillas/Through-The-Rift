using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Camara_GBA.GBCamera.Example_Elements.Scripts
{
namespace GBCamera
{

public class RandomPaletteButton : MonoBehaviour
{
	
	[FormerlySerializedAs("_fadeMaterials")] public FadeMaterials fadeMaterials;
	[FormerlySerializedAs("_randomPalette")] public RandomPalette randomPalette;
	private bool _switchingPalette = false;
	
	public void OnChooseRandomPalette ()
	{
		if (!_switchingPalette)
		{
			StartCoroutine (ChooseRandomPalette ());
		}
			
	}
	
	public IEnumerator ChooseRandomPalette ()
	{
		_switchingPalette = true;
		yield return fadeMaterials.StartCoroutine (fadeMaterials.FadeOut ());
		randomPalette.SelectRandomPalette ();
		yield return fadeMaterials.StartCoroutine (fadeMaterials.FadeIn());
		_switchingPalette = false;
	}
	

}


}
}
