using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CollisionSound))]
public class CollisionSoundEditor : Editor {
	CollisionSound obj;
	GUIStyle style;
	
	protected void OnEnable() {
		style = new GUIStyle();
		style.alignment = TextAnchor.MiddleCenter;
	}
	
	public override void OnInspectorGUI() {
		this.obj = target as CollisionSound;
		this.obj.useManagerSounds = EditorGUILayout.Toggle(value: this.obj.useManagerSounds, label: "Use only Manager Sound?");
		if (!this.obj.useManagerSounds) {
			
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Collision Tag : Sound plays if this tag is contained in the other object's tag.", style);
			EditorGUILayout.LabelField("Leave empty to make the sound play on every collision.", style);
			EditorGUILayout.LabelField("Minimum value : Necessary collision force to activate sound on collision.", style);
			EditorGUILayout.LabelField("In trigger's case, speed when Entering, Leaving or In the trigger", style);
			EditorGUILayout.Space();
			
			base.OnInspectorGUI();
		}
	}
	
}
