using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**<summary>This handles the location of the reticle in the scene</summary> */ 
public class Reticle : MonoBehaviour {

    // Scene Objects
    public Rigidbody2D reticleBody;
    public Rigidbody2D playerBody;

    // Class Objects
    public float weaponFireDistance = 7.3f; // Default is paper shot length

    // Use this for initialization
    void Start()
    {
        this.GetComponent<DistanceJoint2D>().distance = weaponFireDistance;
        reticleBody.position = playerBody.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float distanceFromPlayer = (playerBody.position - mousePosition).magnitude;

        if(distanceFromPlayer >= weaponFireDistance)
        {
            // Enable Fixed Joint, set velocity toward mouse
            this.GetComponent<DistanceJoint2D>().enabled = true;
            Vector2 directionToMouse = new Vector2( mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            reticleBody.velocity = directionToMouse * 10;
        }
        else
        {
            this.GetComponent<DistanceJoint2D>().enabled = false;
            reticleBody.transform.position = mousePosition;
            reticleBody.velocity = new Vector2(0, 0);
        }
    }
}
