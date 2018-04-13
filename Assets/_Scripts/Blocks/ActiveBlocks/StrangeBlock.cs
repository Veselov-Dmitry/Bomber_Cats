using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class StrangeBlock : BlockBase {

    [SerializeField] private List<GameObject> m_availableTransformBlocks = new List<GameObject>();

    public override void Hit()
    {
        base.Hit();
        Debug.Log("Hit");
        BlockController.instance.DestroyBlock(Pos);
        SpawnBlock();  
    }
    private void SpawnBlock()
    {
        var obj = Instantiate(m_availableTransformBlocks.GetRandomOrDefault(), transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<BlockBase>().Pos = Pos;
        BlockController.instance.GetBlocks().Remove(this);
        BlockController.instance.GetBlocks().Add(obj.GetComponent<BlockBase>());
        
    }
}
