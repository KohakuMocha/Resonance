using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public LinkedList<Items> inventory;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addItem(Items obj)
    {
        inventory.AddLast(obj);
    }
    public bool checkItem(Items obj)
    {
        foreach (Items x in inventory)
        {
            if (obj == x)
            {
                inventory.Remove(x);
                return true;
            }
        }
        return false;
    }
}
