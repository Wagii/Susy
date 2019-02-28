using UnityEngine;
using UnityEngine.Events;

public class Start : Checkpoint
{
	protected new void Awake() {
		base.Awake();
		this.previous = null;
	}
	
	protected new void OnTriggerEnter(Collider other) {
		if (!this.check) {
			this.passed = true;
			this.check.Invoke();
		}
	}
}
