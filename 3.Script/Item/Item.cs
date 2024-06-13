using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Basic, ChoiceOwn, ChoiceMove,Nothing
}

public class Item : MonoBehaviour
{
    [SerializeField] ItemType itemType;
    [SerializeField] int itemID;
    ItemBasic basicItem;
    ItemChoiceOwn choiceOwnItem;
    ItemChoiceMove choiceMoveItem;

    private void Awake()
    {
        switch (itemType)
        {
            case ItemType.Basic:
                basicItem = GetComponent<ItemBasic>();
                choiceOwnItem = null;
                choiceMoveItem = null;
                break;
            case ItemType.ChoiceOwn:
                basicItem = null;
                choiceOwnItem = GetComponent<ItemChoiceOwn>();
                choiceMoveItem = null;
                break;
            case ItemType.ChoiceMove:
                basicItem = null;
                choiceOwnItem = null;
                choiceMoveItem = GetComponent<ItemChoiceMove>();
                break;
            case ItemType.Nothing:
                basicItem = null;
                choiceOwnItem = null;
                choiceMoveItem = null;
                break;
        }
    }
    public int getID { get { return itemID; } }
    public ItemBasic getBasicItem { get { return basicItem; } }
    public ItemChoiceOwn getChoiceOwnItem { get { return choiceOwnItem; } }
    public ItemChoiceMove getChoiceMoveItem { get { return choiceMoveItem; } }
    public ItemType getType { get { return itemType; } }
}