using System;
using System.Collections;
using UnityEngine;

public class BomdYellow : BombBase
{
    //
    [SerializeField] private GameObject m_Expl_prefab;
    private int m_CountJump = 3;
    private GameObject m_Expl_instance;
    private float m_RadiusExplosion = 2f;

    public override void Explosion(GameObject go = null)
    {
        //фикс от повторного взрыва при начале отскока
        if (GetComponent<Rigidbody2D>().velocity.y > 0) return;
        AnimExplosion();
        Collider2D[] destr = Physics2D.OverlapCircleAll(transform.position, m_RadiusExplosion);
        float minDir = 10, curDir;
        GameObject biger = null;
        foreach (var op in destr)
        {
            if (op)
                if (op.tag == "Box")
                {
                    curDir = Vector2.Distance(transform.position, op.transform.position);
                    if (minDir > curDir)
                    {
                        minDir = curDir;
                        biger = op.gameObject;
                    }
                }
        }
        if (biger) Destroy(biger, Time.deltaTime);
        if (m_CountJump <= 1)
        {
            isExpl = true;
            Destroy(gameObject, 0.5f);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }else
        {
            print("AddForce");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * Settings.BombJumpForce, ForceMode2D.Impulse);
            m_CountJump--;
        }
        CheckAfterExplosionGameState();
    }
    public override void AnimExplosion()
    {
        m_Expl_instance = Instantiate(m_Expl_prefab);
        m_Expl_instance.transform.position = transform.position;
    }
}
