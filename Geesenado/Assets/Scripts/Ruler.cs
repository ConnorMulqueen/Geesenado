using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** <summary>An object that handles player ruler.</summary>*/
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
    private bool isForwardSwing = true;
    private int swingCycle = 0;
    private Vector2 anchorLocation;
    private Vector2 conAnchorLocation;

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
        get { return 0.2f; }
        set { if (value != 0.2f) Damage = 0.2f; }
    }

    public float Countdown
    {
        get { return countdown; }
        private set { countdown = value; }
    }

    public float DealDamage { get { return Damage; } set { DealDamage = value;  } }
    
    // Use this for initialization
    void Start () {
        isLive = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        Physics2D.IgnoreCollision(playerBody.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>(), true);

        anchorLocation = this.GetComponent<HingeJoint2D>().anchor;
        conAnchorLocation = this.GetComponent<HingeJoint2D>().connectedAnchor;
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

            // Set wobble back and forth on joint by switching motor direction
            HingeJoint2D rulerJoint = GetComponent<HingeJoint2D>();
            float minAngle = rulerJoint.limits.min;
            float maxAngle = rulerJoint.limits.max;
            float currentAngle = rulerJoint.jointAngle;

            if ((currentAngle > maxAngle && isForwardSwing) || (currentAngle < minAngle && isForwardSwing == false))
            {
                JointMotor2D m = this.GetComponent<HingeJoint2D>().motor;
                m.motorSpeed *= -1;
                this.GetComponent<HingeJoint2D>().motor = m;
                toggleSwing();
            }

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

        this.GetComponent<HingeJoint2D>().connectedAnchor = conAnchorLocation;
        this.GetComponent<HingeJoint2D>().anchor = anchorLocation;

    }

    public void toggleSwing()
    {
        if (isForwardSwing)
            isForwardSwing = false;
        else
            isForwardSwing = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            JointMotor2D m = this.GetComponent<HingeJoint2D>().motor;
            m.motorSpeed *= -1;
            this.GetComponent<HingeJoint2D>().motor = m;
            toggleSwing();
        }
    }
}
