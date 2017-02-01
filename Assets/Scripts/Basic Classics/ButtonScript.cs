using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
    public Sprite OnHoverOuterBox; //Image of Selected Outer Box 
    public Sprite OffHoverOuterBox; //Image of Regular Outer Box 
    public GameObject OuterBox; //Game Object of OuterBox

	// Use this for initialization
	void Start () {
    }
	public void OnHover()
    {
        //Change Opacity of Inner Box
        Color temp = this.GetComponent<Image>().color;
        temp.a = 0.9f;
        this.GetComponent<Image>().color = temp;

        //Change Outter Box Image to Select
        OuterBox.GetComponent<Image>().sprite = OnHoverOuterBox;

    }
    public void OnHoverAway()
    {
        //Change Opacity of Inner Box
        Color temp = this.GetComponent<Image>().color;
        temp.a = 0.6f;
        this.GetComponent<Image>().color = temp;

        //Change Opactiy of OuterBox
        OuterBox.GetComponent<Image>().sprite = OffHoverOuterBox;
        Color temp2 = OuterBox.GetComponent<Image>().color;
        temp2.a = 0.6f;
        OuterBox.GetComponent<Image>().color = temp2;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
