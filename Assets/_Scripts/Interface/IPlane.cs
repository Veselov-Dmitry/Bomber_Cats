using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlane
{
    bool isFlyPlane { get; set; }
    bool flyOutPlane { get; set; }
    bool canDroppingBomb { get; set; }


    void StartFly();
    void DropBomb();
    void ResetPosition();
}
