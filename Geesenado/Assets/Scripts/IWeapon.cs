using Helpers;
using UnityEngine;

public interface IWeapon
{

    /* --------- NOTES --------
     * All weapons when fired will use up 1 ammunition. Effects of weapons can create other effects 
     * (e.g. Tri Shot, Three Round Burst, etc.)
    */

    // --------- Properties ---------
    /**
     * <summary>Returns the current amount of ammo for this weapon.</summary>
     */
    int Ammo { get; set; }

    /**
     * <summary>Returns t max amount of ammo allowed for this weapon.
     * Has the ability to be boosted by a character ability.</summary>
     */
    int MaxAmmo { get; set; }

    /**
     * <summary>The ammount of GPA damage this weapon does. 
     * Has the ability to be boosted by character ability.</summary>
     */
    float Damage { get; set; }
}