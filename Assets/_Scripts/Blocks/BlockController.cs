using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public static BlockController instance;

    private BlockSpawner m_blockSpawner;

    private void Awake()
    {
        instance = this;
        m_blockSpawner = GetComponent<BlockSpawner>();
    }

    public void DestroyBlock(Vector2 pos)
    {
        var block = m_blockSpawner.Blocks.Find(x => x.Pos == pos);

        if (block)
        {
            m_blockSpawner.Blocks.Remove(block);
            block.Destroy();
        }
    }

    public void HitBlock(Vector2 pos)
    {
        var block = m_blockSpawner.Blocks.Find(x => x.Pos == pos);
        if (block)
        {
            block.Hit();
        }
    }
    public bool isPosClear(Vector2 pos)
    {
        var block = m_blockSpawner.Blocks.Find(x => x.Pos == pos);
        if (block) return true;
        return false;
    }
    public List<BlockBase> GetBlocks()
    {
        return m_blockSpawner.Blocks;
    }
}
