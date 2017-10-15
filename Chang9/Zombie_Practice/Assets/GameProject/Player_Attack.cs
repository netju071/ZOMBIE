using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {

    public GameObject arrow, sward_effect;
    public float cur_delay = 0f;
    public int cur_weapon = 0;
    public float attack_delay = 0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
    void SwardAttack()
    {
        Vector3 posit = transform.position;
        Quaternion rotat = transform.rotation;
        Instantiate(sward_effect, posit, rotat);
        cur_delay = 0;
    }
    void ArrowAttack()
    {
        Vector3 posit = transform.position;
        Quaternion rotat = transform.rotation;
        posit.y += 0.5f;
        posit.z += 0.7f;
        Instantiate(arrow, posit, rotat);
        cur_delay = 0;

    }
	// Update is called once per frame
	void Update () {
        cur_delay += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && cur_delay>=attack_delay)
        {
            switch(cur_weapon)
            {
                case 0:
                    SwardAttack(); break;
                case 1:
                    ArrowAttack(); break;

                
            }
        }
    }
}
