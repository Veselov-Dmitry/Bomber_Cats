using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBomb
{
    bool isExpl { get; set; }
    void Destroy();

    void Explosion();
}
