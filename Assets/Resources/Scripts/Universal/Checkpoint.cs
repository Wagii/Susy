using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
	public UnityEvent check;
	public bool passed { get; private set; }
	
	protected void Awake() {
		this.passed = false;
	}
	
	public Checkpoint previous, next;
	
	protected void OnTriggerEnter(Collider other) {
		if (this.previous.passed && !this.check) {
			this.passed = true;
			this.check.Invoke();
		}
	}
}
