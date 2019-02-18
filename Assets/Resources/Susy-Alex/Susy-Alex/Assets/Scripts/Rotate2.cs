using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour {

	public float rotation;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotation * Time.deltaTime , 0);
	}
}
