using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class Chrono : MonoBehaviour {
	private float Timer { get { return Manager.quest.Timer; } }
	
	[SerializeField] private Text text;
	
	protected void Start() {
		this.text = GetComponent<Text>();
	}
	
	protected void Update() {
		this.text.text = ToTimer();
	}
	
	private string ToTimer () {
		return (Timer/60 < 10 ? "0" : "") 
			+ ((int)Timer/60).ToString() 
			+ " : "
			+ (Timer%60 < 10 ? "0" : "")
			+ (Math.Truncate((Timer%60)*100)/100).ToString();
	}
}
