using UnityEngine;

public class InputSlow : MonoBehaviour {
	public static InputSlow inputSlow;
	private Slower slow = null;
	private float baseSlowMultiplier = 0;
	public float slowPower = 50f;
	private float speedToReturnToZero = 200f;

	private void Start() {
		InputSlow.inputSlow = this;
		this.slow = Manager.player.GetComponent<Slower>();
		this.speedToReturnToZero = 4f*this.slowPower;
		this.baseSlowMultiplier = this.slow.localSlowMultiplier;
	}

	protected void FixedUpdate() {
		this.slow.localSlowMultiplier = GoodEnough.Lerp(this.slow.localSlowMultiplier, this.baseSlowMultiplier, this.speedToReturnToZero * Time.deltaTime);
	}
}
