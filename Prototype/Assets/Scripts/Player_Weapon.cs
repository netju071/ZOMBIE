using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    public GameObject bow, sword, arrow, sword_range;
    private int curWeapon;
    private void InitializeWeapon()
    {
        bow = Resources.Load<GameObject>("LowpolyWeaponPack/Prefabs/bow");
        sword = Resources.Load<GameObject>("LowpolyWeaponPack/Prefabs/sword");
        arrow = Resources.Load<GameObject>("Create/Arrow");
        sword_range = Resources.Load<GameObject>("Create/Sword_Range");

        SetCurWeaponType(1);
        bow.SetActive(false);
    }
    private void SetCurWeaponType(int type)
    {
        curWeapon = type;
    }
    public int GetCurWeaponType()
    {
        return curWeapon;
    }
    private void SwapWeapon()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            sword.SetActive(true);
            bow.SetActive(false);
            SetCurWeaponType(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            sword.SetActive(false);
            bow.SetActive(true);
            SetCurWeaponType(2);
        }
    }
}
