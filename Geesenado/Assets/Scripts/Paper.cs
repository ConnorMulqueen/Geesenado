using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class Paper : MonoBehaviour, IPlayerWeapon
{

    // Bodies
    public Rigidbody2D playerBody;
    public Rigidbody2D paperBody;
    public GameObject paperPrefab;

    private int ammo;
    private int maxAmmo;

    private static float TIMEOUT = 3f;
    private float countdown;

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


    public void Fire(float damagePoints = 0.3f, Constants.DamageType damageType = Constants.DamageType.Static)
    {
        this.Damage = damagePoints;

        if (ammo > 0)
        {
            // Create the paper prefab
            var paper = (GameObject)Instantiate(
                paperPrefab,
                transform.position,
                transform.rotation
            );

            paper.GetComponent<Rigidbody2D>().velocity = transform.up * 8;

            Destroy(paper, .5f);
            this.Ammo--;
        }
        else
        {
            // Need More Ammo
            Debug.Log("Paper- Need More Ammo");
        }
    }

    // Use this for initialization
    void Start()
    {
        maxAmmo = 100;
        ammo = 20;
    }

    void FixedUpdate()
    {
        transform.position = playerBody.position;
    }
}

