using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** <summary>A script for the pencil prefab.</summary>*/
public class PencilPrefab : MonoBehaviour, IDealsDamage
{
    public float DealDamage { get; set; }

    void Start()
    {
    }

    void FixedUpdate()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 directionToMouse = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        
        //Angles the posiiton and velocity of the prefab
        transform.GetComponent<Rigidbody2D>().transform.up = directionToMouse;
        transform.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}

