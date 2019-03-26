[System.Serializable]
public class Sounds {
	public string name = "";
	public string collisionTag = "";
	[FMODUnity.EventRef] public string eventRef;
	public float soundVolume = 1;
	public float minimumValueToActivate = 0;
}
