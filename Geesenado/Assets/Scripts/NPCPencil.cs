using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    /** <summary>An object that handles and spawns the NPC pencil prefab.</summary>*/
    public class NPCPencil : MonoBehaviour, INPCWeapon
    {
        // Bodies
        public Rigidbody2D npcBody;
        public Rigidbody2D npcPencilBody;
        public SpriteRenderer pencilSprite;

        // Location
        float timeToFire = 0;
        Vector3 targetPos;

        // Timing
        private static float TIMEOUT = .1f;
        private bool isLive;
        private float countdown;

        public void Awake()
        {
        }

        public void Start()
        {
            npcPencilBody.GetComponent<SpriteRenderer>().enabled = false;
            this.IsLive = false;
            this.Countdown = TIMEOUT;
            Physics2D.IgnoreCollision(npcBody.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }

        public void Fire(float damagePoints = 0.1f, Constants.DamageType damageType = Constants.DamageType.Static)
        {
            // Call the overloaded Fire function
            Fire(damagePoints,damageType,new Vector2());
        }

        /**
         * <summary>Spawns a new pencil object in 
         * the direction of that the character is facing</summary>
         * 
         */
        public void Fire(
            float damagePoints = 0.1f,
            Constants.DamageType damageType = Constants.DamageType.Static,
            Vector2 fireToPoint = new Vector2()
        )
        {
            Debug.Log("NPC PECNIL FIRE");
            
            // Enable the pencil to be  live
            this.isLive = true;
            
            // Enable box collider and sprite
            npcPencilBody.GetComponent<SpriteRenderer>().enabled = true;
            npcPencilBody.GetComponent<PolygonCollider2D>().enabled = true;
        }

        public void FixedUpdate()
        {
            if (isLive) // Checks if fire has been called, if so -> begin movement
            { 
                // Start the countdown for length of time on the screen
                this.Countdown -= Time.deltaTime;

                if (countdown <= 0)
                {

                    // Set the up direction of the NPCPencil to be the same as the NPCs 
                    transform.GetComponent<Rigidbody2D>().rotation = npcBody.rotation;
                    transform.up = npcBody.transform.up;

                    // Fire the pencil upward/where the npc is facing
                    transform.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
                   
                    // Time's up, reset counter, isLive tag, and position
                    isLive = false;
                    this.Countdown = TIMEOUT;
                }
            }
            else
            {
                // Idle properties
                npcPencilBody.position = new Vector2(npcBody.position.x, npcBody.position.y);
                npcPencilBody.GetComponent<SpriteRenderer>().enabled = false;
                npcPencilBody.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }

        public void LateUpdate()
        {
        }

        public NPCPencil()
        {
            MaxAmmo = 1;
            Ammo = 1;
        }

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

        /** <summary>Returns the time left for pencil that is firing</summary> */
        public float Countdown
        {
            get { return countdown; }
            private set { countdown = value; }
        }

        /** <summary>Returns if the Pencil is currently Fire()ing</summary> */
        public bool IsLive
        {
            get { return isLive; }
            private set { isLive = value; }
        }

        public float DealDamage
        {
            get
            {
                return this.Damage;
            }

            set
            {
                DealDamage = value;
            }
        }
    }
}

