using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedFlyValue : MonoBehaviour {

    public Slider sl;
    private Text txt;
	void Start () {
        if (!sl)
        {
            print("Set public element Slider value");
        }
            txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        txt.text =(sl)? sl.value.ToString("#0.###"):"err.";
	}
}
