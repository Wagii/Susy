using UnityEngine;
using FMODUnity;

public class LoseColisSound : MonoBehaviour
{
    
	private FMOD.Studio.EventInstance instance;

	protected void Start() {
		this.instance = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.loseColisAlarm);
		RuntimeManager.AttachInstanceToGameObject(this.instance, this.transform, GetComponent<Rigidbody>());
    }

	public void StartSound() {
		this.instance.start();
	}
	
	public void StopSound() {
		this.instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
}
