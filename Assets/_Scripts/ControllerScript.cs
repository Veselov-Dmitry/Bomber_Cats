using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerScript : MonoBehaviour
{
    public GameObject Plane;
    public GameObject[] Bombs;
    [HideInInspector]
    public GameObject InstanceBomb;
    private Camera cam;
    int id = 0;//BOMB
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Plane.GetComponent<IPlane>().flyOutPlane)
        {
            Plane.GetComponent<IPlane>().ResetPosition();
            cam.GetComponent<ICamera>().ResetPosition();
        }
    }
      
    public void TapScreen()
    {
        if (!Plane.GetComponent<IPlane>().isFlyPlane)
        {
            Plane.GetComponent<IPlane>().StartFly();
        }else if (Plane.GetComponent<IPlane>().canDroppingBomb && InstanceBomb==null)
        {
            CreateBomd();
        }else if(InstanceBomb != null)
        {
            DestroyBomb();
        }
    } 

    internal void DestroyBomb()
    {
        if (!InstanceBomb.GetComponent<IBomb>().isExpl)
        {
            InstanceBomb.GetComponent<IBomb>().Destroy();
        }
    }

    public void CreateBomd()
    {
            Vector3 posPlane = Plane.GetComponent<Transform>().position;
            InstanceBomb = Instantiate(Bombs[id], posPlane, Quaternion.identity);
        
    }
    


    public void Quit()
    {
        Application.Quit();
    }
    public void ShowExitMenu()
    {
        GetComponent<MenuController>().ShowExit(true);
    }
    public void ExitMenuNo()
    {
        GetComponent<MenuController>().ShowExit(false);
    }
}
