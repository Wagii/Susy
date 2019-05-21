using UnityEngine;
using FMODUnity;

public class ItemSillageSound : MonoBehaviour
{
	protected void OnEnable() {
		var instance = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.sillageSound);
		RuntimeManager.AttachInstanceToGameObject(instance, this.transform, GetComponent<Rigidbody>());
		instance.start();
		Destroy(this, 1f);
	}
}
