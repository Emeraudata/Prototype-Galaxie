using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; }
    VisualElement m_InfosPlanete;
    public float displayTime = 4.0f;
    float m_TimerDisplay;

    Label m_titre;
    Label m_description;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIDocument document = GetComponent<UIDocument>();
        m_InfosPlanete = document.rootVisualElement.Q<VisualElement>("InfosPlanete");
        m_titre = document.rootVisualElement.Q<Label>("Titre");
        m_description = document.rootVisualElement.Q<Label>("Description");
        m_InfosPlanete.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayInfosPlanete(string nom = "Nom", string description="Une description de l'app")
    {
        m_titre.text = nom;
        m_description.text = description;
        m_InfosPlanete.style.display = DisplayStyle.Flex;
    }

    public void HideInfosPlanete()
    {
        m_InfosPlanete.style.display = DisplayStyle.None;
    }
}
