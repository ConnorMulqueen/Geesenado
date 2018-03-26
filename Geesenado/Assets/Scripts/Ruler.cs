using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : MonoBehaviour, IPlayerWeapon{

    // Game Objects
    public Rigidbody2D playerBody;
    public Rigidbody2D rulerBody;

    // Locals
    private int ammo;
    private int maxAmmo;
    private bool isLive;
    private float countdown;
    private static float TIMEOUT = 1f;
    private float rotateSpeed = 2f;

    public int Ammo
    {
        get { return 1; }
        set { if (value != 1) Ammo = 1; }
    }

    public int MaxAmmo
    {
        get { return 1; }
        set
        {
            // Melee Weapons always have an ammmo value of 1.
            if (value != 1) MaxAmmo = 1;
        }
    }

    public float Damage
    {
        get { return 0.1f; }
        set { if (value != 0.1f) Damage = 0.1f; }
    }

    public float Countdown
    {
        get { return countdown; }
        private set { countdown = value; }
    }

    // Use this for initialization
    void Start () {
        isLive = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        Physics2D.IgnoreCollision(playerBody.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>(), true);
    }

    public void Fire(float damagePoints = 0.1f, Constants.DamageType damageType = Constants.DamageType.Static)
    {
        Debug.Log("Ruler- received Fire() command - JG");
        isLive = true;

        if (countdown <= 0)
        {
            this.Countdown = TIMEOUT;
        }
    }
	
	void FixedUpdate () {
        if(isLive)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;

            this.Countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                // Time's up
                Debug.Log("Ruler- countdown complete");
                isLive = false;
            }
        }
        else
        {
           this.GetComponent<SpriteRenderer>().enabled = false;
           this.GetComponent<BoxCollider2D>().enabled = false;
        }

        // Position of the ruler is set by the hinge joint on the player body
        GetComponent<HingeJoint2D>().connectedAnchor = playerBody.position;

        // Set wobble back and forth on joint by switching motor direction
        float minAngle = GetComponent<HingeJoint2D>().limits.min;
        float maxAngle = GetComponent<HingeJoint2D>().limits.max;
        float currentAngle = GetComponent<HingeJoint2D>().jointAngle;
        Debug.Log("joint angle: " + currentAngle);
        if (currentAngle > maxAngle || currentAngle < minAngle)
        {
            float oldSpeed = this.GetComponent<JointMotor2D>().motorSpeed;
            float newSpeed = oldSpeed * -1;
            JointMotor2D m = this.GetComponent<JointMotor2D>();
            m.motorSpeed = newSpeed;
        }


    }
}
