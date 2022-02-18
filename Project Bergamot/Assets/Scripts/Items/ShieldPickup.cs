using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Item
{
    [SerializeField]Item shield;

    public override void Use(GameObject car)
    {
        shield.Use(car);
    }
}
