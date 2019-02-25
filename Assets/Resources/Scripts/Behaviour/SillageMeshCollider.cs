using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class SillageMeshCollider : MonoBehaviour
{
	[SerializeField] private MeshCollider collider;
	[SerializeField] private Transform cam;
	[Header("Speed on X, Size on Y")] [SerializeField] private AnimationCurve sizeCurve;
	[SerializeField] private float sizeGrowthRate = .1f;
	[SerializeField] private float objectSpeedMultiplier = 1f;
	[Space]
	[Header("Value for the transfer 3Dmodel->Unity (import scale)")]
	[SerializeField] private float importScale = 1;
	private float actualSpeed = 0;

	private void Awake()
	{
		this.collider.isTrigger = true;
		this.collider.enabled = false;
		if (sizeCurve.length == 0)
			DestroyImmediate(this);
	}

	private void FixedUpdate()
	{
		if (Manager.player.velocity.magnitude < sizeCurve.keys[0].time)
		{		
			if (this.collider.enabled) 
				this.collider.enabled = false;
			this.collider.transform.localScale = Vector3.one;
			return;
		} else if (!this.collider.enabled)
			this.collider.enabled = true;
	        
		// TODO : Fix speed Lerp to make the collider grow organically
		this.actualSpeed = Mathf.Lerp(this.actualSpeed, Manager.player.velocity.magnitude, Time.deltaTime);
		
		this.collider.transform.localScale = Vector3.one * this.sizeCurve.Evaluate(this.actualSpeed) * importScale;
		this.collider.transform.LookAt(this.transform.position + Manager.player.velocity, Vector3.up);
	}

	private void OnTriggerEnter(Collider other)
	{
		Rigidbody rb = other.GetComponent<Rigidbody>();
		if (rb == null) return;
		rb.velocity += ((this.transform.position - rb.position).normalized * Manager.player.velocity.magnitude * this.objectSpeedMultiplier) - Manager.player.velocity.normalized;
	}
}
