using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilPrefab : MonoBehaviour
{
    public Rigidbody2D player;

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

        transform.Translate((player.transform.position - transform.position).normalized * 5 * Time.deltaTime);
        transform.up = directionToMouse;
    }
}

