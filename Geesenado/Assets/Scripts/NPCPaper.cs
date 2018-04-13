using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/** <summary>An object that handles and spawns the NPC paper prefab.</summary>*/
public class NPCPaper : MonoBehaviour, INPCWeapon {

    public GameObject npcObject;
    public Rigidbody2D npcPaperBody;
    public GameObject npcPaperPrefab;


    private int ammo;
    private int maxAmmo;
    private int MAX_FIREPOWER = 10;

    // The IWeapon class has descriptions for the following properties
    public int Ammo
    {
        get { return ammo; }

        set
        {
            if (value > this.maxAmmo) ammo = maxAmmo;
            else ammo = value;
        }
    }

    public int MaxAmmo
    {
        get { return this.maxAmmo; }
        set { if (value > 10) MaxAmmo = 10; }
    }

    public float Damage
    {
        get { return 0.3f; }
        set { if (value > 0.3f) Damage = 0.3f; }
    }

    /**
     * <summary>Unused</summary>
     */
    public float DealDamage { get; set; }

    // Use this for initialization
    void Start () {
        maxAmmo = 100;
        ammo = maxAmmo;
        Physics2D.IgnoreCollision(npcObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
    }

    public void Fire(float damagePoints = 0.1f, Constants.DamageType damageType = Constants.DamageType.Static)
    {
        // Call the overloaded Fire function
        Fire(damagePoints, damageType, new Vector2());
    }

    /**
     * <summary>Fires Paper object in the direction of that the character is facing</summary>
     */
    public void Fire(
        float damagePoints = 0.1f,
        Constants.DamageType damageType = Constants.DamageType.Static,
        Vector2 fireToPoint = new Vector2()
    )
    {
        if (ammo > 0)
        {
            // Create the paper prefab
            var paper = (GameObject)Instantiate(
                npcPaperPrefab,
                transform.position,
                transform.rotation
            );

            Physics2D.IgnoreCollision(npcObject.GetComponent<BoxCollider2D>(), paper.GetComponent<CircleCollider2D>());

            // Determine the velocity the paper is fired at
            paper.GetComponent<Rigidbody2D>().velocity = npcObject.GetComponent<Rigidbody2D>().transform.right * MAX_FIREPOWER +
                    new Vector3(npcObject.GetComponent<Rigidbody2D>().velocity.x, npcObject.GetComponent<Rigidbody2D>().velocity.y);

            // Set damage the prefab will deal
            paper.GetComponent<PaperPrefabDamage>().DealDamage = Damage;

            // Set the lifetime of the paper prefab
            Destroy(paper, .75f);
            this.Ammo--;
        }

    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.position = npcObject.GetComponent<Rigidbody2D>().position;
    }
}
