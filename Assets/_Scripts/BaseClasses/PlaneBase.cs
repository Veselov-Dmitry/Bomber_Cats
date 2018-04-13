using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneBase : MonoBehaviour
{
    public Transform StartPosition;

    [HideInInspector] public float SpeedFly;
    [HideInInspector] public float SpeedDown; 
    [HideInInspector] public bool isFlyPlane;
    [HideInInspector] public bool canDroppingBomb;
    [HideInInspector] public enum FlyDirct { FlyForward = 1, FlyBack = -1 };
    [HideInInspector] public FlyDirct dir;

    [SerializeField] private GameObject m_Expl_prefab;
   
    protected Camera cam;
    protected float w, h, deltaY, brownMark,planeX;
    protected int cntFlys = 1;

    private Vector3 pos;
    private Animator anim;

    void Start()
    {
        Init();
    }
    public void Init()
    {
        InitComponents();
        InitStartValues();
        GetScreenSize();
        ResetPosition();
        GameController.SetPauseFalse();
    }

    private void InitComponents()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }
    private void InitStartValues()
    {
        GameController.Player = this; // TODO ref
        anim.enabled = false;
        isFlyPlane = false;
    }

    //TODO Ref
    void Update()
    {
        if (isFlyPlane)
        {
            pos = transform.position;
            transform.position = new Vector2(pos.x + (Settings.SpeedFly * (int)dir * Time.timeScale * Time.deltaTime),
                                             pos.y - (Settings.SpeedDown * Time.timeScale * Time.deltaTime));
            if (pos.x >= w )
            {
                canDroppingBomb = false;
                if (pos.x >= (w + planeX) && dir == FlyDirct.FlyForward)
                {
                    canDroppingBomb = true;
                    //print("FlyBack pos.x=" + pos.x.ToString());
                    dir = FlyDirct.FlyBack;
                    PositionNdFlip();
                }
            }
            else if (pos.x <= -w)
            {
                canDroppingBomb = false;
                if (pos.x <= -(w + planeX) && dir == FlyDirct.FlyBack)
                {
                    canDroppingBomb = true;
                    //print("FlyForward pos.x=" + pos.x.ToString());
                    dir = FlyDirct.FlyForward;
                    PositionNdFlip();
                }
            }
            else canDroppingBomb = true;
        }
    }

    internal void Hold()
    {
        Debug.LogWarning("Plane Hold");
    }

    public void StartFly()
    {
        if (!isFlyPlane)
        {
            dir = FlyDirct.FlyForward;
            canDroppingBomb = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            isFlyPlane = true;
        }
    }

    public void ResetPosition()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        isFlyPlane = false;
        canDroppingBomb = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        transform.position = StartPosition.position;
        transform.rotation = StartPosition.rotation;
    }

    protected void GetScreenSize()
    {
        planeX = GetComponent<Renderer>().bounds.size.x;
        Vector3 v = new Vector3(Screen.width, Screen.height, 0), wv;
        wv = cam.ScreenToWorldPoint(v);
        w = wv.x;
        h = wv.y;
    }

    protected void PositionNdFlip()
    {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
    #region HitsToSomething
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isFlyPlane)
        {
            if (other.tag == "Finish")
            {
                HitGround();
            }
            if (other.tag == "Box")
            {
                HitBox();
            }
        }
    }
    private void HitGround()
    {
        isFlyPlane = false;
        GetComponent<SpriteRenderer>().flipX = true;
        GameController.Win();
    }
    private void HitBox()
    {
        BombController.instance.Hold();
        isFlyPlane = false;
        //какой-то косяк с перемещением взрыва решил взрывать через префаб
        //anim.enabled = true;
        //anim.Play("ExplosionAnimation");
        GameObject expl = Instantiate(m_Expl_prefab);
        expl.transform.position = transform.position;
        GetComponent<SpriteRenderer>().enabled = false;
        this.Invoke(Crash, 0.5f); //Не используй invoke, лучше пользуйся monobehaviour extensions
                                  //  Invoke("Crash", 0.5f);
    }

    #endregion

    private void Crash()
    {
        GameController.Lose();
    }

    public void VictoryAnim()
    {
        //play some animation
        anim.enabled = true;
        anim.Play("VictoryAnimation");
    }
}
