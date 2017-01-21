using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Items
{
    Key,
    Stone,


}
public class InteractableObject : MonoBehaviour {

    public Items typeOfItem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        addItemToInventory();
        Destroy(this);
    }
    public void addItemToInventory()
    {
        GameObject.Find("Character").GetComponent<Inventory>().inventory.Add(this);
    }
}
