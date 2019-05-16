using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourneQ : MonoBehaviour
{
	[ColorUsageAttribute(true,true)]
	public Color active, disable;
	protected Renderer[] rds = null;
	
	protected void Start() {
		rds = GetComponentsInChildren<Renderer>();
	}
	
	protected void Update()
    {
	    transform.Rotate(0,1,0); 
    }
    
	public void No() {
		foreach (var item in rds)
			item.enabled = false;
	}
	
	public void Yes() {
		foreach (var item in rds) {
			item.enabled = true;
			item.material.SetColor("_EmissionColor", active);
		}
	}
	
	public void Matte() {
		foreach (var item in rds)
			item.material.SetColor("_EmissionColor", disable);
	}
	
	public void Stroy() {
		Destroy(gameObject);
	}
}
