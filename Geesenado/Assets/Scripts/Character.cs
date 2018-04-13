﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public float _health;
    public float _movementSpeed;
    public Rigidbody2D _rb;
    private int _currEquippedMelee;
    private int _currEquippedRanged;
	public float maxHleath=4.0f;
    //private Weapon[] _inventory = new Weapon[3];

    public void Start()
    {
        _health = 4.0f;
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {

    }

    public virtual void movement()
    {

    }

    public void damageInflicted(float damage)
    {
        _health -= damage;
    }

    public float getHealth()
    {
        return _health;
    }
	public float getMaxHealth()
	{
		return maxHleath;
	}
    public void setMovementSpeed(float m)
    {
        _movementSpeed = m;
    }
	public void addHealth(float value){
		_health = _health + value;
		
	}
    //public Weapon[] getInventory(){ return _inventory; }
    //public void addToInventory(Weapon w){}
}
