using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupDecider : MonoBehaviour {

    public SpriteRenderer spriteRenderer;

    List<IHoldable> weaponOptions;
    public string Choice { get; set; }

	// Use this for initialization
	void Start () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //this.GetComponent<Rigidbody2D>().MoveRotation(this.GetComponent<Rigidbody2D>().rotation + 1);
	}

    public Sprite Sprite
    {
        set
        {
            GetComponent<SpriteRenderer>().sprite = value;
        }
    }
}
