using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DlgPause : DlgAbstract {

    public void ResetLvl()
    {
        SceneController.ResetLvl();
    }

    public void Quit()
    {
        SceneController.Quit();
    }

    public override void OnCloseBtnDown()
    {
        GameController.ChangePause();
        base.OnCloseBtnDown();
    }
}
