using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private GameObject frameOfHealthBar;
    private GameObject healthBar;
    private float maxHealth, curHealth;
    private float dist_y;

    private void InitializeHealth()
    {
        frameOfHealthBar = transform.Find("HealthBar").gameObject;
        healthBar = transform.Find("HealthBar/HealthBackground/Health").gameObject;
        SetMaxHealth(100f);
        SetCurrentHealth(GetMaxHealth());
        dist_y = 2.15f;
        
    }
    public void SetMaxHealth(float value)
    {
        maxHealth = value;
    }
    public void SetCurrentHealth(float value)
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
    private void DecreaseHealth(float damage)
    {
        SetCurrentHealth(GetCurrentHealth() - damage);
        SetHealthBar(GetCurrentHealth() / GetMaxHealth());
    }
}
