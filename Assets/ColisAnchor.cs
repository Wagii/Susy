using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColisAnchor : MonoBehaviour
{
	[SerializeField] private Transform target = null;
	[SerializeField] private Vector3 offset = Vector3.zero;
	
	protected void Update() {
		this.transform.eulerAngles = Vector3.up * this.target.eulerAngles.y;
		this.transform.position = this.target.position + this.offset;
	}
}
