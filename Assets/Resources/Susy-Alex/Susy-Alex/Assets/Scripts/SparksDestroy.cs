using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksDestroy : MonoBehaviour {

	public float lifeTime = 1;
	
	void Update () {
		lifeTime -= 1 * Time.deltaTime;

		if (lifeTime <= 0){
			Destroy(this.gameObject);
		}
	}
}
