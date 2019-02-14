using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementController : MonoBehaviour
{

    private string tag;
    private bool auto;
    private GameObject platform;
    private float posY, posX;
    [SerializeField] private string Go;
    [SerializeField] private float distance;
    [SerializeField] private int speed;
    Vector3 scale;
    private void Start()
    {
        platform = transform.parent.gameObject;
        scale = platform.transform.localScale;
        auto = false;tag = "UpDown";
        posY = Mathf.Round(platform.transform.position.y);
        posX = Mathf.Round(platform.transform.position.x);
        distance = Mathf.Round(Mathf.Max(Random.Range(5f, 30f)));
        speed = 2;


    }


    private void OnTriggerExit(Collider col) {   auto = true; }

    private void OnTriggerStay(Collider col)
    {

        switch (Go)
        {
            case "UP": platform.transform.Translate(Vector3.up * Time.deltaTime * speed); col.transform.Translate(Vector3.up * Time.deltaTime * speed); break;
            case "DOWN": platform.transform.Translate(Vector3.down * Time.deltaTime * speed); col.transform.Translate(Vector3.down * Time.deltaTime * speed); break;

        }

        auto = false;
        scale.x -= Time.deltaTime / 2; scale.z -= Time.deltaTime / 2; platform.transform.localScale = scale;
    }

    private void Update()
    {
        moveTo();
        if (auto) { Run(); }
        if (platform.transform.localScale.x <= 0.5f) { Destroy(platform); }
    }

    void Run() { 
        switch (Go)
        {
            case "UP": platform.transform.Translate(Vector3.up * Time.deltaTime * speed); break;
            case "DOWN": platform.transform.Translate(Vector3.down * Time.deltaTime * speed); break;
        }
    }

    void moveTo()
    {

        switch (tag)
        {
            case "UpDown":
                if (Mathf.Round(platform.transform.position.y) == posY) { Go = "UP"; }
                if (Mathf.Round(platform.transform.position.y) == (posY + distance)) { Go = "DOWN"; }
                break;
        }
    }
}



