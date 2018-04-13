using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Обычная взрывчатка
public class TNTBLock : BlockBase
{ 
    public override void Hit()
    {
        List<Vector2> blocks = new List<Vector2>();
        for(int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) Debug.Log("TnT BLOCK");
                else blocks.Add(new Vector2(Pos.x + i, Pos.y + j));
            }
        }

        base.Hit();
        Debug.Log("START HIT BLOCKS");
        BlockController.instance.DestroyBlock(Pos);
        foreach (var item in blocks)
        {
           BlockController.instance.HitBlock(item);
        }
        Debug.Log("DESTROY MY BLOCK");
     
    }

}
