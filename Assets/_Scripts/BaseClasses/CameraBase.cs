using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase : MonoBehaviour
{
    public GameObject Player;
    private float SpeedDown;
    private bool isCameraMove;
    private void Start()
    {
        isCameraMove = false;
        SpeedDown = 0;
    }
    private void Update()
    {
        if (isCameraMove)
        {
            SpeedDown = Settings.SpeedDown;
            Vector3 pos = transform.position;
            float yy = pos.y - (SpeedDown * Time.timeScale * Time.deltaTime);
            transform.position = new Vector3(pos.x, yy, pos.z);
        }
    }

    public void Hold()
    {
        isCameraMove = false;
        SpeedDown = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish")
        {
            Hold();
        }
    }
    public void MoveDown()
    {
        isCameraMove = true;
    }
    public void ResetPosition()
    {
        Hold();
        Invoke("SetZeroPosition", 1);
    }
    private void SetZeroPosition()
    {
      //  transform.position = new Vector3(0, 0, -10);
    }
    public void SetStartPosition(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, pos.y, -10f);
    }
    public void SetFieldOfView(int columns)
    {
        GetComponent<Camera>().orthographicSize = CameraFieldOfView.GetFieldOfView(columns);
    }
}
