using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private float exp;

    private void InitializeExp()
    {
        exp = 5f;
    }

    public float GetExp()
    {
        return exp;
    }

    public void SetExp(float value)
    {
        exp = value;
    }
}
