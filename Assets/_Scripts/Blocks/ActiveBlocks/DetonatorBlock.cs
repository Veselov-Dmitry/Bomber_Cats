using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonatorBlock : BlockBase {

    public override void Hit()
    {
        base.Hit();
        var blocks = BlockController.instance.GetBlocks().FindAll(x => x.GetComponent<TNTBLock>() != null);
        if(blocks.Count > 0)
        {
            blocks[0].Hit();
            if (blocks[1] != null) blocks[1].Hit();
        }
        BlockController.instance.DestroyBlock(Pos);
    }
}
