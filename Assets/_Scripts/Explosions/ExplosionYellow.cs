using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionYellow : ExplosionBase
{

    void Start()
    {
        Destroy();
    }

    public override void Destroy()
    {
        Destroy(gameObject, 0.5f);
    }
}
