using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFading : MonoBehaviour {

	public QuestManager questManager;
	
	public ParticleSystem success;
	public Text reward;
	public float delay = 1f;
	
	void Start(){
		reward = this.GetComponent<Text>();
	}

	public void PingReward (bool money = false, bool time = false) {
		if (money == true)
			reward.text = "+" + questManager.lastScoreGain.ToString() + "u";
		

		if (time == true)
			reward.text = "+" + questManager.lastTimeGain.ToString() + "s";
		
		
		StartCoroutine (Delay ());
	}


	IEnumerator Delay (){
		StartCoroutine (FadeIn(1f, GetComponent<Text>()));
		yield return new WaitForSeconds (delay);
		StartCoroutine (FadeOut (1f, GetComponent<Text>()));
	}


	IEnumerator FadeIn(float t, Text i){

		i.color = new Color (i.color.r, i.color.g, i.color.b, 0);

		while (i.color.a < 1f) {
			i.color = new Color (i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime/t));
			yield return null;
		}

	}

		IEnumerator FadeOut(float t, Text i){

		i.color = new Color (i.color.r, i.color.g, i.color.b, 1);

		while (i.color.a > 0f) {
			i.color = new Color (i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime/t));
			yield return null;

		}

		if(i.color.a <= 0){
			this.gameObject.SetActive(false);
		}
			
	}


		
}
