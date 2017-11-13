using UnityEngine;

public class Shoot_Arrow : MonoBehaviour {

    private float arrowSpeed, delTime;

	// Use this for initialization
	void Start ()
    {
        SetArrowSpeed(10f);
        SetDeleteTime(1.0f);
    }
	// Update is called once per frame
	void Update ()
    {
        MoveInDirection();

        if(GetDeleteTime() <= Time.time)
        {
            DestoryCollider();
        }
    }
    private void SetArrowSpeed(float value)
    {
        arrowSpeed = value;
    }
    private void SetDeleteTime(float value)
    {
        delTime = Time.time + value;
    }
    public float GetArrowSpeed()
    {
        return arrowSpeed;
    }
    public float GetDeleteTime()
    {
        return delTime;
    }
    private void MoveInDirection()
    {
        transform.Translate(0, 0, GetArrowSpeed() * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().SetStatusOfBeingAttacked(true);
        }
        DestoryCollider();
    }
    public void DestoryCollider()
    {
        Destroy(GameObject.Find("arrow(Clone)"), 0.0f);
    }
}
