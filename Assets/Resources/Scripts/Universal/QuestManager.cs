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
	private float timer = 0;
	private int score = 0;
	
	public bool hasColis = true;
	
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
	}

	public bool Checkpoint () {
		this.timer += (this.activeQuest.maxTime * (this.activeQuest.objective.checkpoint.percentTimeAdd/100))/* + (activeQuest.maxTime * (timer/activeQuest.maxTime))*/;
		//ChangeTarget(activeQuest.objective.checkpoint.transform);
		PlaySound(SoundType.Check);
		return this.activeQuest.Check();
	}

	public void EndQuest () {
		Status = PlayerQuestStatus.SEARCHING;
		score += (int)(activeQuest.score + (activeQuest.score * (this.timer/this.activeQuest.maxTime)));
		
		
		foreach (var item in scores)
			item.text = this.score.ToString() + "$";
		
		
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
		this.GetComponentInChildren<ObjectifSound>().Reset();
	}

	protected void Update() {
		if (this.status == PlayerQuestStatus.INQUEST) {
			if (Manager.player.transform.position.IsCloseEnoughTo(this.activeQuest.objective.position, this.activeQuest.objective.validationRange) && this.hasColis) {
				Debug.Log((this.activeQuest.objective.position - Manager.player.position).magnitude);
				if (Checkpoint()) {
					EndQuest();
					return;
				} else {
					ChangeTarget(activeQuest.objective.checkpoint.transform);
				}
			}

			this.timer -= Time.deltaTime;
			foreach (var item in times)
				item.text = FloatToTime(this.timer);
			if (this.timer <= 0) {
				LoseQuest();
			}
		} else
			if (timer != 0) {
				timer = 0;
				foreach (var item in times)
					item.text = "00:00";
			}
	}
	
	
	
	
	
	private enum SoundType {
		Start,
		Check,
		End
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
				
		default:
			break;
		}
	}
	
	private string FloatToTime(float time) {
		int intTime = (int)time;
		return ((intTime/60<10?"0":"") + (intTime/60).ToString() +":"+(intTime%60<10?"0":"") + (intTime%60).ToString());
	}
}
