using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private GameObject _item;

    public void PickUp()
    {
        GameObject.FindGameObjectWithTag(Constants._mainPlayer).GetComponent<Inventory>().AddItem(this);
    }

    public int GetId() { return _id; }
    public string GetName() { return _name; }
    public GameObject GetItem() { return _item; }
}
