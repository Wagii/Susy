using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour {

	public static void ChangeTarget(Transform target) {
		foreach (var item in GameObject.FindObjectsOfType<Direction>())
			item.SetNewTarget(target);
	}

	public StartPoint activeQuest = null;
	public PlayerQuestStatus Status { get { return status; } private set { status = value; } }
	public float Timer { get { return timer; } }
	public float Score { get { return score; } }

	private List<StartPoint> quests = new List<StartPoint>();
	private PlayerQuestStatus status = PlayerQuestStatus.SEARCHING;
	public float timer = 0; // Now public
	public int score = 0; // Now public
	
	public bool moreThanTen = false;
	public bool hasColis = true;
	
	public TextFading[] gainPrompt;
	public int lastScoreGain { get; private set; }
	public float lastTimeGain { get; private set; }
	
	[SerializeField] private List<Text> times = null;
	[SerializeField] private List<Text> scores = null;

	protected void Start() {
		Manager.quest = this;
		this.quests = new List<StartPoint>(FindObjectsOfType<StartPoint>());
	}

	public void DisableButOneQuest (StartPoint activeQuest) {
		for (int i = 0; i < quests.Count; i++) {
			if (quests[i].status == QuestStatus.COMPLETE) continue;

			quests[i].QuestStatusChanged(QuestStatus.DISABLED);
		}
		activeQuest.QuestStatusChanged(QuestStatus.ACTIVE);
	}

	public void ReadyAllQuests () {
		foreach (var item in quests) {
			if (item.status == QuestStatus.COMPLETE) continue;

			item.QuestStatusChanged(QuestStatus.READY);
		}
	}

	public void StartQuest (StartPoint quest) {
		if (!this.hasColis) return;
		Status = PlayerQuestStatus.INQUEST;
		this.timer = quest.maxTime;
		this.activeQuest = quest;
		FindNearestQuest.nearestQuest.StopSearch();
		DisableButOneQuest(quest);
		ChangeTarget(quest.objective.checkpoint.transform);
		PlaySound(SoundType.Start);
		if (quest.maxTime > 10f)
			moreThanTen = true;
	}

	public bool Checkpoint () {
		this.lastTimeGain = (this.activeQuest.maxTime * (this.activeQuest.objective.checkpoint.percentTimeAdd/100));
		this.timer += this.lastTimeGain;
		
		foreach (var prompt in this.gainPrompt) {
			prompt.gameObject.SetActive(true);
			prompt.PingReward(time: true);
		}
		
		if (this.timer > 10f)
			moreThanTen = true;
		PlaySound(SoundType.Check);
		return this.activeQuest.Check();
	}

	public void EndQuest () {
		Status = PlayerQuestStatus.SEARCHING;
		this.lastScoreGain = (int)(activeQuest.score + (activeQuest.score * (this.timer/this.activeQuest.maxTime)));
		score += this.lastScoreGain;
		
		foreach (var prompt in this.gainPrompt) {
			prompt.gameObject.SetActive(true);
			prompt.PingReward(money: true);
		}
		
		foreach (var item in scores)
			item.text = this.score.ToString() + "u";
		
		
		this.activeQuest.QuestStatusChanged(QuestStatus.COMPLETE);
		ReadyAllQuests();
		ChangeTarget(null);
		FindNearestQuest.nearestQuest.StartSearch();
		this.activeQuest = null;
		PlaySound(SoundType.End);
	}

	public void LoseQuest() {
		this.activeQuest.QuestStatusChanged(QuestStatus.READY);
		ReadyAllQuests();
		ChangeTarget(null);
		FindNearestQuest.nearestQuest.StartSearch();
		
		this.activeQuest = null;
		this.status = PlayerQuestStatus.SEARCHING;
		
		ObjectifSound.objSound.Lose();
		
		this.GetComponentInChildren<ObjectifSound>().Reset();
	}

	protected void Update() {
		if (this.status == PlayerQuestStatus.INQUEST) {
			if (Manager.player.transform.position.IsCloseEnoughTo(this.activeQuest.objective.position, this.activeQuest.objective.validationRange) && this.hasColis) {
				if (Checkpoint()) {
					EndQuest();
					return;
				} else {
					ChangeTarget(activeQuest.objective.checkpoint.transform);
				}
			}

			this.timer -= Time.deltaTime;
			if (moreThanTen && this.timer <= 10f) {
				moreThanTen = false;
				TenSeconds.tensecs.Play();
			}
			foreach (var item in times)
				item.text = FloatToTime(this.timer);
			if (this.timer <= 0) {
				LoseQuest();
			}
		} else
			if (timer != 0) {
				timer = 0;
				foreach (var item in times)
					item.text = "--:--";
			}
	}
	
	
	
	
	
	private enum SoundType {
		Start,
		Check,
		End,
		Lost
	};
	
	private ObjectifSound objSound { get { return ObjectifSound.objSound; } }
	
	private void PlaySound (SoundType type) {
		switch (type)
		{
		case SoundType.Start:
			objSound.StartQuest();
			break;
		
		case SoundType.Check:
			objSound.StartQuest();
			break;
				
		case SoundType.End:
			objSound.EndQuest();
			break;
				
		case SoundType.Lost:
			objSound.LostColis();
			break;
				
		default:
			break;
		}
	}
	
	private string FloatToTime(float time) {
		int intTime = (int)time;
		return ((intTime/60<10?"0":"") + (intTime/60).ToString() +":"+(intTime%60<10?"0":"") + (intTime%60).ToString());
	}
}
