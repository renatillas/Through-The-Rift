using EntityScripts;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject topHalf;
    public GameObject openParticle;
    private GameObject _player;
    private Quaternion _startingRotation;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        _startingRotation = transform.rotation;
    }

    private void Update()
    {
        if (_player == null) return;
        if (Vector3.Distance(_player.transform.position, transform.position) < 2)
        {
            Instantiate(openParticle, this.transform);
            OpenMouth();
            KillPlayer();
        }
    }

    void OpenMouth()
    {
        topHalf.transform.rotation = Quaternion.RotateTowards(topHalf.transform.rotation,
            Quaternion.AngleAxis(-160, transform.right) * _startingRotation,
            200 * Time.deltaTime);
    }

    void KillPlayer()
    {
        _player.GetComponent<Health>().InstaKill();
    }
}