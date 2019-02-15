using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using Valve.VR;

public class Player_Movement : MonoBehaviour
{
	private Vector3 position, pressPosition;

	public void UpdatePosition(SteamVR_Behaviour_Pose pos, SteamVR_Input_Sources sources)
	{
		this.position = pos.poseAction.localPosition;
	}

	public void Press(SteamVR_Behaviour_Boolean pressType, SteamVR_Input_Sources sources, bool press)
	{
		this.pressPosition = this.position;
	}

	public void Release(SteamVR_Behaviour_Boolean pressType, SteamVR_Input_Sources sources, bool press)
	{
		Debug.Log(this.position - this.pressPosition);
		var player = GetComponent<Rigidbody>();
		if (this.position == this.pressPosition) return;
//		player.AddForce(this.position - this.pressPosition);
		this.pressPosition = Vector3.zero;
	}
}
