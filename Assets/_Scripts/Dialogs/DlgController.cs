using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgController : MonoBehaviour {
    public static DlgController instance;

    [SerializeField] private BombChooser m_dlgBombChoose;
    [SerializeField] private DlgDefeat m_dlgDefeat;
    [SerializeField] private DlgPause m_dlgPause;
    [SerializeField] private DlgVictory m_dlgVictory;
    [SerializeField] private DlgSettings m_dlgSettings;

    private void Awake()
    {
        instance = this;
    }

    public void ShowVictoryMenu()
    {
        m_dlgVictory.OpenDlg();
    }
    public void ShowPauseMenu()
    {
        GameController.ChangePause();
        m_dlgPause.OpenDlg();
    }

    public void ShowDefeatMenu()
    {
        GameController.ChangePause();
        m_dlgDefeat.OpenDlg();
    }
    public void OpenDialogSettings()
    {
        m_dlgSettings.OnOpenBtnDown();
    }
}
