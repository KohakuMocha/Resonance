using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<InteractableObject> inventory;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public bool checkItem(Items obj)
    {
        foreach (InteractableObject x in inventory)
        {
            if (obj == x.typeOfItem)
            {
                inventory.Remove(x);
                UIManager.Instance.RemoveKey();
                return true;
            }
        }
        return false;
    }
}
