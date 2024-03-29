using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB itemInstance;
    public void Awake()
    {
        itemInstance = this;
    }
    //public List<Item> itemData = new List<Item>();
}
