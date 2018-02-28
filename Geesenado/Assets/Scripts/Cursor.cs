using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    // Scene Objects
    public Rigidbody2D cursorBody;
    public Rigidbody2D playerBody;

    // Class Objects

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 vectorFromPlayer = cursorBody.position - playerBody.position;
        float distanceFromPlayer = vectorFromPlayer.magnitude;
        cursorBody.position = new Vector2(mousePosition.x - playerBody.position.x, mousePosition.y - playerBody.position.y);

    }
}
