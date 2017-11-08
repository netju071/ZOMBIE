using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Range : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("/Player").GetComponent<Player_Controller>().SetStatusOfBeingAttacked(true);
        }
    }
    public void DestoryCollider()
    {
        Destroy(GameObject.Find("Zombie_Range(Clone)"), 0.0f);
    }


}
