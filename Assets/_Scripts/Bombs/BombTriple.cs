using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTriple : BombBase
{
    public override void Explosion(GameObject go = null)
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        AnimExplosion();
        isExpl = true;
        Vector3 p = transform.position;
        if (gameObject.transform.childCount>2)
        {
            GameObject[] g = new GameObject[]{
            gameObject.transform.GetChild(0).gameObject
            , gameObject.transform.GetChild(1).gameObject
            , gameObject.transform.GetChild(2).gameObject };
            foreach (GameObject op in g)
            {
                op.transform.parent = null;
                op.SetActive(true);
            }
        }

        Destroy(gameObject, 0.5f);
        CheckAfterExplosionGameState();
    }
    public override void Destroy()
    { 
        Explosion();
    }
}
