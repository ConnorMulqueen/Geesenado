using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class NPC : Character
    {
        //Used for passive walking
        private float _prevTime; //Used to script movement() sequence
        private double _timeRunning; //Time spent running and holding position
        private UnityEngine.Vector2[] _directions; //The 4 cardinal directions (up, down, left, right)
        private UnityEngine.Vector2 _currentDirection;

        //Used for running at Player
        private float _aggroRadius;
        private bool _aggroFlag;
        private Transform _target;

        //Used for firing weapon
        public NPCPencil _pencil;
        public double _fireRate;
        private double _prevFireTime;

        //Used for dodging the player's attacks
        private float _dodgeRadius;
        private bool _dodgeAvailable;
        private bool _currentlyDodging;
        private float _dodgeStartTime;


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
        }

        new void Update()
        {
            movement();
        }

        /* <summary> NPC moves in random direction for prototype phase </summary>
           Thoughts: use 'InvokeRepeating' in the Start() method instead
           of this approach next time*/
        new void movement()
        {
            if (_aggroFlag)
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
            else if (!_aggroFlag)
            {
                passiveWalk();
                if (Vector2.Distance(transform.position, _target.position) < _aggroRadius) //check if player is in range to aggro NPC
                {
                    _aggroFlag = true;
                }
            }
        }

        new void damageInflicted(int dmg)
        {
            _health -= dmg;

            //Panic run
            if (_health < 20)
            {
                _movementSpeed *= 3;
                _timeRunning *= 2;
            }

            //Die
            else if (_health < 0)
            {
                Destroy(gameObject);
            }
        }

        void aggroRun()
        {
            dodge();
            transform.LookAt(_target);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self); ;
            transform.Translate(new Vector3(_movementSpeed * Time.deltaTime, 0, 0));

            if (Time.time - _prevFireTime > _fireRate || _prevFireTime == 0)
            {
                //TODO: fire weapon here.

                _prevFireTime = Time.time;

            }
        }

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
        void passiveWalk()
        {
            //Walk
            if (Time.time - _prevTime < _timeRunning)
            {
                transform.Translate(_currentDirection* Time.deltaTime * _movementSpeed);
            }

            //Hold position
            else if (Time.time - _prevTime > _timeRunning && Time.time - _prevTime < _timeRunning * 2) { }

            //Reset
            else
            {
                Debug.Log("reset direction");
                int x = Random.Range(0, 4);
                Debug.Log(x);
                _currentDirection = _directions[Random.Range(0, 4)];
                _prevTime = Time.time;
            }
        }


        /* Phase 1 Testing functionality: Display aggro bubble
  
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _aggroRadius);
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _dodgeRadius);
        }

        */

    }
}
