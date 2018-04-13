using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
public abstract class DlgAbstract : MonoBehaviour
{
    [Header("DlgAbstract fields:")]
    [SerializeField] protected Button m_closeButton;

    public static bool IsAnyDlgOpen { get; protected set; }
    public bool IsOpened { get; protected set; }
    public Animator Animator { get; protected set; }
    public Button CloseBtn { get { return m_closeButton; } }

    protected Animator m_animator;
    protected static List<DlgAbstract> m_activeScreens = new List<DlgAbstract>();
    private DlgAbstract m_previousDlg;
    protected Canvas m_canvas;

    public static Action<DlgAbstract> DlgWasOpenedEvent;
    public static Action<DlgAbstract> DlgWasClosedEvent;
	public static Action AllDlgsWereClosed;

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        m_canvas = GetComponent<Canvas>();
		m_canvas.enabled = false;
       // gameObject.SetActive(false);
    }
    private void Start()
    {
        
    }

    protected virtual void OnDestroy()
    {
        if (IsOpened) CloseDlg();
    }

    virtual public void OpenDlg()
    {
		gameObject.SetActive (true);
        m_canvas.enabled = true;

        if (SplashScreen.instance != null)
        {
            SplashScreen.instance.ShadowOn();
            if(m_activeScreens.Count > 0)
            {
                SplashScreen.instance.SetParent(m_activeScreens[m_activeScreens.Count - 1].transform);
                SplashScreen.instance.SetOvverideSorting(false);
            }
        }

        IsOpened = true;
        IsAnyDlgOpen = true;
        Animator.SetTrigger("Open");
        m_activeScreens.Add(this);

    }

    virtual public void CloseDlg()
    {
        m_canvas.enabled = false;
        if (SplashScreen.instance != null)
        {
            if(m_activeScreens.Count > 2)
            {
                SplashScreen.instance.SetParent(m_activeScreens[m_activeScreens.Count - 3].transform);
                SplashScreen.instance.SetOvverideSorting(false);
            }
            else if (m_activeScreens.Count > 1)
            {
                SplashScreen.instance.ReverseParent();
                SplashScreen.instance.SetOvverideSorting(true);
            }
            else if(m_activeScreens.Count == 1)
            {
                SplashScreen.instance.ShadowOff();
            }
        }

        m_activeScreens.Remove(this);

        DisableDlg();

        DlgWasClosedEvent.SafeInvoke(this);

        if (m_activeScreens.Count == 0)
        {
            IsAnyDlgOpen = false;
	    AllDlgsWereClosed.SafeInvoke();
        }
    }


    public static void CloseAllScreens()
    {
        while(m_activeScreens.Count > 0) m_activeScreens[0].CloseDlg();
        m_activeScreens.Clear();
    }

    public static void CloseLastDlg()
    {
        if (m_activeScreens.Count > 0) m_activeScreens.Last().CloseDlg();
    } 


    void DisableDlg()
    {
        gameObject.SetActive(false);
        IsOpened = false;
    }

    //Will called from animation
    public void DlgHasBeenOpened()
    {
        DlgWasOpenedEvent.SafeInvoke(this);
    }

    protected void OpenPreviousDlg()
    {
        if (m_previousDlg != null) m_previousDlg.OpenDlg();
    }

    protected void StorePreviousDlg()
    {
        m_previousDlg = m_activeScreens.LastOrDefault();
    }

    public virtual void OnCloseBtnDown()
    {
        CloseDlg();
    }

    public virtual void OnOpenBtnDown()
    {
        OpenDlg();
    }
}
