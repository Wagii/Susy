using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class SillageMeshCollider : MonoBehaviour
{
	[SerializeField] private MeshCollider meshCollider = null;
	[Header("Speed on X, Size on Y")] [SerializeField] private AnimationCurve sizeCurve = null;
	[Range(0,1000)][SerializeField] private float sizeGrowthRate = .1f;
	[SerializeField] private float objectSpeedMultiplier = 1f;
	[Space]
	[Header("Value for the transfer 3Dmodel->Unity (import scale)")]
	[SerializeField] private float importScale = 1;
	private float actualSpeed = 0;
	
	private void Awake()
	{
		this.meshCollider.isTrigger = true;
		this.meshCollider.enabled = false;
		if (sizeCurve.length == 0)
			DestroyImmediate(this);
	}

	private void FixedUpdate()
	{
		if (Manager.player.velocity.magnitude < sizeCurve.keys[0].time)
		{		
			if (this.meshCollider.enabled) 
				this.meshCollider.enabled = false;
			this.meshCollider.transform.localScale = Vector3.one * importScale;
			return;
		} else if (!this.meshCollider.enabled)
			this.meshCollider.enabled = true;
	        
		// TODO : Fix speed Lerp to make the collider grow organically
		this.actualSpeed = GoodEnough.Lerp(this.actualSpeed, Manager.player.velocity.magnitude, this.sizeGrowthRate * Time.deltaTime);
		
		this.meshCollider.transform.localScale = Vector3.one * this.sizeCurve.Evaluate(this.actualSpeed) * importScale;
		this.meshCollider.transform.LookAt(this.transform.position + Manager.player.velocity, Vector3.up);
	}
	

	private void OnTriggerEnter(Collider other)
	{
		Rigidbody rb = other.GetComponent<Rigidbody>();
		Slower sl = other.GetComponent<Slower>();
		if (rb == null || sl == null) return;
		
		//rb.AddForce(((this.transform.position - rb.position).normalized * Manager.player.velocity.magnitude * this.objectSpeedMultiplier) - Manager.player.velocity.normalized, ForceMode.Impulse);
		rb.velocity += ((this.transform.position - rb.position).normalized * Manager.player.velocity.magnitude * this.objectSpeedMultiplier) - Manager.player.velocity.normalized;
		other.gameObject.AddComponent<ItemSillageSound>();
	}
}
