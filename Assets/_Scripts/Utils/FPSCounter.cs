using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    float m_deltaTime = 0.0f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        m_deltaTime += (Time.deltaTime - m_deltaTime) * 0.1f;
    }


    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = Color.yellow;
        float msec = m_deltaTime * 1000.0f;
        float fps = 1.0f / m_deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}