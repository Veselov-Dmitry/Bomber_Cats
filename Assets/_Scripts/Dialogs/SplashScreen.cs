using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public static SplashScreen instance;

    Image m_splashScreen;
    Canvas m_canvas;
    Transform m_mainParent;

    public Image Screen
    {
        get
        {
            if (m_splashScreen == null) m_splashScreen = GetComponent<Image>();
            return m_splashScreen;
        }
    }


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }


    void OnEnable()
    {
        m_canvas = GetComponent<Canvas>();
        m_mainParent = transform.parent;
    }


    public void ShadowOn()
    {
        Screen.enabled = true;
    }


    public void ShadowOff()
    {
        Screen.enabled = false;
    }


    public void ReverseParent()
    {
        transform.SetParent(m_mainParent);
    }


    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }


    public void SetOvverideSorting(bool state)
    {
        m_canvas.overrideSorting = state;
    }
}
