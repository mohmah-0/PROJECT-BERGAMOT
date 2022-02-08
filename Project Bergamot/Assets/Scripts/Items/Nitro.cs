using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : Item
{
    public override void Use(GameObject car)
    {
        car.GetComponent<Inventory>().UseNitro();
    }
}
