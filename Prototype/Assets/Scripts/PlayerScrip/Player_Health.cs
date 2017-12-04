using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private GameObject frameOfHealthBar;
    private GameObject healthBar;
    private float maxHealth, curHealth;
    private float dist_x;
    private float dist_y;
    private float dist_z;

    private void InitializeHealth()
    {
        frameOfHealthBar = GameObject.Find("/Player/HealthBar");
        healthBar = GameObject.Find("/Player/HealthBar/HealthBackground/Health");
        SetMaxHealth(100f);
        SetCurrentHealth(GetMaxHealth());
        dist_x = -0.03f;
        dist_y = 3.62f;
        dist_z = -0.02f;
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
    private void MoveHealthBarAlongPlayer()
    {
        frameOfHealthBar.transform.position = new Vector3(player.transform.position.x + dist_x, player.transform.position.y + dist_y, player.transform.position.z + dist_z);
    }
    private void DecreaseHealth(float damage)
    {
        SetCurrentHealth(GetCurrentHealth() - damage);
        SetHealthBar(GetCurrentHealth()/GetMaxHealth());
    }
}