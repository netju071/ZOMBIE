using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWindow : MonoBehaviour {
    private Text countText;
    public int count;

    // Use this for initialization
    void Start ()
    {
        countText = GameObject.Find("/Canvas/Image/countText").GetComponent<Text>();
        count = 0;
    }
	// Update is called once per frame
	void Update ()
    {
        DyingZombieCount();
    }
    private void DyingZombieCount()
    {
        countText.text = "DyingZombieCount : " + count.ToString();
    }
}
