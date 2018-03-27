using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public interface INPCWeapon : IWeapon
{

    void Fire(float damagePoints, Constants.DamageType damageType, Vector2 fireToPoint);
}

