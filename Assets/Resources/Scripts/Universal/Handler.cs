using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour {

	private const float magicValue = 1.660795f;
	
public static Handler CreateHand(GameObject obj, Transform target, bool reverse)  {
		obj.GetComponent<Handler>().target = target;
		obj.GetComponent<Handler>().reverse = reverse;
		obj.transform.localPosition = Vector3.zero;
		obj.SetActive(false);
		return obj.GetComponent<Handler>();
	}

	public static void ActivateHand(GameObject obj, Transform press) {
		obj.SetActive(true);
		obj.transform.position = press.position;
	}
	
	public static void DisableHand(GameObject obj) {
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		obj.transform.localScale = Vector3.one * 0.00001f;
		obj.SetActive(false);
	}

	[HideInInspector] public Transform target;
	[HideInInspector] public bool reverse = false;

	protected void Update () {
		transform.LookAt(target.transform);
		transform.localScale = Vector3.one * (target.transform.position - transform.position).magnitude * magicValue * (reverse? -1: 1);
	}
	
}
