using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {

    public GameObject arrow;
    public float cur_delay = 0.5f;
    public float attack_delay = 0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cur_delay += Time.deltaTime;
        if(Input.GetKeyDown("a") && cur_delay>=attack_delay)
        {
            Vector3 posit = transform.position;
            Quaternion rotat = transform.rotation;
            posit.y += 0.5f;
            posit.z += 0.6f;
            Instantiate(arrow, posit, rotat);
            cur_delay = 0;
        }
    }
}
