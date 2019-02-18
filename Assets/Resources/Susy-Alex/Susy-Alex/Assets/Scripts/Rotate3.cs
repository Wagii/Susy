using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3 : MonoBehaviour {

	public float rotation;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotation * Time.deltaTime, 0, 0);
	}
}
