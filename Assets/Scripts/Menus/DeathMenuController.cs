using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class DeathMenuController : MonoBehaviour
    {
        public void OnPlayerDeath()
        {
            gameObject.SetActive(true);
        }

        public void OnTryAgainClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnExitClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}