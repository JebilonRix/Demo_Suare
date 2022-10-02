using UnityEngine;
using UnityEngine.SceneManagement;

namespace SuareDemo
{
    [CreateAssetMenu(menuName = "Red Panda/Restart")]
    public class SO_RestartButton : ScriptableObject
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}