using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isHitToButtons())
                BombController.instance.TapScreen();
        }
    }

    #region RaycastToUI

    [SerializeField] private GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    private bool isHitToButtons()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();
       
        //Raycast using the Graphics Raycaster and mouse click position
        if(m_Raycaster != null) m_Raycaster.Raycast(m_PointerEventData, results);
        int layernm = LayerMask.NameToLayer("UI");
        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            Debug.Log("Hit " + result.gameObject.name);
            if (result.gameObject.layer == layernm)
            {
                Debug.Log("TRUE");
                return true;
            }
        }
    

        return false;
    }

    #endregion
}
