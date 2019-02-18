using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

	public GameObject[] objectsList;
	public Vector3[] vectorsList;

	public GameObject exp1;
	public GameObject exp2;
	public GameObject exp3;
	public GameObject exp4;
	public GameObject exp5;
	public GameObject exp6;
	public GameObject exp7;
	public GameObject exp8;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.A)){
			exp1.gameObject.SetActive(true);
			exp2.gameObject.SetActive(false);
			exp3.gameObject.SetActive(false);
			exp4.gameObject.SetActive(false);
			exp5.gameObject.SetActive(false);
			exp6.gameObject.SetActive(false);
			exp7.gameObject.SetActive(false);
			exp8.gameObject.SetActive(false);
		}
		if(Input.GetKey(KeyCode.Z)){
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(true);
			exp3.gameObject.SetActive(false);
			exp4.gameObject.SetActive(false);
			exp5.gameObject.SetActive(false);
			exp6.gameObject.SetActive(false);
			exp7.gameObject.SetActive(false);
			exp8.gameObject.SetActive(false);
		}
		if(Input.GetKey(KeyCode.E)){
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(false);
			exp3.gameObject.SetActive(true);
			exp4.gameObject.SetActive(false);
			exp5.gameObject.SetActive(false);
			exp6.gameObject.SetActive(false);
			exp7.gameObject.SetActive(false);
			exp8.gameObject.SetActive(false);
		}
		if(Input.GetKey(KeyCode.R)){
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(false);
			exp3.gameObject.SetActive(false);
			exp4.gameObject.SetActive(true);
			exp5.gameObject.SetActive(false);
			exp6.gameObject.SetActive(false);
			exp7.gameObject.SetActive(false);
			exp8.gameObject.SetActive(false);
		}
		if(Input.GetKey(KeyCode.T)){
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(false);
			exp3.gameObject.SetActive(false);
			exp4.gameObject.SetActive(false);
			exp5.gameObject.SetActive(true);
			exp6.gameObject.SetActive(false);
			exp7.gameObject.SetActive(false);
			exp8.gameObject.SetActive(false);
		}

		if(Input.GetKey(KeyCode.Y)){
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(false);
			exp3.gameObject.SetActive(false);
			exp4.gameObject.SetActive(false);
			exp5.gameObject.SetActive(false);
			exp6.gameObject.SetActive(true);
			exp7.gameObject.SetActive(false);
			exp8.gameObject.SetActive(false);
		}

		if(Input.GetKey(KeyCode.U)){
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(false);
			exp3.gameObject.SetActive(false);
			exp4.gameObject.SetActive(false);
			exp5.gameObject.SetActive(false);
			exp6.gameObject.SetActive(false);
			exp7.gameObject.SetActive(true);
			exp8.gameObject.SetActive(false);
		}

		if(Input.GetKey(KeyCode.I)){
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(false);
			exp3.gameObject.SetActive(false);
			exp4.gameObject.SetActive(false);
			exp5.gameObject.SetActive(false);
			exp6.gameObject.SetActive(false);
			exp7.gameObject.SetActive(false);
			exp8.gameObject.SetActive(true);
		}
		
	}
}
