using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]  private float speedH = 2.0f,speedV = 2.0f;
    private float Mx, My=90;

    void Update()
    {
    
        Mx = Mathf.Min(90, Mathf.Max(-90, Mx - Input.GetAxis("Mouse Y")*speedH));
        My += speedV * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, My, 0.0f);
        this.gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(Mx, My, 0.0f);

        Cursor.visible = false;
    }
}