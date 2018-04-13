using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : BlockBase {

    [SerializeField] private float m_ghostTime;

    private int m_hitCount = 0;

    public override void Hit()
    {
        base.Hit();
        if (m_hitCount == 0) StartCoroutine(StartGhost());
        else DestroyCustom();
    }

    private IEnumerator StartGhost()
    {
        InterractBlock(false);
        yield return new WaitForSeconds(m_ghostTime);
        InterractBlock(true);
        m_hitCount++;
    }

    private void InterractBlock(bool isActive)
    {
        GetComponent<Collider2D>().enabled = isActive;
        GetComponent<SpriteRenderer>().enabled = isActive;
    }
    public void DestroyCustom()
    {
        BlockController.instance.DestroyBlock(Pos);
    }
}
