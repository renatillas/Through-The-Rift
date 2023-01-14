using UnityEngine;

public class SpawnsPopUpText : MonoBehaviour
{
    [SerializeField] private GameObject prefabPopUpText;

    [SerializeField] private float secondsOnAir;

    [SerializeField] private Transform location;

    public void PopUpText(int text)
    {
        prefabPopUpText.GetComponent<TextMesh>().text = text.ToString();
        GameObject popup = Instantiate(prefabPopUpText, location.position,
            Quaternion.LookRotation(-Camera.main.transform.position));
        Destroy(popup, secondsOnAir);
    }
}