using UnityEngine;

public class SpawnsPopUpText : MonoBehaviour
{
    [SerializeField] private GameObject prefabPopUpText;


    [SerializeField] private Transform location;

    public void SpawnPopUpText(int text)
    {
        prefabPopUpText.GetComponent<TextMesh>().text = text.ToString();
        GameObject popup = Instantiate(prefabPopUpText, location.position,
            Quaternion.LookRotation(-Camera.main.transform.position));
    }
}