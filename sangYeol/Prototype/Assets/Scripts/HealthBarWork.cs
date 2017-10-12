using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarWork : MonoBehaviour {

    public Image healthBar;
    private GameObject player;

    private float dist_x = -0.03f;
    private float dist_y = 3.62f;
    private float dist_z = -0.02f;


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Cha_Knight");
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(transform.position + ", " + player.transform.position);
        transform.position = new Vector3(player.transform.position.x + dist_x, player.transform.position.y + dist_y, player.transform.position.z + dist_z);
    }
}
