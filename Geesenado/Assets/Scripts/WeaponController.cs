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

    // Local
    // item at position 0 of list will be fired
    private List<IHoldable> ranged;
    private List<IHoldable> melee;
    private int weaponIndex;

    

	// Use this for initialization
	void Start () {
        ranged = new List<IHoldable>();
        ranged.Add(paper);
        ranged.Add(textbook);

        melee = new List<IHoldable>();
        melee.Add(pencil);
	}
	
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
        if (Input.GetKeyDown(KeyCode.Tab))
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
}
