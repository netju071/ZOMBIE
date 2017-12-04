using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private bool isTracing;

    private void InitializeTracing()
    {
        SetStatusOfTracing(false);
    }
    private void SetStatusOfTracing(bool status)
    {
        isTracing = status;
    }
    public bool GetStatusOfTracing()
    {
        return isTracing;
    }
}
