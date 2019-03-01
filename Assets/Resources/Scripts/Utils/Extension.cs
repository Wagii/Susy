using UnityEngine;

public static class Extension {
	public const string LEFT_HAND = "Hand_Left";
	public const string RIGHT_HAND = "Hand_Right";
	public const string LEFT_OBJECT_HAND = "Hand_Object_Left";
	public const string RIGHT_OBJECT_HAND = "Hand_Object_Right";
	
	public const int AllLayers = Physics.AllLayers;

	public static int OverlapSphereNonAlloc(Vector3 position, 
		float radius, 
		out Collider[] results, 
		int layerMask = AllLayers, 
		QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) 
	{
		int i = Physics.OverlapSphere(position, radius, layerMask, queryTriggerInteraction).Length;
		results = new Collider[i];
		return Physics.OverlapSphereNonAlloc(position, radius, results, layerMask, queryTriggerInteraction);
	}
	
	public static void PrintGizmo(Transform transform) {
		Debug.DrawRay(transform.position, transform.forward, Color.blue);
		Debug.DrawRay(transform.position, transform.right, Color.red);
		Debug.DrawRay(transform.position, transform.up, Color.green);
	}
	
	public static void Cast(Vector3 position, Vector3 direction, Color color) {
		Debug.DrawRay(position, direction, color);
	}
}
