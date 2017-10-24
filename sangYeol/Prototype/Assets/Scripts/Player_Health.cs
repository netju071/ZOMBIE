using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{

    private GameObject HealthBar;
    private float dist_x;
    private float dist_y;
    private float dist_z;


    private void InitializeHealth()
    {
        HealthBar = GameObject.Find("/Player/HealthBar");
        dist_x = -0.03f;
        dist_y = 3.62f;
        dist_z = -0.02f;
    }

    private void MoveHealthBarAlongPlayer()
    {
        HealthBar.transform.position = new Vector3(player.transform.position.x + dist_x, player.transform.position.y + dist_y, player.transform.position.z + dist_z);
    }
}
