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
        //zombie = GameObject.Find("/Enemy/TinyZombie/mummy_rig");
        zombie = GameObject.Find("/Enemy/" + gameObject.name + "/mummy_rig");
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
        //if (zombie == null)
        //{
        //    zombie = GameObject.Find("/Enemy/TinyZombie/mummy_rig");
        //    navAgent = zombie.GetComponent<NavMeshAgent>();
        //    frameOfHealthBar = GameObject.Find("/Enemy/TinyZombie/HealthBar");
        //    healthBar = GameObject.Find("/Enemy/TinyZombie/HealthBar/HealthBackground/Health");
        //}

        if (DistanceFromTarget() > GetDetectRange())
        {
            StopMovement();
        }
        else if(DistanceFromTarget() <= GetAttackRange())
        {
            StopMovement();
            AttackTargetObject();
        }
        else
        {
            MoveToTargetObject();
            SetStatusOfAttack(false);
            //if (DistanceFromTarget() <= GetAttackRange())
            //{
            //    StopMovement();
            //    AttackTargetObject();
            //}
        }        
        MoveHealthBarAlongZombie();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Range" && other.gameObject.transform.parent.tag == "Player")
        {
            DecreaseHealth(other.gameObject.transform.parent.GetComponent<Player_Controller>().GetPlayerDamage());
        }
            
    }
}