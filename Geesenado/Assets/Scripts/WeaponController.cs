using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

/**
 * <summary>
 * Right Click - Melee Weapon,
 * Left Click - Ranged Weapon
 * Tab - Cycle Ranged Weapons,
 * Shift & Tab - Cycle Melee Weapons
 * </summary>  
 */


public class WeaponController : MonoBehaviour {

    // Scene Objects
    public GameObject playerObject;
    public Paper paper;
    public Pencil pencil;
    public Textbook textbook;
    public Ruler ruler;

    // Local
    // item at position 0 of list will be fired
    private List<IHoldable> ranged;
    private List<IHoldable> melee;
    private int weaponIndex;

    

	// Use this for initialization
	void Start () {
        ranged = new List<IHoldable>();
        ranged.Add(paper);
        ranged.Add(textbook);  //Comment out for testing purposes

        melee = new List<IHoldable>();
        melee.Add(pencil);
        melee.Add(ruler); //Comment out for testing purposes
	}
	//*Needs to be edited if player is only going to start with only start with one or two weapons and pickup the rest*//
	void Update () {

        // Setting Mouse Left Click for MELEE attack
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButton(0))
        {
            ((IWeapon) melee[0]).Fire();
        }

        // Setting Space Bar or Right Click for RANGED attack
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))
        {
            ((IWeapon) ranged[0]).Fire();
        }

        // Toggle Functionality
        if (Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Toggled Ranged Weapons");
            MoveToFirst(ranged.Count - 1, 0, ranged);
        }
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Toggled Melee Weapons");
            MoveToFirst(melee.Count - 1, 0, melee);
        }
    }

    public void MoveToFirst(int oldIndex, int newIndex, List<IHoldable> list)
    {
        var item = list[oldIndex];
        list.RemoveAt(oldIndex);
        list.Insert(newIndex, item);
    }

    //Checks to see if weapons to pickup is not contained in the list of weapons then it is added.
    public bool Pickup(string weapon)
    {

        if (weapon.Equals("Ruler") && !melee.Contains(ruler)){
            melee.Add(ruler);
        }else if (weapon.Equals("Textbook") && !ranged.Contains(textbook))
        {
           ranged.Add(textbook);
        }
        else if (weapon.Equals("Pencil") && !melee.Contains(pencil))
        {
            melee.Add(pencil);
        }
        else if (weapon.Equals("Paper") && !ranged.Contains(paper))
        {
            ranged.Add(paper);
        }
        else
        {
            return false;
        }

        return true;
    }

}
