using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmoSphereThing : MonoBehaviour
{
	protected void OnDrawGizmos() {
		var cantgofarther = this.GetComponent<CantGoFartherFromThere>();
		Gizmos.DrawSphere(cantgofarther.center, cantgofarther.bounds);
	}
}
