using UnityEngine;

public class Manager : MonoBehaviour {
	public static Manager parameters;
	public Rigidbody player;
	public SlowParameters slowParameters;
	
	protected void Awake() {
		Manager.parameters = this;
		if (this.player == null) this.player = FindObjectOfType<Valve.VR.SteamVR_PlayArea>().GetComponent<Rigidbody>();
	}
}
