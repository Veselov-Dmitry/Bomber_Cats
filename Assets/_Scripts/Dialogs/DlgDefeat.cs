using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgDefeat : DlgAbstract {

    public void ResetLvl()
    {
        SceneController.ResetLvl();
    }

    public void Quit()
    {
        SceneController.Quit();
    }
}
