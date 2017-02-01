using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfAllLit : MonoBehaviour {
    public List<ObjectLit> Objects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void CheckToggles()
    {
        for(int x = 0; x < Objects.Count; x++)
        {
            if (!Objects[x].ItIsLit)
            {
                return;
            }
        }
        Application.LoadLevel("Final");
        Player.Instance.transform.position = new Vector3(-164f, -28f, -1f);
    }
}
