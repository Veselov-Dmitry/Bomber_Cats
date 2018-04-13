using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUsual : BombBase
{

    public enum BombAnim { none,Triple_0,Triple_1,Triple_2}
    [SerializeField] private BombAnim m_startAnimation;
    private void Reset()
    {
        m_startAnimation = BombAnim.none;
    }
    private new void Start()
    {
        base.Start();
        switch (m_startAnimation)
        {
            case BombAnim.Triple_0:
                {

                    anim.enabled = true;
                    anim.Play("Triple_0Anim");
                    break;
                }
            case BombAnim.Triple_1:
                {

                    anim.enabled = true;
                    anim.Play("Triple_1Anim");
                    break;
                }
            case BombAnim.Triple_2:
                {

                    anim.enabled = true;
                    anim.Play("Triple_2Anim");
                    break;
                }
            default: { break; }
        }
    }
    public override void Explosion(GameObject go = null)
    {
        AnimExplosion();
        isExpl = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //Collider2D[] destr = Physics2D.OverlapCircleAll(transform.position, 1);
        //if(destr.Length>0)
        //{
        //    float minDir = Vector2.Distance(transform.position, destr[0].transform.position), curDir;
        //    GameObject biger = destr[0].gameObject;
        //    foreach (var op in destr)
        //    {
        //        if (op)
        //            if (op.tag == "Box")
        //            {
        //                curDir = Vector2.Distance(transform.position, op.transform.position);
        //                if (minDir > curDir)
        //                {
        //                    biger = op.gameObject;
        //                }
        //            }
        //    }
        //    if (biger) { print(biger.gameObject.name); Destroy(biger, 0.3f); }
        //}
        if (go)
        { print(go.gameObject.name); Destroy(go, Time.deltaTime); }
            Destroy(gameObject, 0.5f);
        CheckAfterExplosionGameState();
    }

}
