using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeesenadoScript : MonoBehaviour {
    private CircleCollider2D geesenadoCirc;
    public GameObject gooseObj;
	// Use this for initialization
	void Start () {
        float offsetX = Random.Range(30, 250);
        float offsetY = Random.Range(5, 70);
        GetComponent<Rigidbody2D>().position = new Vector2(offsetX, offsetY);
        geesenadoCirc = gameObject.AddComponent<CircleCollider2D>();
        geesenadoCirc.radius = 160.0f;
        //geesenadoCirc.offset = new Vector2(-45f, 3f);
        geesenadoCirc.isTrigger = true;
        /*Debug.Log("STORM IS FORMED");
        Debug.Log("Offset X is:" + offsetX);
        Debug.Log("Offset Y is:" + offsetY);*/

        for(int i=0; i <100; i++)
        {
            var goose = (GameObject)Instantiate(gooseObj);
            goose.GetComponent<Goose>().geesenado = this.gameObject;
            Vector2 center = GetComponent<Rigidbody2D>().position;
            float radius = geesenadoCirc.radius;
            float angle = Random.value * 360;
            goose.transform.position = center + Vector2.right * radius * Mathf.Cos(angle) + Vector2.up * radius * Mathf.Sin(angle);
        }

        
	}
	
	// Update is called once per frame
	void Update () {
        geesenadoCirc.radius = geesenadoCirc.radius - (1.5f * Time.deltaTime);
        //Debug.Log("Storm is shrinking");
	}

    private float PosNeg
    {
        get
        {
            if (Random.value > .5)
                return 1;
            else
                return -1;
        }
    }
}
