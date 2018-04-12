using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupDecider : MonoBehaviour {

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    List<IHoldable> weaponOptions;
    public GameObject pickupWeapon;
    public string Choice { get; set; }

	// Use this for initialization
	void Start () {

        int weaponIndex = Random.Range(0, 4);
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        Debug.Log("Weapon Pickup Choice was: " + weaponIndex);
        switch (weaponIndex)
        {
            case 0:
                // Pencil
                spriteRenderer.sprite = sprites[weaponIndex];
                transform.localScale -= new Vector3(0.25F, 0.25F, 0);
                //spriteRenderer.color = Color.black;
                this.Choice = "Pencil";
                break;
            case 1:
                // Paper
                spriteRenderer.sprite = sprites[weaponIndex];
                transform.localScale -= new Vector3(0.65F, 0.65F, 0);
                // spriteRenderer.color = Color.white;
                this.Choice = "Paper";
                break;
            case 2:
                // Textbook
                spriteRenderer.sprite = sprites[weaponIndex];
                transform.localScale -= new Vector3(0.30F, 0.30F, 0);
                //spriteRenderer.color = Color.blue;
                this.Choice = "Textbook";
                break;
            case 3:
                // Ruler
                spriteRenderer.sprite = sprites[weaponIndex];
                transform.localScale -= new Vector3(0.15F, 0.15F, 0);
                // spriteRenderer.color = Color.red;
                this.Choice = "Ruler";
                break;
        }
        //Creates collider for each pickupWeapon object so that it matches the sprite size, allows it to be triggered on collision
        pickupWeapon.AddComponent<PolygonCollider2D>();
        pickupWeapon.GetComponent<PolygonCollider2D>().isTrigger = true;

    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().MoveRotation(this.GetComponent<Rigidbody2D>().rotation + 1);
	}
}
