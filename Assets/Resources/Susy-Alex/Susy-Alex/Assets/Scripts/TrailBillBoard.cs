using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBillBoard : MonoBehaviour {

	private ParticleSystem ps;
    private ParticleSystemRenderer psr;
    public ParticleSystemRenderSpace alignment = ParticleSystemRenderSpace.View;

    void Start() {

        Camera.main.transform.rotation = Quaternion.Euler(0.0f, 20.0f, 0.0f);   // rotate the camera so we can see the difference between view and world space

        ps = GetComponent<ParticleSystem>();
        psr = GetComponent<ParticleSystemRenderer>();

        var main = ps.main;
        main.startSpeed = 2.0f;

        psr.material = new Material(Shader.Find("Sprites/Default"));
    }

    void Update() {
        psr.alignment = alignment;
    }

    void OnGUI() {
        alignment = (ParticleSystemRenderSpace)GUI.SelectionGrid(new Rect(25, 25, 300, 30), (int)alignment, new GUIContent[] { new GUIContent("View"), new GUIContent("World"), new GUIContent("Local"), new GUIContent("Facing") }, 4);
    }
}
