using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void Use(GameObject car);
    public abstract void DisplayItem();
}
