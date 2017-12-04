using UnityEngine;

public class Effect : MonoBehaviour {

    private float delTime;

	// Use this for initialization
	void Start()
    {
        SetDeleteTime(1.5f);
	}
	
	// Update is called once per frame
	void Update()
    {
        if (GetDeleteTime() <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    public void SetDeleteTime(float value)
    {
        delTime = Time.time + value;
    }
    public float GetDeleteTime()
    {
        return delTime;
    }
}
