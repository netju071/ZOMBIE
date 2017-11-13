using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Range : MonoBehaviour
{
    private float delTime;
    private void Start()
    {
        SetDeleteTime(1.0f);
    }
    void Update()
    {
        if (GetDeleteTime() <= Time.time)
        {
            DestoryCollider();
        }
    }
    private void SetDeleteTime(float value)
    {
        delTime = Time.time + value;
    }
    public float GetDeleteTime()
    {
        return delTime;
    }
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
