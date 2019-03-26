using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Sillage : MonoBehaviour
{
	[SerializeField] private SphereCollider sillageCollider = null;
    [Header("Speed on X, Size on Y")] [SerializeField] private AnimationCurve sizeCurve = null;
    [SerializeField] private float sizeGrowthRate = .1f;
    [SerializeField] private float objectSpeedMultiplier = 1f;
    private float actualSpeed = 0;

    private void Awake()
    {
        this.sillageCollider.isTrigger = true;
        this.sillageCollider.enabled = false;
        if (sizeCurve.length == 0)
            DestroyImmediate(this);
    }

    private void FixedUpdate()
    {
        if (Manager.player.velocity.magnitude < sizeCurve.keys[0].time)
        {
	        if (this.sillageCollider.enabled) 
		        this.sillageCollider.enabled = false;
            return;
        } else if (!this.sillageCollider.enabled)
	        this.sillageCollider.enabled = true;
	        
        this.actualSpeed = Mathf.Lerp(this.actualSpeed, Manager.player.velocity.magnitude, this.sizeGrowthRate);
        this.sillageCollider.radius = this.sizeCurve.Evaluate(this.actualSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.velocity += ((this.transform.position - rb.position).normalized * Manager.player.velocity.magnitude * this.objectSpeedMultiplier) - Manager.player.velocity.normalized;
    }
}
