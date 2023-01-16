using UnityEngine;
using UnityEngine.Serialization;

namespace Resources.GBCamera.Example_Elements.Scripts
{
    namespace GBCamera
    {
        public class RandomPalette : MonoBehaviour
        {
            [FormerlySerializedAs("_palettes")] public Texture[] palettes;
            [FormerlySerializedAs("_materials")] public Material[] materials;
            private int _previousPaletteIndex = 0;

            public void SelectRandomPalette()
            {
                if (palettes.Length == 0 || materials.Length == 0)
                    return;

                var randomPaletteIndex = _previousPaletteIndex;
                while (randomPaletteIndex == _previousPaletteIndex)
                {
                    randomPaletteIndex = Random.Range(0, palettes.Length);
                }

                for (var i = 0; i < materials.Length; i++)
                {
                    materials[i].SetTexture("_Palette", palettes[randomPaletteIndex]);
                }

                _previousPaletteIndex = randomPaletteIndex;
            }
        }
    } // GBCamera
} // RogueNoodle