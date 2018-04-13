using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeesenadoScript : MonoBehaviour {
    private CircleCollider2D geesenadoCirc;
    public GameObject gooseObj;
	// Use this for initialization
	void Start () {
        geesenadoCirc = gameObject.AddComponent<CircleCollider2D>();
        System.Random rnd = new System.Random();
        float offsetX = rnd.Next(220, 265);
        float offsetY = rnd.Next(5, 99);
        geesenadoCirc.offset = new Vector2(offsetX, offsetY);
        geesenadoCirc.radius = 160.0f;
        //geesenadoCirc.offset = new Vector2(-45f, 3f);
        geesenadoCirc.isTrigger = true;
        /*Debug.Log("STORM IS FORMED");
        Debug.Log("Offset X is:" + offsetX);
        Debug.Log("Offset Y is:" + offsetY);*/

        for(int i=0; i <30; i++)
        {
            var goose = (GameObject)Instantiate(gooseObj);
            goose.transform.position = new Vector2(Random.Range(0, 100) + geesenadoCirc.offset.x, Random.Range(0, 100) + geesenadoCirc.offset.y);
            goose.GetComponent<Goose>().geesenado = this.gameObject;
            goose.GetComponent<DistanceJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
            goose.GetComponent<DistanceJoint2D>().connectedAnchor = geesenadoCirc.offset;
            goose.GetComponent<DistanceJoint2D>().distance = geesenadoCirc.radius;
        }

        
	}
	
	// Update is called once per frame
	void Update () {
        geesenadoCirc.radius = geesenadoCirc.radius - (1.5f * Time.deltaTime);
        //Debug.Log("Storm is shrinking");
	}
}
