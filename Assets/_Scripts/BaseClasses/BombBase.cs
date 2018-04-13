using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBase : MonoBehaviour
{
    public bool isExpl { get; set; }

    public float CoolDown
    {
        get
        {
            return coolDown;
        }
        private set
        {
            coolDown = value;
        }
    }

    [SerializeField] private float coolDown;
    protected Animator anim;
    protected void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        isExpl = false;
    //    Invoke("Explosion",1);
    }
    public virtual void Destroy()
    {/* 
        Explosion();
        anim.enabled = true;
        anim.Play("ExplosionAnimation");
        isExpl = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Collider2D[] destr = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach (Collider2D op in destr)
        {
            if (op)
                if (op.tag == "Box")
                    Destroy(op.gameObject, Time.deltaTime);
        }/**/
       
    }
    protected void CheckAfterExplosionGameState()
    {
        GameController.CheckWin();
    }

    public virtual void Explosion(GameObject go = null)
    {
        //anim.enabled = true;
        //anim.Play("ExplosionAnimation");
        //isExpl = true;
        //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //Collider2D[] destr = Physics2D.OverlapCircleAll(transform.position, 0.6f);

        //if(destr.Length>0)
        //{
        //    if (destr[0])
        //        if (destr[0].tag == "Box")
        //            Destroy(destr[0].gameObject, Time.deltaTime);
        //}        
        //Destroy(gameObject, 0.5f);
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Box"||col.tag == "Finish")
        {
            //TODO вот так вызывать взаимодействие с блоком и разделить попадание на финиш и в бокс
            //col.GetComponent<BlockBase>().Hit();
            Explosion(col.gameObject);
        }
    }
    public virtual void AnimExplosion()
    {
        anim.enabled = true;
        anim.Play("ExplosionAnimation");
    }
}
