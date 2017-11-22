using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private GameObject bow, sword, arrow, sword_range;
    private int curWeapon;
    private void InitializeWeapon()
    {
        bow = GameObject.Find("/Player/Cha_Knight/Group Locator/Root/Skeleton_Root/Skeleton_Spine01/Skeleton_Spine02/Skeleton_Arm_R/Skeleton_ForeArm_R/Skeleton_Hand_R/bow");
        sword = GameObject.Find("/Player/Cha_Knight/Group Locator/Sword02");
        arrow = Resources.Load<GameObject>("Create/arrow");
        sword_range = Resources.Load<GameObject>("Create/Sword_Range");

        //bow = Resources.Load<GameObject>("LowpolyWeaponPack/Prefabs/bow");
        //sword = Resources.Load<GameObject>("LowpolyWeaponPack/Prefabs/sword");
        //arrow = Resources.Load<GameObject>("Create/Arrow");
        //sword_range = Resources.Load<GameObject>("Create/Sword_Range");

        SetCurWeaponType(1);
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
            SetAttackRange(2.0f);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            sword.SetActive(false);
            bow.SetActive(true);
            SetCurWeaponType(2);
            SetAttackRange(8.0f);
        }
        ChangeStats(GetCurWeaponType());
    }
}
