using UnityEngine;

public class BomdRed : BombBase
{//Destroy all Box in range 2
    public override void Explosion(GameObject go = null)
    {
        AnimExplosion();
        isExpl = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Collider2D[] destr = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach (var op in destr)
        {
            if (op)
                if (op.tag == "Box")
                    Destroy(op.gameObject, Time.deltaTime);
        }
        Destroy(gameObject, 0.5f);
        CheckAfterExplosionGameState();
    }
}
