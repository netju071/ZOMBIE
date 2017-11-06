using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Range : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Destroy(GameObject.Find("Zombie_Range(Clone)"), 1.0f);
    }
    /// <summary>  decide th collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("/Player").GetComponent<Player_Controller>().SetStatusOfCollider(true);
        }
    }
    /// </summary>



}
