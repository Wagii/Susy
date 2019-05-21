using UnityEngine;
using FMODUnity;

public class ObjectifSound : MonoBehaviour {
	public static ObjectifSound objSound;
	private FMOD.Studio.EventInstance sound;
	private FMOD.Studio.EventInstance lost;
	
	protected void Start() {
		ObjectifSound.objSound = this;
		this.sound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.objectif_manager);
		RuntimeManager.AttachInstanceToGameObject(this.sound, this.transform, Manager.player);
		this.lost = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.loseQuest);
		RuntimeManager.AttachInstanceToGameObject(this.lost, this.transform, Manager.player);
		this.sound.start();
	}
	
	protected void Update() {
		if (Manager.quest.activeQuest == null) return;
		
		this.sound.setParameterValue("distance", Manager.parameters.soundParameters.dist.Evaluate(Mathf.Abs((Manager.quest.activeQuest.objective.position - this.transform.position).magnitude)));
	}
	
	public void StartQuest() {
		StartCoroutine(ForOneFrame());
		this.sound.setParameterValue("objectif", 0);
	}
	
	private System.Collections.IEnumerator ForOneFrame() {
		this.sound.setParameterValue("objectif_rec", 1);
		yield return null;
		this.sound.setParameterValue("objectif_rec", 0);
	}
	
	public void EndQuest() {
		this.sound.setParameterValue("objectif", 1);
	}
	
	public void LostColis() {
		this.sound.setParameterValue("lost", 1);
	}
	
	public void GetColis() {
		this.sound.setParameterValue("lost", 0);
	}
	
	public void Lose() {
		this.lost.start();
	}
	
	public void Reset() {
		this.sound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		this.sound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.objectif_manager);
		RuntimeManager.AttachInstanceToGameObject(this.sound, this.transform, Manager.player);
		this.sound.start();
	}
}
