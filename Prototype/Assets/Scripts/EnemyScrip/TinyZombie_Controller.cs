using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private GameObject zombie;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        zombie = transform.Find("mummy_rig").gameObject;
        GameObject.Find("/Enemy").GetComponent<Zombie_Creator>().IncreaseNumberOfTinyZombie();
        player = GameObject.Find("/Player/Cha_Knight");
        InitializeAnimator();
        InitializeMovement();
        InitializeAttack();
        InitializeHealth();
        InitializeExp();
    }
 
    // Update is called once per frame
    private void Update()
    {
        if (GetStatusOfTracing() == true)
        {
            SetTargetPosition(player.transform.position);

            if (DistanceFromPosition(GetTargetPosition()) > GetDetectRange())
            {
                StopMovement();
                SetStatusOfTracing(false);
                SetTimeToMove();
            }
            else if (DistanceFromPosition(GetTargetPosition()) <= GetAttackRange())
            {
                StopMovement();
                AttackTargetObject();
            }
            else
            {
                SetStatusOfAttack(false);
                MoveToTarget();
            }
        }
        else
        {
            if (DistanceFromPosition(player.transform.position) <= GetDetectRange())
            {
                SetStatusOfTracing(true);
                SetTargetPosition(player.transform.position);
                MoveToTarget();
            }
            else if(GetStatusOfMovement() == true)
            {
                if(GetTimeToStop() <= Time.time)
                {
                    StopMovement();
                    SetTimeToMove();
                }
                else
                {
                    MoveToTarget();
                }
            }
            else if(GetTimeToMove() <= Time.time)
            {
                SetTargetPosition(RandomPosition());
                MoveToTarget();
                SetTimeToStop();
            }
        }

        MoveHealthBarAlongZombie();

        if (GetCurrentHealth() <= 0)
        {
            DestroyZombie();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Range" && other.gameObject.transform.parent.tag == "Player")
        {
            DecreaseHealth(other.gameObject.transform.parent.GetComponent<Player_Controller>().GetAttackDamage());
        }
            
    }
    
    private float DistanceFromTarget()
    {
        return Vector3.Distance(new Vector3(zombie.transform.position.x, 0, zombie.transform.position.z), new Vector3(player.transform.position.x, 0, player.transform.position.z));
    }



    private void DestroyZombie()
    {
        GameObject.Find("/Main Camera").GetComponent<MissionWindow>().IncreaseNumberOfDyingZombie();
        GameObject.Find("/Enemy").GetComponent<Zombie_Creator>().CreateFireFiles(new Vector3(zombie.transform.position.x, zombie.transform.position.y + 2.08f, zombie.transform.position.z - 1.08f));
        GameObject.Find("/Enemy").GetComponent<Zombie_Creator>().DecreaseNumberOfTinyZombie();
        ReceiveExp(GameObject.Find("/Player").GetComponent<Player_Controller>().GetCurWeaponType());
        Destroy(gameObject);
    }
}