using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{

    private GameObject frameOfHealthBar;
    private GameObject healthBar;
    private GameObject respawn;
    private float maxHealth, curHealth;
    private float dist_y;

    private void InitializeHealth()
    {
        frameOfHealthBar = GameObject.Find("/Enemy/TinyZombie/HealthBar");
        healthBar = GameObject.Find("/Enemy/TinyZombie/HealthBar/HealthBackground/Health");
        respawn = Resources.Load<GameObject>("Create/TinyZombie");
        SetMaxHealth(100f);
        SetCurrentHealth(GetMaxHealth());
        dist_y = 2.15f;
        
    }
    private void SetMaxHealth(float value)
    {
        maxHealth = value;
    }
    private void SetCurrentHealth(float value)
    {
        curHealth = value;
    }
    public void SetHealthBar(float health)
    {
        healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetCurrentHealth()
    {
        return curHealth;
    }
    private void MoveHealthBarAlongZombie()
    {
        frameOfHealthBar.transform.position = new Vector3(zombie.transform.position.x, zombie.transform.position.y + dist_y, zombie.transform.position.z);
    }
    public void DecreaseHealth(float damage)
    {
        SetCurrentHealth(GetCurrentHealth() - damage);
        SetHealthBar(GetCurrentHealth() / GetMaxHealth());
        SetStatusOfBeingAttacked(false);
        if (GetCurrentHealth() == 0)
        {
            Destroy(GameObject.Find("/Enemy/TinyZombie"));
            GameObject newZombie = (GameObject)Instantiate(respawn, respawn.transform.position, Quaternion.identity);
            newZombie.GetComponent<TinyZombie_Controller>().Awake();
            newZombie.name = "TinyZombie";
            newZombie.transform.parent = GameObject.Find("/Enemy").transform;
            
        }
    }
}
