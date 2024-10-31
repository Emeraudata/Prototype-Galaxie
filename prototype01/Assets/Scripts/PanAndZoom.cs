using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PanAndZoom : MonoBehaviour
{
    [SerializeField]
    private float panSpeed = 5.0f;
    [SerializeField]
    private float zoomSpeed = 5f;
    [SerializeField]
    private float zoomInMax = 20f;
    [SerializeField]
    private float zoomOutMax = 70f;

    private CinemachineInputProvider inputProvider;
    private CinemachineVirtualCamera virtualCamera;
    private Transform cameraTransform;

    public float fireRate = 0.25f;
    public float mouseRange = 100f;
    public Transform focalPoint;
    private float nextFire;

    public InputAction FireAction;

    private MeshRenderer lastSelected;
    private Color originalSelectd;
    private Color selectedColor;

    private GameObject planetePreviouslySelected;

    private void Awake()
    {
        inputProvider = GetComponent<CinemachineInputProvider>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cameraTransform = virtualCamera.VirtualCameraGameObject.transform;
        FireAction.Enable();
        FireAction.performed += FireMotherFucker;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = inputProvider.GetAxisValue(0);
        float y = inputProvider.GetAxisValue(1);
        float z = inputProvider.GetAxisValue(2);

        if (x != 0 || y != 0)
        {
            PanScreen(x, y);
        }
        if (z != 0)
        {
            ZoomScreen(z);
        }
    }

    public void ZoomScreen(float increment)
    {
        float fov = virtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);
    }

    public Vector2 PanDirection(float x, float y)
    {
        Vector2 direction = Vector2.zero;
        if (y >= Screen.height * 0.95f)
        {
            direction.y += 10;
        }
        if (y <= Screen.height * 0.05f)
        {
            direction.y -= 10;
        }
        if (x >= Screen.width * 0.95f)
        {
            direction.x += 10;
        }
        if (x <= Screen.width * 0.05f)
        {
            direction.x -= 10;
        }
        return direction;
    }

    public void PanScreen(float x, float y)
    {
        Vector2 direction = PanDirection(x, y);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraTransform.position + (Vector3)direction * panSpeed, Time.deltaTime);
    }

    public void FireMotherFucker(InputAction.CallbackContext context)
    {
        //Debug.Log("On ouvre le feu, bande de bâtards de vos morts !!");
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out raycastHit, 1000f))
        {
            Debug.Log("Touché, motherfuckerbitchasshole !");
            if (raycastHit.collider != null && raycastHit.collider.tag == "Planete")
            {
                GameObject planete = raycastHit.transform.gameObject;
                if(planetePreviouslySelected != null)
                {
                    if (planete != planetePreviouslySelected)
                    {
                        planetePreviouslySelected.GetComponent<Planet>().DeselectPlanete();
                        Planet planeteClass = planete.GetComponent<Planet>();
                        planeteClass.PlaneteSelected();
                        planetePreviouslySelected = planete;
                    }
                } else
                {
                    Planet planeteClass = planete.GetComponent<Planet>();
                    planeteClass.PlaneteSelected();
                    planetePreviouslySelected = planete;
                }
            }
        }
        else
        {
            Debug.Log("Caramba, encore raté !");
            planetePreviouslySelected.GetComponent<Planet>().DeselectPlanete();
        }
    }
}
