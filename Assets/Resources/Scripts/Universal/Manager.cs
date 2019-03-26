using UnityEngine;

public class Manager : MonoBehaviour {
    // Static Accessors, DO NOT TOUCH
    public static Manager parameters;
	public static Rigidbody player;
	public static QuestManager quest;

    // Parameters
	public SlowParameters slowParameters;
	public PlayerMovementParameters playerMovementParameters;
	public ObjectMovementParameters objectMovementParameters;


    protected void Awake() {
		Manager.parameters = this;
		if (player == null) player = FindObjectOfType<Valve.VR.SteamVR_PlayArea>().GetComponent<Rigidbody>();
	}
}
