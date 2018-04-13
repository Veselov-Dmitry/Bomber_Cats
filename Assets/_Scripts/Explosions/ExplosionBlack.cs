using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBlack : MonoBehaviour, IExplosion
{

    void Start()
    {
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
