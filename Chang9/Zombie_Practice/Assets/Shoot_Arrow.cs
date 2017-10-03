using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Arrow : MonoBehaviour {

    public float Speed = 10f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, Speed * Time.deltaTime);
	}
}
