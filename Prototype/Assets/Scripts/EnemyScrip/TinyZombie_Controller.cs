using UnityEngine;
using UnityEngine.AI;
public partial class TinyZombie_Controller : MonoBehaviour
{
    private GameObject zombie;
    private GameObject player;
    private bool isCollider;
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
        isCollider = false;
    }
 
    // Update is called once per frame
    private void Update()
    {
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

        if (GetCurrentHealth() <= 0)
        {
            //GameObject.Find("/EventSystem").GetComponent<MissionWindow>().count += 1;
            GameObject.Find("/Enemy").GetComponent<Zombie_Creator>().CreateFireFiles(new Vector3(zombie.transform.position.x, zombie.transform.position.y + 2.08f, zombie.transform.position.z - 1.08f));
            GameObject.Find("/Enemy").GetComponent<Zombie_Creator>().DecreaseNumberOfTinyZombie();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Range" && other.gameObject.transform.parent.tag == "Player")
        {
            DecreaseHealth(other.gameObject.transform.parent.GetComponent<Player_Controller>().GetPlayerDamage());
        }
            
    }

    public float DistanceFromTarget()
    {
        return Vector3.Distance(new Vector3(zombie.transform.position.x, 0, zombie.transform.position.z), new Vector3(player.transform.position.x, 0, player.transform.position.z));
    }
}