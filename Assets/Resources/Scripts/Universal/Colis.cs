using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Slower)), RequireComponent(typeof(StickAtPosition))]
public class Colis : MonoBehaviour {
	public Collider trigger = null, col = null;
	public Rigidbody body = null;
	private Rigidbody rb = null;
	private Slower slower = null;
	private StickAtPosition stick = null;
	private GameObjectEntity entity = null;
	
	protected void Start() {
		this.rb = GetComponent<Rigidbody>();
		this.slower = GetComponent<Slower>();
		this.stick = GetComponent<StickAtPosition>();
		this.entity = GetComponent<GameObjectEntity>();
		Take();
	}

	[SerializeField] private float timeBeforeTakeable = 0.75f;
	private bool takable = false;

	public void Take() {
		Manager.quest.hasColis = true;
		this.stick.enabled = true;

		var hinge = GetComponent<HingeJoint>();
		if (hinge != null) {
			hinge.connectedBody = body;
		}

		this.rb.velocity = Vector3.zero;
		this.rb.angularVelocity = Vector3.zero;
		this.transform.rotation = Quaternion.identity;
		this.trigger.enabled = false;
		this.col.enabled = false;
		this.entity.enabled = false;
		this.slower.enabled = false;
	}


	// Don't forget to drop the colis on collision Enter
	public void Drop() {
		Manager.quest.hasColis = false;
		this.stick.enabled = false;

		var hinge = GetComponent<HingeJoint>();
		if (hinge != null) {
			hinge.connectedBody = null;
		}

		this.rb.velocity = -Manager.player.velocity.normalized * Manager.parameters.slowParameters.slowSpeed;
		this.rb.angularVelocity = RandomVector();
		this.col.enabled = true;
		this.entity.enabled = true;
		this.slower.enabled = true;

		StartCoroutine(SetTakeableAfterTime(this.timeBeforeTakeable));
	}

	private System.Collections.IEnumerator SetTakeableAfterTime(float time) {
		yield return new WaitForSeconds(time);
		this.trigger.enabled = true;
	}

	protected void OnTriggerEnter(Collider other) {
		Take();
	}

	private Vector3 RandomVector(float min = -3, float max = 3) {
		return new Vector3(Random.Range(min, max),Random.Range(min, max),Random.Range(min, max));
	}

}