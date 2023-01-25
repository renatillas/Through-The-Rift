using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class EndLevelMenuController : MonoBehaviour
    {
        public void OnBossDeath()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void OnContinuePlaying()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnExitClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}