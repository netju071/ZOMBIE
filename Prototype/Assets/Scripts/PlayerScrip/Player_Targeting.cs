using UnityEngine;

public partial class Player_Controller : MonoBehaviour
{
    private GameObject targetObject;
    private Vector3 targetPosition;

    private void InitializeTargeting()
    {
        Untargeting();
    }
    private string GetTargetObjectTag()
    {
        return targetObject.tag;
    }
    private void Targeting()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            targetObject = hit.collider.gameObject;
            targetPosition = hit.point;
        }
        else
        {
            Untargeting();
        }
    }
    private void Untargeting()
    {
        targetObject = null;
        targetPosition = Vector3.zero;
    }
    private float DistanceFromTargetObject()
    {
        return Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(targetPosition.x, 0, targetPosition.z));
    }
}
