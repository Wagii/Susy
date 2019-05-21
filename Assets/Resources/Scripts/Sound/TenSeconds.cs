using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TenSeconds : MonoBehaviour
{
	public static TenSeconds tensecs = null;
	private FMOD.Studio.EventInstance instance;
	
	protected void Start() {
		tensecs = this;
		this.instance = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.tenSeconds);
		RuntimeManager.AttachInstanceToGameObject(this.instance, transform, Manager.player);
	}
	
	public void Play() {
		this.instance.start();
	}
	
}
