using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private Animator anim;
    
    private void InitializeAnimator()
    {
        anim = GetComponent<Animator>();
    }
}
