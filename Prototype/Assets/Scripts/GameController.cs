using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private bool isPause;

	// Use this for initialization
	void Start () {
        SetStatusOfPause(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (GetStatusOfPause())
            {
                case false:
                    Time.timeScale = 0;
                    SetStatusOfPause(true);
                    break;
                case true:
                    Time.timeScale = 1;
                    SetStatusOfPause(false);
                    break;
            }
        }
	}
    private void SetStatusOfPause(bool status)
    {
        isPause = status;
    }
    public bool GetStatusOfPause()
    {
        return isPause;
    }
}
