using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void buttonPush2()
    {
        string targetSceneName = "Level02";
        SceneManager.LoadScene(targetSceneName);
    }
        public void buttonPush1()
    {
        string targetSceneName = "Level01";
        SceneManager.LoadScene(targetSceneName);
    }
        public void buttonPush3()
    {
        string targetSceneName = "Level03";
        SceneManager.LoadScene(targetSceneName);
    }
}