using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour {

	public float rangeMin;
	public float rangeMax;

	public Vector3 random;
	public Vector3 randomSize;
	
	// Update is called once per frame
	void Update () {

		random.x = Random.Range (rangeMin, rangeMax);
		Vector3 randomSize = new Vector3 (random.x,  random.x, random.x);
		this.gameObject.transform.localScale = randomSize;

	}
}
