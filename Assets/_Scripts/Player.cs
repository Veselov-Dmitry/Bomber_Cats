using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PlaneBase
{
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
}
