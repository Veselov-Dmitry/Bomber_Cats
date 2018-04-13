using UnityEngine;

public class BomdBlack : BombBase
{//Simple bomb
    public override void Explosion(GameObject go = null)
    {
        AnimExplosion();
        isExpl = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Collider2D[] destr = Physics2D.OverlapCircleAll(transform.position, 1);
        float minDir = 10,curDir;
        GameObject biger = null;
        foreach (var op in destr)
        {
            if (op)
                if (op.tag == "Box")
                {
                    curDir = Vector2.Distance(transform.position, op.transform.position);
                    if(minDir > curDir)
                    {
                        biger = op.gameObject;
                    }
                }
        }
        if(biger) Destroy(biger, Time.deltaTime);
        Destroy(gameObject, 0.5f);
        CheckAfterExplosionGameState();
    }

}
