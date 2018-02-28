using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    // Scene Objects
    public Rigidbody2D cursorBody;
    public Rigidbody2D playerBody;

    // Class Objects
    float weaponFireDistance = 7.3f; // Default is paper shot length

    // Use this for initialization
    void Start () {
        cursorBody.position = playerBody.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 vectorFromPlayer = cursorBody.position - playerBody.position;
        Vector2 vectorFromMouse = cursorBody.position - mousePosition;

        float distanceFromPlayer = vectorFromPlayer.magnitude;

        if (distanceFromPlayer >= 7.3f)
        {
            cursorBody.transform.position = 
                new Vector2((playerBody.position.x + 7.3f)  , (playerBody.position.y + 7.3f));
        }
        else
        {
            cursorBody.transform.position = mousePosition;
        }
    }
}
