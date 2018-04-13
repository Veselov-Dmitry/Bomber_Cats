using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinsBlock : BlockBase {

    public override void Hit()
    {
        DestroyCopy();
        base.Hit();
    }
    private void DestroyCopy()
    {
        var twinsBlocks = BlockController.instance.GetBlocks().FindAll(x => x.GetComponent<TwinsBlock>() != null);

        if(twinsBlocks.Count >=2) twinsBlocks.Find(x => x != this).GetComponent<TwinsBlock>().Kill();
        Kill();
    }
    public void Kill()
    {
        BlockController.instance.DestroyBlock(Pos);
    }
}
