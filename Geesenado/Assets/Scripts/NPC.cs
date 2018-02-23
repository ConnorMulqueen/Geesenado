using UnityEngine;
using System.Collections;

public class NPC : Character
{

    private float _prevTime; //Used to script movement() sequence
    private double _timeRunning; //Time spent running and holding position
    private UnityEngine.Vector2[] _directions; //The 4 cardinal directions (up, down, left, right)
    private UnityEngine.Vector2 _currentDirection;

    //public Pencil pencil;

    /* Phase 1 Instance Variables 
     * 
     * private float _aggroRadius = 5f;
     * private Transform _target;
     */

    new void Start()
    {
        base.Start();
        _prevTime = Time.time;
        _directions = new UnityEngine.Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        _currentDirection = _directions[Random.Range(0, 4)];
        _timeRunning = 3.0;

        //_target = GameObject.FindGameObjectWithTag("Player").transform;
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
        //Move
        if (Time.time - _prevTime < _timeRunning)
        {
            transform.Translate(_currentDirection * Time.deltaTime * _movementSpeed);
        }

        //Hold position
        else if (Time.time - _prevTime > _timeRunning && Time.time - _prevTime < _timeRunning * 2) { }

        //Reset
        else
        {
            _currentDirection = _directions[Random.Range(0, 4)];
            _prevTime = Time.time;
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

    /* Phase 1 functionality in progress: Smarter movement 
     * void movementp1() {
     *     float distance = vector2.distance(_target.position, transform.position);
     *     if (distance <= _aggroRadius) {
     *         _navmeshagent.setdestination(_target.position);
     *     }
     * }
     */

    /* Phase 1 functionality: Display aggro bubble
    * 
    * void ondrawgizmosselected()
    * {
    *     gizmos.color = color.red;
    *     gizmos.drawwiresphere(transform.position, _aggroRadius);
    * }
    */
}
