using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{
	Test test;
	protected void OnEnable() {
		test = target as Test;
		test.rb = test.GetComponent<Rigidbody>();
	}
	
	public override void OnInspectorGUI() {
		test = target as Test;
		
		EditorGUILayout.LabelField(test.rb.velocity.magnitude.ToString());
	}
}
