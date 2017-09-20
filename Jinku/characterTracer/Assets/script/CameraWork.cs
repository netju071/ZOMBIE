using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour {
    
    GameObject Skeleton;

    // Use this for initialization
    void Start () {
        Skeleton = GameObject.Find("Skeleton");

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Skeleton.transform.position.x-20.6f, Skeleton.transform.position.y + 5.12f, Skeleton.transform.position.z - 20.6f);
	}
}
