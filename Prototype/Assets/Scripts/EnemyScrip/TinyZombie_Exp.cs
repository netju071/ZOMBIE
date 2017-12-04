using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private float exp;

    private void InitializeExp()
    {
        SetExp(5.0f);
    }

    public void SetExp(float value)
    {
        exp = value;
    }
    public float GetExp()
    {
        return exp;
    }
}
