using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAnimation : MonoBehaviour {

    [SerializeField] private SpriteRenderer m_gun;

    private void Update()
    {
        Aim();
    }
    private void Aim()
    {
        Vector3 dir = Player.instance.transform.position - m_gun.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        m_gun.transform.rotation = Quaternion.Euler(0, 0, angle -90);
    }
}
