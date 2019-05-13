using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Slower)), RequireComponent(typeof(StickAtPosition))]
public class Colis : MonoBehaviour {
	public Collider trigger = null, col = null;
	private Rigidbody rb = null;
	private Slower slower = null;
	private StickAtPosition stick = null;
	private GameObjectEntity entity = null;
	[SerializeField] private GameObject modelLeft = null, modelRight = null;
	
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

		this.rb.velocity = Vector3.zero;
		this.rb.angularVelocity = Vector3.zero;
		this.rb.constraints = RigidbodyConstraints.FreezeRotation;
		this.transform.rotation = Quaternion.identity;
		this.trigger.enabled = false;
		this.col.enabled = false;
		this.entity.enabled = false;
		this.slower.enabled = false;
		
		this.transform.localScale = Vector3.one;
		
		this.modelLeft.SetActive(false);
		this.modelRight.SetActive(false);
	}


	// Don't forget to drop the colis on collision Enter
	public void Drop(Collision collisionInfo) {
		this.takable = false;
		Manager.quest.hasColis = false;
		this.stick.enabled = false;

		this.rb.constraints = RigidbodyConstraints.None;
		this.rb.velocity = collisionInfo.relativeVelocity.normalized * 75;
		this.rb.angularVelocity = RandomVector();
		this.col.enabled = true;
		this.entity.enabled = true;
		this.slower.enabled = true;

		this.transform.localScale = Vector3.one * 10;

		this.modelLeft.SetActive(true);
		this.modelRight.SetActive(true);

		StartCoroutine(SetTakeableAfterTime(this.timeBeforeTakeable));
	}

	private System.Collections.IEnumerator SetTakeableAfterTime(float time) {
		yield return new WaitForSeconds(time);
		this.trigger.enabled = true;
		this.takable = true;
	}

	protected void OnTriggerEnter(Collider other) {
		if (takable && other.tag == "Player")
			Take();
	}

	private Vector3 RandomVector(float min = -3, float max = 3) {
		return new Vector3(Random.Range(min, max),Random.Range(min, max),Random.Range(min, max));
	}

}