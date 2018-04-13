using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject ExitMenu;

	void Start ()
    {
		
	}
	
	void Update ()
    {

    }
    public void ShowExit(bool isShow)
    {
        if (isShow)
        {
            ExitMenu.gameObject.SetActive(true);
        }
        else
        {
            ExitMenu.gameObject.SetActive(false);

        }
    }
}
