using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	public Renderer background;

	public Color colorStart;
    public Color colorEnd;

	// Use this for initialization
	void Start () {
		background = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float lerp = Mathf.PingPong(Time.time, 3) /  3;
        this.background.material.color = Color.Lerp(colorStart, colorEnd, lerp);
	}
}
