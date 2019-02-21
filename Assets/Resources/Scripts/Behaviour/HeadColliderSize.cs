using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HeadColliderSize : MonoBehaviour
{
    [SerializeField] private SphereCollider collider;
    [Header("Speed on X, Size on Y")] [SerializeField] private AnimationCurve sizeCurve;
    [SerializeField] private float sizeGrowthRate = .1f;
    private float actualSpeed = 0;

    private void FixedUpdate()
    {
        if (Manager.player.velocity.magnitude == 0) return;
        this.actualSpeed = Mathf.Lerp(this.actualSpeed, Manager.player.velocity.magnitude, this.sizeGrowthRate);
        this.collider.radius = this.sizeCurve.Evaluate(this.actualSpeed);
    }
}
