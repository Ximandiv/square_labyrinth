using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();

            if(Input.GetKeyDown(KeyCode.R))
            {
                string sceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadSceneAsync(sceneName);
            }
        }
    }
}