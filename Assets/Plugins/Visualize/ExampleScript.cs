using UnityEngine;
using FMOD.Studio;
using FMODUnity;

[RequireComponent(typeof(Rigidbody))]
// Derive from FMODSoundEmitter to be able to use the automatic wave getting script
public class ExampleScript : FMODSoundEmitter {
	[EventRef] [SerializeField] private string eventRef = "";
	//public EventInstance eventInstance; is already generated in FMODSoundEmitter
	public DataGetter masterWaveScript = null;
	
	private float[][] data { get { return masterWaveScript.data; } }
	
	protected void Awake() {
		this.eventInstance = RuntimeManager.CreateInstance(eventRef);
		RuntimeManager.AttachInstanceToGameObject(this.eventInstance, this.transform, this.GetComponent<Rigidbody>());
		this.eventInstance.start();
	}
	
	protected void Update() {
		if (data.Length < 1) return;
		if (data[0].Length < 1) return;
		
		for (int i = 0; i < data[0].Length; i++) {
			Debug.DrawLine(new Vector3(i*.01f, 0, 0), new Vector3(i*.01f, data[0][i]*5f, 0), Color.HSVToRGB(data[0][i], 1, 1));
		}
	}
}
