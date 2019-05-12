using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColisOnCollision : MonoBehaviour
{
	[SerializeField] private Colis colis = null;
	[SerializeField] private float minimumSpeedToLoseColis = 500f;
	
	protected void OnCollisionEnter(Collision collisionInfo) {
		if (Manager.player.velocity.magnitude < minimumSpeedToLoseColis) return;
		
		this.colis.Drop();
	}
}
