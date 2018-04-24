using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour {
    public GameObject geesenado;
    public GameObject playerObj;

    private Vector2 center;
    private float radius;
    private bool inNado;
    private bool isWalking = true;
    private float moveSpeed = 5;

	// Use this for initialization
	void Start () {
        center = geesenado.GetComponent<Rigidbody2D>().position;
        radius = geesenado.GetComponent<CircleCollider2D>().radius;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isWalking)
        {
           GetComponent<Rigidbody2D>().position = Vector2.MoveTowards(
               GetComponent<Rigidbody2D>().position, 
               center, 
               5 * Time.deltaTime
           );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Geesenado")
        {
            isWalking = false;
            inNado = true;
            moveSpeed *= -1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Geesenado")
        {
            isWalking = true;
            inNado = false;
            moveSpeed *= -1;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Geesenado")
        {
            inNado = true;
        }
    }
}
