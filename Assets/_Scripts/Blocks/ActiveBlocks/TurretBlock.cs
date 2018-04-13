using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBlock : BlockBase
{
    [SerializeField] private GameObject m_rocketPrefab;
    [SerializeField] private float m_distance;
    [SerializeField] private float m_aimTime;

    private float m_currentAimTime;

    private GameObject player;

    private void Start()
    {
        player = Player.instance.gameObject;
    }


    private void Update()
    {
        if (isCanAim())
        {
            Aim();
        }
        else
        {
            m_currentAimTime = 0;
        }
    }

    private bool isCanAim()
    {
      if(Vector2.Distance(player.transform.position,transform.position) <= m_distance) return true;
        return false;
    }

    private void Aim()
    {
        Debug.Log(m_currentAimTime);
        m_currentAimTime += Time.deltaTime;
        if (m_currentAimTime >= m_aimTime) Shoot();
    }
    private void Shoot()
    {
        Instantiate(m_rocketPrefab, transform.position, Quaternion.identity);
        m_currentAimTime = 0;
        this.enabled = false;
    }

    public override void Hit()
    {
        base.Hit();
        BlockController.instance.DestroyBlock(Pos);
    }
}
