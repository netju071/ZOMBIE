using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_unit : MonoBehaviour {

    public float health=100f;
    public Collider col;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        col = GetComponent<Collider>();
        if (col.gameObject.tag=="effect")
        {
            health -= 10f;
            print(health);   
        }
	}
}
