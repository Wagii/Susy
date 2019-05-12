using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class MenuScript : MonoBehaviour {
	
	[SerializeField] private Scene targetScene;
	
	protected void Awake() {
		if (this.targetScene == null)
			Destroy(this);
		SceneManager.LoadScene(this.targetScene.buildIndex, LoadSceneMode.Single);
	}
	
	protected void OnTriggerEnter(Collider col) {
		//if (other.transform.parent.GetComponent<Rigidbody>() != Manager.player) return;
		SceneManager.SetActiveScene(this.targetScene);
	}
}
