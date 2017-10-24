using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    private bool isMoving, isAttacking;

    // Constructor
    void Awake()
    {
        isMoving = isAttacking = false;
    }

    // Accessor functions
    public bool GetStatusOfMovement()
    {
        return isMoving;
    }
    public bool GetStatusOfAttack()
    {
        return isAttacking;
    }

    // Mutator functions
    public void SetStatusOfMovement(bool status)
    {
        isMoving = status;
    }
    public void SetStatusOfAttack(bool status)
    {
        isAttacking = status;
    }
}
