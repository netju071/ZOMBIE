using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour {
    private GameObject player;
    private float dist_x = -0.44f;
    private float dist_y = 15.51f;
    private float dist_z = 16.15f;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
    }
    
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x + dist_x, player.transform.position.y + dist_y, player.transform.position.z + dist_z);
    }
}
