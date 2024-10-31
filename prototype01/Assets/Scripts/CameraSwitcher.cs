using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera primaryCamera;
    public CinemachineVirtualCamera secondaryCamera;

    public void CenterOnPlaneteSelected(GameObject objectToLookAt)
    {
        primaryCamera.enabled = false;
        secondaryCamera.enabled = true;
        secondaryCamera.LookAt = objectToLookAt.transform;
        secondaryCamera.Follow = objectToLookAt.transform;
        secondaryCamera.m_Lens.FieldOfView = 8;
        secondaryCamera.m_Lens.Dutch = -35.0f;
    }

    public void CenterOnTheMiddleOfMilkyWay()
    {
        secondaryCamera.enabled = false;
        primaryCamera.enabled = true;
        primaryCamera.LookAt = gameObject.transform;
        primaryCamera.m_Lens.FieldOfView = 20;
    }
}
