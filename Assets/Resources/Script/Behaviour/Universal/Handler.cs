using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour {

	private const float magicValue = 1.660795f;
	//public static GameObject prefab;
	//public static GameObject reversePrefab;
	
	//private Vector3 norm { get { return Vector3.right + Vector3.forward; } }
	
	//public static Handler CreateHand (Vector3 position, Transform parent, Transform hand, bool reverse) {
	//	GameObject obj;
	//	if (reverse)
	//		obj = Instantiate(reversePrefab, position, Quaternion.identity, parent);
	//	else
	//		obj = Instantiate(prefab, position, Quaternion.identity, parent);
	//	Handler handler = obj.GetComponent<Handler>();
	//	handler.target = hand;
	//	handler.reverse = reverse;
	//	return handler;
	//}
	
	//public static void DestroyHand (Handler hand) {
	//	DestroyImmediate (hand.gameObject);
	//}
	

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
		//transform.localScale = Vector3.up * (target.localPosition - transform.localPosition).magnitude + this.norm;
		//transform.LookAt(target.position * (reverse? -1 : 1));
		transform.LookAt(target.transform);
		transform.localScale = Vector3.one * (target.transform.position - transform.position).magnitude * magicValue * (reverse? -1: 1);
	}
	
}
