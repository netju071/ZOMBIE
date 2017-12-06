using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManagement : MonoBehaviour
{
    public void NewGameBtn()
    {
        SceneManager.LoadScene("game");
    }
    public void ExitBtn()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
