using UnityEngine;
using Valve.VR;

public class Handler : MonoBehaviour {

	private const float magicValue = 1.660795f;
	[SerializeField] private Transform target;
	[SerializeField] private Mesh gizmo, reverseGizmo;
	private MeshFilter rd;
	[HideInInspector] public bool reverse = false;
	
	private PlayerMovementParameters parameters { get { return Manager.parameters.playerMovementParameters; } }

	private void Start() {
	    this.reverse = parameters.reverse;
		this.rd = GetComponent<MeshFilter>();
		this.transform.localScale = Vector3.one * .0001f;
	    this.gameObject.SetActive(false);
    }

	protected void Update() {
		if (this.reverse != Manager.parameters.playerMovementParameters.reverse){
			this.reverse = Manager.parameters.playerMovementParameters.reverse;
			this.rd.mesh = this.reverse? this.reverseGizmo : gizmo;
	}
        this.transform.LookAt(this.target.transform);
        this.transform.localScale = Vector3.one 
	        * Mathf.Clamp((this.target.transform.position - transform.position).magnitude, 
                            parameters.minVectorValue, 
	        				parameters.maxVectorValue)
	        / 2.75f
			* (reverse ? -1 : 1);
    }

	public void Press (SteamVR_Behaviour_Boolean pose, SteamVR_Input_Sources sources, bool press) {
		this.transform.localPosition = this.target.localPosition;
	}
    
	public void Release (SteamVR_Behaviour_Boolean pose, SteamVR_Input_Sources sources, bool press) {
		this.transform.localScale = Vector3.one * .0001f;
	}
}
