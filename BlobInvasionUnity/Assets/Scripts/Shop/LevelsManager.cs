using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.Shop
{
    public class LevelsManager : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}