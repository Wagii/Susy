using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffects : MonoBehaviour {

	public AudioSource collision;
	public ParticleSystem sparks;
	private ParticleSystem sparksInstance;

	public Transform stone;
	public Vector3 pos;

	public bool collided;
	public bool timerLocker;
	public float timer;
	public float delay;

	void Start(){
		//sparks = GetComponentInChildren<ParticleSystem>();
		collision = GetComponentInChildren<AudioSource>();
		stone = GetComponent<Transform>();
		timer = delay;
	}

	void Update(){
		pos = new Vector3 (stone.position.x, stone.position.y, stone.position.z);

		if(collided == true){
			timer -= 1 * Time.deltaTime;
		}

		if(timer < 0 && timerLocker == false){
			collided = false;
			timerLocker = true;
		}

		if(timerLocker == true){
			timer = delay;
			timerLocker = false;
		}


	}

	// Use this for initialization
	void OnCollisionEnter(){

		if(collided == false){
		collided = true;
		collision.Play(0);
		sparksInstance = Instantiate(sparks, pos, this.transform.rotation);
		sparksInstance.Play(true);
		}

	}


}
