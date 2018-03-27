using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilPrefab : MonoBehaviour
{
    public float Damage;

    void Start()
    {
        Debug.Log("Hello");
    }

    void FixedUpdate()
    {
        Debug.Log("Prefab Runnin");
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 directionToMouse = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        
        //transform.up = directionToMouse;
        transform.GetComponent<Rigidbody2D>().transform.up = directionToMouse;
        transform.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
    }
}

