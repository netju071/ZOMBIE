using UnityEngine;

public class Player_Attack_ShootArrow : MonoBehaviour {

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
            Destroy(gameObject);
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
        Destroy(gameObject);
    }
}
