using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Item, int> _items = new Dictionary<Item, int>();

    public void AddItem(Item item)
    {
        //check if item exists
        if (_items.ContainsKey(item))
        {
            _items[item] += 1;
            return;
        }
        _items.Add(item, 1);
    }

    public void Clear()
    {
        _items.Clear();
    }
}



