using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubScreen : MonoBehaviour
{
	public Color lerpedColor = Color.white;
	public Renderer rend;
	public Color color1;
	public Color color2;
	
	public float duration = 1f;
	
	
    void Update()
    {
	    lerpedColor = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, duration));
	    this.GetComponent<Renderer>().material.color = lerpedColor;
    }
}
