using UnityEngine;
using UnityEngine.AI;
public partial class TinyZombie_Controller : MonoBehaviour
{
    private GameObject zombie;
    private GameObject player;
    private bool isCollider;
    // Use this for initialization
    private void Awake()
    {
        zombie = GameObject.Find("/Enemy/TinyZombie/mummy_rig");
        player = GameObject.Find("/Player/Cha_Knight");
        InitializeAnimator();
        InitializeMovement();
        InitializeAttack();
        InitializeHealth();
        isCollider = false;
    }
    public float DistanceFromTarget()
    {
        return Vector3.Distance(new Vector3(zombie.transform.position.x, 0, zombie.transform.position.z), new Vector3(player.transform.position.x, 0, player.transform.position.z));
    }

    // Update is called once per frame
    private void Update()
    {
        if (zombie == null)
        {
            zombie = GameObject.Find("/Enemy/TinyZombie/mummy_rig");
            navAgent = zombie.GetComponent<NavMeshAgent>();
            HealthBar = GameObject.Find("/Enemy/TinyZombie/HealthBar");
            Health = GameObject.Find("/Enemy/TinyZombie/HealthBar/HealthBackground/Health");
        }
        //Debug.Log("distance: " +DistanceFromTarget());
        if (GetAttackRange()<DistanceFromTarget()&& DistanceFromTarget()<7)
        {
            MoveToTargetObject();
            SetStatusOfAttack(false);
            if(DistanceFromTarget() <=GetAttackRange())
            {
                StopMovement();
                AttackTargetObject();
            }
        }
        else if(DistanceFromTarget()<=GetAttackRange())
        {
            StopMovement();
            AttackTargetObject();
        }
        else if(DistanceFromTarget() >7)
        {
            StopMovement();
        }
        MoveHealthBarAlongZombie();
    }
    ////////////////////////////////////////// collider statuse change function
    public void SetStatusOfCollider(bool status)
    {
        isCollider = status;
    }
    public bool GetStatusOfCollider()
    {
        return isCollider;
    }
    ///////////////////////////////////////////////
}