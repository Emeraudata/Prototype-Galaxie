using UnityEngine;

public class RenderingLine : MonoBehaviour
{
    LineRenderer laserLine;
    public GameObject planeteTarget;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        if (planeteTarget != null)
        {
            RenderLaserLine();
        }
    }

    public void RenderLaserLine()
    {
        laserLine.enabled = true;
        Vector3 rayOrigin = transform.position;
        laserLine.SetPosition(0, rayOrigin);
        laserLine.SetPosition(1, planeteTarget.transform.position);

    }
}
