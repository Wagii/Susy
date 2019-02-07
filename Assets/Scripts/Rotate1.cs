using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour {

	public float rotation1;
	public float rotation2;
	public float rotation3;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotation1 * Time.deltaTime, rotation2 * Time.deltaTime, rotation3 * Time.deltaTime);
	}
}
