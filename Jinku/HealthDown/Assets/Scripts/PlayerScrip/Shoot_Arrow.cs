using UnityEngine;

public class Shoot_Arrow : MonoBehaviour {

    private float Speed = 10f;
    private Vector3 shootingVector;
	// Use this for initialization
	void Start ()
    {
        shootingVector = GameObject.Find("/Emey/TinyZombie").GetComponent<Vector3>();
        Debug.Log(shootingVector.x);
        Debug.Log(shootingVector.y);
        Debug.Log(shootingVector.z);
        Destroy(GameObject.Find("arrow(Clone)"), 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Speed * Time.deltaTime, 0, Speed * Time.deltaTime);
	}
    /// <summary>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(1);
        Debug.Log(other);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(2);
            GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().SetStatusOfCollider(true);
        }
    }/// </summary>
}
