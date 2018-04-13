using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDeathRay : BombBase
{

    private new void Start()
    {
        base.Start();
        Explosion();
    }

    public override void Explosion(GameObject go = null)
    {
        StopAllCoroutines();
        AnimExplosion();
        isExpl = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        RaycastHit2D[] destr = Physics2D.RaycastAll(transform.position, Vector2.down);
        foreach (var op in destr)
        {
            if (op)
                if (op.transform.tag == "Box")
                {
                    Destroy(op.transform.gameObject, Time.deltaTime);
                }
        }
        Destroy(gameObject, 0.5f);
        CheckAfterExplosionGameState();
    }
    public override void AnimExplosion()
    {
        anim.enabled = true;
        anim.Play("DeathRay");
    }
}
