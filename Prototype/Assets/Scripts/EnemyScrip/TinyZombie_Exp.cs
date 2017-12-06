using UnityEngine;

public partial class TinyZombie_Controller : MonoBehaviour
{
    private float exp;

    private void InitializeExp()
    {
        SetExp(5.0f);
    }

    public void SetExp(float value)
    {
        exp = value;
    }
    public float GetExp()
    {
        return exp;
    }
    private void ReceiveExp(int WeaponType)
    {
        switch (WeaponType)
        {
            case 1:
                Debug.Log("칼 경험치!");
                GameObject.Find("/Player/Cha_Knight/Group Locator/Sword02").GetComponent<Weapon_Sword>().IncreaseExp(GetExp());
                break;

            case 2:
                Debug.Log("활 경험치!");
                GameObject.Find("/Player/Cha_Knight/Group Locator/Root/Skeleton_Root/Skeleton_Spine01/Skeleton_Spine02/Skeleton_Arm_R/Skeleton_ForeArm_R/Skeleton_Hand_R/bow").GetComponent<Weapon_Bow>().IncreaseExp(GetExp());
                break;

            default:
                Debug.Log("[경고]: CurWeaponType값이 범위에서 벗어났습니다.");
                break;

        }
    }
}
