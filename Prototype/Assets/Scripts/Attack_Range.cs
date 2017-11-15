using UnityEngine;

public class Attack_Range : MonoBehaviour {

    private float delTime;

	// Use this for initialization
	void Start ()
    {
        SetDeleteTime(0.1f);    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetDeleteTime() <= Time.time)
        {
            Destroy(gameObject);
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
}
