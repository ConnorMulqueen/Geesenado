using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using UnityEngine;

namespace Assets.Scripts
{
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
        private static float TIMEOUT = 1f;
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
            // Load the fire to point into the global variable
            targetPos = fireToPoint;

            // Enable the pencil to be  live
            this.isLive = true;
            npcPencilBody.GetComponent<SpriteRenderer>().enabled = true;

            // Set the up direction of the NPCPencil to be the same as the NPCs 
            Vector2 direction = npcBody.transform.up;
            transform.up = direction;
        }

        public void FixedUpdate()
        {
            if (isLive) // Checks if fire has been called, if so -> begin movement
            {
                // Set the location to move towards
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPos,
                    5 * Time.deltaTime
                );

                // Start the countdown for length of time on the screen
                this.Countdown -= Time.deltaTime;

                if (countdown <= 0)
                {
                    // Time's up, reset counter, isLive tag, and position
                    isLive = false;
                    this.Countdown = TIMEOUT;
                    npcPencilBody.position = new Vector2(npcBody.position.x, npcBody.position.y);
                }
            }
            else
            {
                npcPencilBody.position = new Vector2(npcBody.position.x, npcBody.position.y);
                npcPencilBody.GetComponent<SpriteRenderer>().enabled = false;
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

    }
}

