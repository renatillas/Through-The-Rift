using UnityEngine;

public class DestroyCountdown : MonoBehaviour
{
    [SerializeField] private float secondsToDestroy;

    void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}