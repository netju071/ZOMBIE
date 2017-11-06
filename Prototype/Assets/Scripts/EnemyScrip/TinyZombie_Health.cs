using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{

    private GameObject HealthBar;
    private GameObject Health;
    private GameObject respawn;
    private float dist_y;
    private float Max_Health = 100f;
    private float cur_Health = 0f;
    private float TinyZombieDamage = 5;
    private float damage;

    private void InitializeHealth()
    {
        HealthBar = GameObject.Find("/Enemy/TinyZombie/HealthBar");
        Health = GameObject.Find("/Enemy/TinyZombie/HealthBar/HealthBackground/Health");
        respawn = Resources.Load<GameObject>("Create/TinyZombie");
        damage = GameObject.Find("/Player").GetComponent<Player_Controller>().GetStatusOfDamage();
        cur_Health = Max_Health;
        dist_y = 2.15f;
        
    }
    public void Decreasehealth()
    {
        cur_Health = cur_Health- damage;
        float calc_Health = cur_Health / Max_Health;
        SetHealthBar(calc_Health);
        if(cur_Health == 0)
        {
            Destroy(GameObject.Find("/Enemy/TinyZombie"));
            GameObject newViking1 = (GameObject)Instantiate(respawn, respawn.transform.position, Quaternion.identity);
            newViking1.GetComponent<TinyZombie_Controller>().Awake();
            newViking1.name = "TinyZombie";
            newViking1.transform.parent = GameObject.Find("/Enemy").transform;
            
        }
    }
    public  void SetHealthBar(float myHealth)
    {
        Health.transform.localScale = new Vector3(myHealth, Health.transform.localScale.y, Health.transform.localScale.z);
    }
    private void MoveHealthBarAlongZombie()
    {
        HealthBar.transform.position = new Vector3(zombie.transform.position.x, zombie.transform.position.y+dist_y, zombie.transform.position.z);
    }
    public float GetStatusOfDamage()
    {
        return TinyZombieDamage;
    }
}
