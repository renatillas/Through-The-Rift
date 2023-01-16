using TMPro;
using UnityEngine;

namespace EntityScripts
{
    public class SpawnsPopUpText : MonoBehaviour
    {
        [SerializeField] private GameObject prefabPopUpText;
        [SerializeField] private Transform location;

        public void SpawnPopUpText(int text)
        {
            prefabPopUpText.GetComponent<TextMeshPro>().text = text.ToString();
            Instantiate(prefabPopUpText, location.position, Quaternion.identity);
        }
    }
}