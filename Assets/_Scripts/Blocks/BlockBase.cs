using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour {

    public Vector2 Pos;

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void Hit()
    {
       
    }
}
