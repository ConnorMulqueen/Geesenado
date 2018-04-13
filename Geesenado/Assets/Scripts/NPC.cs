using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class NPC : Character
    {
        //Used for passive walking
        private float _prevTime; //Used to script movement() sequence
        private double _timeRunning; //Time spent running and holding position
        private UnityEngine.Vector2[] _directions; //The 4 cardinal directions (left, right, up, down)
        private UnityEngine.Vector2 _currentDirection;

        //Used for running at Player
        private float _aggroRadius;
        private bool _aggroFlag;
        private Transform _target;


        //Used for dodging the player's attacks
        private float _dodgeRadius;
        private bool _dodgeAvailable;
        private bool _currentlyDodging;
        private float _dodgeStartTime;

        private bool _panicRun;


        new void Start()
        {
            base.Start();
            _prevTime = Time.time;
            _directions = new UnityEngine.Vector2[4] { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
            _currentDirection = _directions[Random.Range(0, 4)];
            _timeRunning = 3.0;

            _aggroRadius = 5f;
            _aggroFlag = false;
            _target = GameObject.FindGameObjectWithTag("Player").transform;

            _dodgeRadius = 3f;
            _dodgeAvailable = false;
            _currentlyDodging = false;

            _panicRun = false;
        }

        new void Update()
        {
            movement();
        }

        /*<summary> This method is the root of all movement for the NPC class. */
        new void movement()
        {

            if (_panicRun)
            {
                panicRun();
            }
            //Currently running towards Player (aggro state)
            else if (_aggroFlag)
            {
                if (_currentlyDodging)
                {
                    dodge();
                }
                else
                {
                    aggroRun();
                }
            }

            //currently walking in random directions (passive state)
            else if (!_aggroFlag)
            {
                passiveWalk();
                if (Vector2.Distance(transform.position, _target.position) < _aggroRadius) //check if player is in range to aggro NPC
                {
                    _rb.velocity = new Vector3(0f, 0f, 0f);
                    _aggroFlag = true;

                }
            }
        }

        /*<summary> Removes health from this NPC instance */
        new void damageInflicted(float dmg)
        {
            _health -= dmg;

            //Panic run
            if (_health < 1.0f)
            {
                _panicRun = true;
                _timeRunning -= 1;
                resetMovementInfluences();
            }

            //Die
            if (_health < 0)
            {
                Destroy(gameObject);
            }
        }

        /*<summary> looks and runs at player */
        void aggroRun()
        {
            dodge();
            _rb.velocity = new Vector3(0f, 0f, 0f);
            transform.LookAt(_target);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            if (!(Vector2.Distance(transform.position, _target.position) < 1.8f))
            {   //check if player is in range to aggro NPC
                transform.Translate(new Vector3(_movementSpeed * Time.deltaTime, 0, 0));
            }

        }

        /* <summary> Checks if a paperball is within _dodgeRadius, if it is, then 
         * the NPC attempts to dodge it. There is also a time cooldown to reduce how often the NPC
         * can dodge. */
        void dodge()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _dodgeRadius);

            if (_dodgeAvailable && Time.time < _dodgeStartTime + .3) //Move in 'dodge' direction
            {
                _currentlyDodging = true;
                transform.Translate(_currentDirection * _movementSpeed * Time.deltaTime * 3);
            }
            else
            {
                _currentlyDodging = false;
            }

            if (_dodgeAvailable && Time.time > _dodgeStartTime + 2.0) //dodge complete, reset flag
            {
                _dodgeAvailable = false;
                _currentlyDodging = false;
            }

            for (int i = 0; i < hitColliders.Length; i++) //checks if paperball is within range, if it is then dodge.
            {
                if (!_dodgeAvailable && hitColliders[i].tag == "Bullet")
                {
                    _dodgeAvailable = true;
                    _dodgeStartTime = Time.time;
                    _currentDirection = _directions[Random.Range(2, 4)]; //choose new random direction (left or right) to Dodge towards
                }
            }

        }


        /*<summary> Used before the Player aggros the NPC, it makes the 
         * NPC passively walk in random directions */
        void passiveWalk()
        {
            //Walk
            if (Time.time - _prevTime < _timeRunning)
            {
                //transform.Translate(_currentDirection* Time.deltaTime * _movementSpeed);
                _rb.velocity = _currentDirection * 2f;
            }

            //Hold position
            else if (Time.time - _prevTime > _timeRunning && Time.time - _prevTime < _timeRunning * 2) { }

            //Reset
            else
            {
                resetMovementInfluences();
            }
        }
        void panicRun()
        {
            _rb.freezeRotation = true;
            if (Time.time - _prevTime < _timeRunning)
            {
                _rb.velocity = _currentDirection * 5f;
            }
            else
            {
                resetMovementInfluences();
            }
        }
        void resetMovementInfluences()
        {
            _rb.velocity = new Vector3(0f, 0f, 0f);
            _currentDirection = _directions[Random.Range(0, 4)];
            _prevTime = Time.time;
            _rb.angularVelocity = 0f;


        }
        /*<summary> Checks if this instance of NPC 
         * gets hit with a weapon. If it does then it calls damageInflicted
         * and removes health*/
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Bullet")
            {
                float dmg = col.gameObject.GetComponent<IDealsDamage>().DealDamage;
                Debug.Log("NPC took damage: " + dmg.ToString());
                damageInflicted(dmg);
                _rb.velocity = new Vector3(0f, 0f, 0f);
            }
        }
    }
}