using UnityEngine;
using UnityEngine.SceneManagement;
public class MissionWindow : MonoBehaviour
{
    private Rect missionWindow;
    private Rect selectWindow;
    private Rect reStartWindow;
    private string minutes,seconds;
    private int numDyingZombie;
    private int mission;
    private float startTime;
    private bool isSelect, toggle;
    
    void Start()
    {
        InitializeMissionWindow();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleWindow();
        }
        if (mission == 0)
        {
            CalculateTime();
        }
    }

    private void InitializeMissionWindow()
    {
        isSelect = false;
        toggle = true;
        startTime = Time.time;
        numDyingZombie = 0;
    }
    public void IncreaseNumberOfDyingZombie()
    {
        numDyingZombie++;
        //Debug.Log("Current NumDyingZombie: " + numDyingZombie);
    }
    private void ToggleWindow()
    {
        toggle = !toggle;
    }

    private void CalculateTime()
    {
        float t = Time.time - startTime;
        t = 300.0f - t;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");
    }
    
    private void OnGUI()
    {
        if (isSelect == false)
        {
            Time.timeScale = 0;
            selectWindow = GUI.Window(0, new Rect(Screen.width * 0.33f, Screen.height * 0.25f, 500, 200), SelectMission, "Select Mission");
        }
        else if (toggle == true)
        {
            missionWindow = GUI.Window(1, new Rect(Screen.width * 0.8f, Screen.height * 0.01f, Screen.width * 0.2f, 100), ShowMission, "Mission");
        }
        if (isSelect == false)
        {
            Time.timeScale = 0;
            selectWindow = GUI.Window(0, new Rect(Screen.width * 0.33f, Screen.height * 0.25f, 500, 200), SelectMission, "Select Mission");
        }
        if (GameObject.Find("/EventSystem").GetComponent<GameController>().GetStatusOfPause())
        {
            GUI.Box(new Rect(Screen.width * 0.35f, Screen.height * 0.15f, 500, 200), "Pause");
            GUI.skin.textField.fontSize = 20;
            GUI.skin.textField.alignment = TextAnchor.MiddleCenter;
        }
        if (GameObject.Find("/Player").GetComponent<Player_Controller>().GetStatusOfDeath())
        {
            selectWindow = GUI.Window(0, new Rect(Screen.width * 0.33f, Screen.height * 0.25f, 500, 200), Restart, "ReTry?");
        }
    }
    private void Restart(int id)
    {
        if (GUI.Button(new Rect(selectWindow.width * 0.15f, selectWindow.height * 0.35f, 150, 50), "Yes"))
        {
            SceneManager.LoadScene("game");
        }
        else if (GUI.Button(new Rect(selectWindow.width * 0.55f, selectWindow.height * 0.35f, 150, 50), "No"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    private void SelectMission(int id)
    {
        if (GUI.Button(new Rect(selectWindow.width * 0.15f, selectWindow.height * 0.35f, 150, 50), "Time Mission"))
        {
            isSelect = true;
            mission = 0;
            Time.timeScale = 1;
        }
        else if (GUI.Button(new Rect(selectWindow.width * 0.55f, selectWindow.height * 0.35f, 150, 50), "Kill Mission"))
        {
            isSelect = true;
            mission = 1;
            Time.timeScale = 1;
        }
    }

    private void ShowMission(int id)
    {
        if (mission == 0)
        {
            GUI.TextField(new Rect(missionWindow.width * 0.05f, missionWindow.height * 0.5f - 25, Screen.width * 0.18f, 50), (minutes + ":" + seconds));
        }
        else
        {
            GUI.TextField(new Rect(missionWindow.width * 0.05f, missionWindow.height * 0.5f - 25, Screen.width * 0.18f, 50), "Kills : " + numDyingZombie);
        }
    }
}

