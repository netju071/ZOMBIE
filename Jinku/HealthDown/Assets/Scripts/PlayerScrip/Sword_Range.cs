using UnityEngine;

public class Sword_Range : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Destroy(GameObject.Find("Sword_Range(Clone)"), 1.0f);
    }

    /// <summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().SetStatusOfCollider(true);
        }
    }/// </summary>


}
