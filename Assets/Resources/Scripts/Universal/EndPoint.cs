using UnityEngine;
using UnityEngine.Events;

public class EndPoint : Checkpoint
{
	protected new void Awake() {
		base.Awake();
		this.next = null;
	}
	
	protected new void OnTriggerEnter(Collider other) {
		if (previous.passed && !this.passed) {
			this.passed = true;
			this.check.Invoke();
		}
	}
}
