using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static bool isPause;
    private static float m_TimeScaleRef = 1f;

    public static PlaneBase Player;

    public static void ChangePause()
    {
        if (isPause)
        {
            Time.timeScale = m_TimeScaleRef;
            isPause = false;
        }
        else
        {
            Time.timeScale = 0f;
            isPause = true;
        }
    }
    public static void SetPauseFalse()
    {
        isPause = false;
        Time.timeScale = m_TimeScaleRef;
    }

    public static void Win()
    {
        DlgController.instance.ShowVictoryMenu();
        Player.VictoryAnim();
    }
    public static void Lose()
    {
        DlgController.instance.ShowDefeatMenu();
    }
    public static void CheckWin()
    {
        int box = GameObject.FindGameObjectsWithTag("Box").Count();
        if (box <= 0)
        {
            Settings.SpeedDown = 0.6f;
            //TODO increaseSpeedOfPlane when no boxes;
        }

    }
}
