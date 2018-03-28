using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**<summary>Used to identify weapons that is used by a player.</summary> */
public interface IPlayerWeapon : IWeapon
{
    /**
     * <summary>Decreases ammount of weapon </summary>
     * <param name="damageType">The <seealso cref="DamageType"/> of this weapon.</param>
     */
    void Fire(float damagePoints, Constants.DamageType damageType);

}

