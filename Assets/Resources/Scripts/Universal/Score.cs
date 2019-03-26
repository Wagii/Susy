using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour {
	
	[SerializeField] private Text text = null;
	
	protected void Start() {
		this.text = GetComponent<Text>();
	}
	
	protected void Update() {
		this.text.text = "$"+Manager.quest.Score.ToString();
	}
}
