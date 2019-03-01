using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HeadColliderSize : MonoBehaviour
{
	[SerializeField] private SphereCollider headCollider = null;
    [Header("Speed on X, Size on Y")] [SerializeField] private AnimationCurve sizeCurve = null;
    [SerializeField] private float sizeGrowthRate = 5f;
    private float actualSpeed = 0;

    private void FixedUpdate()
    {
        if (Manager.player.velocity.magnitude == 0) return;
        this.actualSpeed = GoodEnough.Lerp(this.actualSpeed, Manager.player.velocity.magnitude, this.sizeGrowthRate * Time.deltaTime);
	    this.headCollider.radius = this.sizeCurve.Evaluate(this.actualSpeed);
    }
}
