using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgVictory : DlgAbstract {

    public void ResetLvl()
    {
        SceneController.ResetLvl();
    }

    public void Quit()
    {
        SceneController.Quit();
    }
}
