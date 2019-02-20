using UnityEngine;

public class thingtest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(GetComponent<Valve.VR.SteamVR_Behaviour_Pose>().origin.position);
        Debug.Log(GetComponent<Valve.VR.SteamVR_Behaviour_Pose>().transform.localPosition);
    }
}
