using UnityEngine;

public class Shoot_Arrow : MonoBehaviour {

    private float Speed = 10f;
	// Use this for initialization
	void Start ()
    {
        Destroy(GameObject.Find("arrow(Clone)"), 3.0f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, Speed * Time.deltaTime);
	}
    /// <summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(2);
            GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().SetStatusOfCollider(true);
        }
    }/// </summary>
}
