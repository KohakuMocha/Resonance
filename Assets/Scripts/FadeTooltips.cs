using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTooltips : MonoBehaviour {

    [SerializeField]
    private Texture2D Tooltip;
    [SerializeField]
    private float fadeSpeed = .8f;

    private float alpha = 0.0f;

    private int draw = -1000;

    private int dir = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            //StartCoroutine(ShowTooltip(1));
            dir = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //StartCoroutine(ShowTooltip(-1));
            dir = -1;
        }
    }

    /*IEnumerator ShowTooltip(int dir)
    {
        while (alpha != Mathf.Clamp01(dir))
        {
            alpha += dir * Time.deltaTime;
            Mathf.Clamp01(alpha);
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = draw;
            GUI.DrawTexture(new Rect(0, 0 - (Screen.height / 4), Tooltip.width, Tooltip.height), Tooltip);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }*/
    private void OnGUI()
    {
        //Debug.Log(alpha);
        alpha += dir * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = draw;
        GUI.DrawTexture(new Rect(0, 0, Tooltip.width, Tooltip.height), Tooltip, ScaleMode.ScaleToFit);
    }
}
