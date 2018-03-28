using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

/**<summary>Used to identify weapons that is used by the NPC.</summary> */
public interface INPCWeapon : IWeapon
{
    void Fire(float damagePoints, Constants.DamageType damageType, Vector2 fireToPoint);
}

