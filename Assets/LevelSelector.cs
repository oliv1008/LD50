using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void Select(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
