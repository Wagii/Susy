using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSphere : MonoBehaviour
{
	[Range(0.5f, 100f)] public float radius = 1;
	
	protected void OnDrawGizmosSelected() {
		Gizmos.DrawSphere(this.transform.position, radius);
	}
}
