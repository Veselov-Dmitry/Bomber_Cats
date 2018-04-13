using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombChooser : MonoBehaviour {

	public void ChooseBomb(int id)
    {
        BombController.instance.SetId(id);
    }

    public void OpenPauseMenu()
    {
        DlgController.instance.ShowPauseMenu();
    }

    public void OpenSettingsMenu()
    {
        DlgController.instance.OpenDialogSettings();
    }
}
