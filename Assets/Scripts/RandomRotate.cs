using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour {

	public Quaternion quaternion;
	public float rotateSpeed;

	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.Slerp(Random.rotation, Random.rotation, rotateSpeed * Time.deltaTime);
	}
}
