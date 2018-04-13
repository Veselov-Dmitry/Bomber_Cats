using UnityEngine;

public class BomdGreen : BombBase
{//Destroy after second tap on screen
    private void OnEnable()
    {
        BombController.OnChangeActiveBomb += Destroy;
    }
    private void OnDisable()
    {
        BombController.OnChangeActiveBomb -= Destroy;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        isExpl = false;
    }
    public override void Destroy()
    { 
        Explosion(); AnimExplosion();
        isExpl = true;
    }

    public override void Explosion(GameObject go = null)
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Collider2D[] destr = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach (Collider2D op in destr)
        {
            if (op)
                if (op.tag == "Box")
                    Destroy(op.gameObject, Time.deltaTime);
        }
        Destroy(gameObject, 0.5f);
        CheckAfterExplosionGameState();
    }
    public override void OnTriggerEnter2D(Collider2D col)
    {
       // base.OnTriggerEnter2D(col);
    }
}
