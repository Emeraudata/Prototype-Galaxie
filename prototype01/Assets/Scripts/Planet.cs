using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public bool isSelected;
    public GameObject circleSelect;
    public string Nom;
    public List<GameObject> planetes;
    public string Description;
    public Material originalMaterial;

    public Material couleurLaser;

    private ParticleSystem circleParticles;

    private void Awake()
    {
        Vector3 originePlanete = gameObject.transform.position;
        planetes.ForEach((planete) =>
        {
            var child = new GameObject();            
            child.AddComponent<LineRenderer>();
            LineRenderer laserPlanete = child.GetComponent<LineRenderer>();
            laserPlanete.enabled = true;
            laserPlanete.material = couleurLaser;
            laserPlanete.SetPosition(0, originePlanete);
            laserPlanete.SetPosition(1, planete.transform.position);
            laserPlanete.startWidth = 0.1f;
            laserPlanete.endWidth = 0.1f;
            child.transform.parent = gameObject.transform;
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        if(circleSelect != null)
        {
            circleParticles = circleSelect.GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotationOfPlanet();
    }

    public void RotationOfPlanet()
    {
        transform.Rotate(0, 0.5f, 0, Space.Self);
    }

    public void PlaneteSelected()
    {
        isSelected = true;
        CameraSwitcher focalPoint = GameObject.Find("FocalPoint").GetComponent<CameraSwitcher>();
        focalPoint.CenterOnPlaneteSelected(gameObject);
        circleParticles.Play();
        UIHandler.instance.DisplayInfosPlanete(Nom, Description);
    }

    public void DeselectPlanete()
    {
        isSelected = false;
        CameraSwitcher focalPoint = GameObject.Find("FocalPoint").GetComponent<CameraSwitcher>();
        focalPoint.CenterOnTheMiddleOfMilkyWay();
        circleParticles.Stop();
        circleParticles.Clear();
        MeshRenderer meshrRenderer = GetComponent<MeshRenderer>();
        meshrRenderer.material = originalMaterial;
        UIHandler.instance.HideInfosPlanete();
    }
}
