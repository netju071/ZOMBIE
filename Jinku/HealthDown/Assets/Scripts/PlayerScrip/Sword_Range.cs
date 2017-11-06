using UnityEngine;

public class Sword_Range : MonoBehaviour {
    /// <summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().SetStatusOfCollider(true);
        }
    }/// </summary>
    public void DestroyCollider()
    {
        Destroy(GameObject.Find("Sword_Range(Clone)"), 1.0f);
    }
}
