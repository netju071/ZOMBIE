using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionWindow : MonoBehaviour
{
    public Rect windowSize;
    private Vector3 winPos = new Vector3(50, 0, 100);
    //private Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    // Use this for initialization
    void Start ()
    {
        //windowSize = new Rect(cam.WorldToScreenPoint(winPos).x, cam.WorldToScreenPoint(winPos).z, 300, 100);
    }
	// Update is called once per frame
	void Update ()
    {
    
    }
    private void MissionWin(int id)
    {
        //GUI.DragWindow();
    }
    public void OnGUI()
    {
        windowSize = GUI.Window(0, windowSize, MissionWin, "Mission");
    }
}
