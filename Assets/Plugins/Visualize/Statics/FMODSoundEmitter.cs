// Use this on all your visualizer scripts
// Or even all your FMOD scripts
public abstract class FMODSoundEmitter : UnityEngine.MonoBehaviour {
	public virtual FMOD.Studio.EventInstance eventInstance { get; set; }
}
