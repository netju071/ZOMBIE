using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour {
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
