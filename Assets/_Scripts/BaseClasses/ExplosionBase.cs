using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionBase : MonoBehaviour
{
    
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

}
