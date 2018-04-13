using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRocket : MonoBehaviour {

    [SerializeField] private float m_speed;
	
	// Update is called once per frame
	void Update () {
        float step = m_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.instance.transform.position, step);

        Vector3 dir = Player.instance.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plane")
        {
            GameController.Lose();
        }
    }
}
