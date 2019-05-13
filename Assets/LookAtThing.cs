using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtThing : MonoBehaviour
{
	[SerializeField] private Transform target = null;
	
	protected void Update()
    {
	    this.transform.LookAt(this.target);
    }
}
