using UnityEngine;

public class Sword_Range : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Find("/Enemy/TinyZombie").GetComponent<TinyZombie_Controller>().SetStatusOfBeingAttacked(true);  // 현재 1:1 경우만 고려
            //other.gameObject.GetComponent<controller>().setstatusofbeingAttacked(true) // 1:@ 고려 (추후 적용)
        }
    }
    public void DestoryCollider()
    {
        Destroy(GameObject.Find("Sword_Range(Clone)"), 0.0f); // 시간 파라미터 제거해보자
    }
}
