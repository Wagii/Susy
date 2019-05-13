using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseColisOnCollision : MonoBehaviour
{
	[SerializeField] private Colis colis = null;
	[SerializeField] private float minimumSpeedToLoseColis = 500f;
	
	[SerializeField] private Image imgLeft = null, imgRight = null;
	
	private Rigidbody rb = null;
	
	protected void Awake() {
		this.rb = GetComponent<Rigidbody>();
	}
	
	protected void Update() {
		this.imgLeft.fillAmount = Manager.player.velocity.magnitude/minimumSpeedToLoseColis;
		this.imgRight.fillAmount = Manager.player.velocity.magnitude/minimumSpeedToLoseColis;
		
	}
	
	protected void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.relativeVelocity.magnitude >= minimumSpeedToLoseColis) {
			this.colis.Drop(collisionInfo);
		}
	}
}
