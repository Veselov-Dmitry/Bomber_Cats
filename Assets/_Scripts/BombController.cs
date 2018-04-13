using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BombController : MonoBehaviour
{
    public static BombController instance;

    //public delegate void OnChangeBomb();
    public static event Action OnChangeBombsSet;
    public static event Action OnChangeActiveBomb;

    public PlaneBase Plane;
    public GameObject[] Bombs; 
    public int ActiveBombId { get { return id; } }
    public GameObject[] ActiveBombsSet { get; private set; }

    public int FirstBomb { get; private set; }
    public int SecondBomb { get; private set; }
    public int ThirdBomb { get; private set; }

    private GameObject InstanceBomb;
    private CameraBase cam;
    private int id = 0;//BOMB
    private bool isCanSpawnBomb;
    private float m_delay; // задержка перед броском следующей бомбы
                           //TODO Передалть задержку на бомбу
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ActiveBombsSet = new GameObject[3];
        cam = Camera.main.GetComponent<CameraBase>();
        Debug.LogWarning("+++ задать стартовый набор бомб");
        //!!!!!!!!!!! задать стартовый набор
        ChangeActiveBombsSet(0,8,4);
                        
        //!!!!!!!!!!! задать стартовый набор
        //!!!!!!!!!!! задать стартовый набор
    }
   
    public void TapScreen()
    {
        if (!Plane.isFlyPlane)
        {
            Plane.StartFly();
            cam.MoveDown();
        }
        else if (ActiveBombsSet[id].GetComponent<BombTriple>()!=null && InstanceBomb != null)
        {
            DestroyBomb();
        }
        else if (Plane.canDroppingBomb && isCanSpawnBomb && Time.timeScale == 1f)
        {
            CreateBomd();
        }
    }

    public void ChangeActiveBombsSet(int FirstBomb = 0, int SecondBomb = 1, int ThirdBomb = 2)
    {
        if(FirstBomb!= SecondBomb && SecondBomb != ThirdBomb && ThirdBomb!= FirstBomb)
        {
            int len = Bombs.Length - 1;
            this.FirstBomb = FirstBomb;
            this.SecondBomb = SecondBomb;
            this.ThirdBomb = ThirdBomb;
            ActiveBombsSet[0] = Bombs[FirstBomb];
            ActiveBombsSet[1] = Bombs[SecondBomb];
            ActiveBombsSet[2] = Bombs[ThirdBomb];
        }
        if (OnChangeBombsSet != null)
        {
            OnChangeBombsSet();
        }
        SetId(this.FirstBomb);
    }

    public void SetId(int id)
    {
        this.id = id;

        m_delay = Bombs[Mathf.Clamp(id, 0, Bombs.Length - 1)].GetComponent<BombBase>().CoolDown;
        Debug.Log(m_delay);
        // кира сказал что пока нет КД на переключение
        //StartCoroutine(Reload(m_delay));
        isCanSpawnBomb = true;
        if(OnChangeActiveBomb != null)
        {
            OnChangeActiveBomb();
        }
    }

    internal void DestroyBomb()
    {
        if (!InstanceBomb.GetComponent<BombBase>().isExpl)
            InstanceBomb.GetComponent<BombBase>().Destroy();
    }

    public void CreateBomd()
    {
        isCanSpawnBomb = false;
        Vector3 posPlane = Plane.GetComponent<Transform>().position;
        InstanceBomb = Instantiate(ActiveBombsSet[id], posPlane, Quaternion.identity);
        m_delay = ActiveBombsSet[id].GetComponent<BombBase>().CoolDown;
        StartCoroutine(Reload(m_delay)); //TODO REF CallDown
    }

    private IEnumerator Reload(float time)
    {
        m_delay = time;
        EventManager.CallDownTime.SafeInvoke(m_delay, id);
               
        for (; ;)
        {
            yield return new WaitForSeconds(1f);
            m_delay--;
            if (m_delay <= 0)
            {
                isCanSpawnBomb = true;
                break;
            }
        }
    }

    public void Hold()
    {
        Plane.Hold();
        cam.Hold();
    }
}
