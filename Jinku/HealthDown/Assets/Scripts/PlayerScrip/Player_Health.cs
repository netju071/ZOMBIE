using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{

    private GameObject HealthBar;
    private GameObject Health;
    private float Max_Health = 100f;
    private float cur_Health = 0f;
    private float damage;
    private float playerDamage = 20;
    private float dist_x;
    private float dist_y;
    private float dist_z;


    private void InitializeHealth()
    {
        HealthBar = GameObject.Find("/Player/HealthBar");
        Health = GameObject.Find("/Player/HealthBar/HealthBackground/Health");
        damage = GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().GetStatusOfDamage();
        cur_Health = Max_Health;
        dist_x = -0.03f;
        dist_y = 3.62f;
        dist_z = -0.02f;
        
    }
    public void Decreasehealth()
    {
        cur_Health = cur_Health - damage;
        float calc_Health = cur_Health / Max_Health;
        SetHealthBar(calc_Health);
        SetStatusOfCollider(false);
    }
    public void SetHealthBar(float myHealth)
    {
        Health.transform.localScale = new Vector3(myHealth, Health.transform.localScale.y, Health.transform.localScale.z);
    }
    private void MoveHealthBarAlongPlayer()
    {
        HealthBar.transform.position = new Vector3(player.transform.position.x + dist_x, player.transform.position.y + dist_y, player.transform.position.z + dist_z);
    }
    public float GetStatusOfDamage()
    {
        return playerDamage;
    }
}