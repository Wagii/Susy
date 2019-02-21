using UnityEngine;
using Valve.VR;

public class Test : MonoBehaviour
{
	public Rigidbody rb;
	
	protected void Awake() {
		this.rb = GetComponent<Rigidbody>();
	}
}
