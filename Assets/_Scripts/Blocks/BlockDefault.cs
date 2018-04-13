using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDefault : BlockBase {

    public override void Hit()
    {
        base.Hit();
        BlockController.instance.DestroyBlock(Pos);
    }
}
