using UnityEngine;
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
	private float score = 0;

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

	//private void SetNextDestination(int i) {
	//	if (i < this.activeQuest.checkpoints.Count) {
	//		this.objective.number = i;
	//		this.objective.transform = this.activeQuest.checkpoints[i].transform;
	//	} else {
	//		this.objective.number = -1;
	//		this.objective.transform = this.activeQuest.end.transform;
	//	}
	//	ChangeTarget(this.objective.transform);
	//}

	//private void SetNextDestination() {
	//	if (this.objective.number + 1 < this.activeQuest.checkpoints.Count) {
	//		this.objective.number++;
	//		this.objective.transform = this.activeQuest.checkpoints[this.objective.number].transform;
	//	} else {
	//		this.objective.number = -1;
	//		this.objective.transform = this.activeQuest.end.transform;
	//	}
	//	ChangeTarget(this.objective.transform);
	//}

	public void StartQuest (StartPoint quest) {
		Status = PlayerQuestStatus.INQUEST;
		this.timer = quest.maxTime;
		this.activeQuest = quest;
		FindNearestQuest.nearestQuest.StopSearch();
		DisableButOneQuest(quest);
	}

	public bool Checkpoint () {
		this.timer += (this.activeQuest.maxTime * this.activeQuest.objective.checkpoint.percentTimeAdd) + (activeQuest.maxTime * (timer/activeQuest.maxTime));
		return this.activeQuest.Check();

	}

	public void EndQuest () {
		Status = PlayerQuestStatus.SEARCHING;
		score += activeQuest.score + (activeQuest.score * (this.timer/this.activeQuest.maxTime));
		this.activeQuest.QuestStatusChanged(QuestStatus.COMPLETE);
		ReadyAllQuests();
		ChangeTarget(null);
		FindNearestQuest.nearestQuest.StartSearch();
	}

	protected void Update() {
		if (this.status == PlayerQuestStatus.INQUEST) {
			if (Manager.player.position.IsCloseEnoughTo(this.activeQuest.objective.position, this.activeQuest.objective.validationRange)) {
				if (Checkpoint()) {
					EndQuest();
					return;
				}
			}

			this.timer -= Time.deltaTime;
			if (this.timer <= 0) {
				this.activeQuest.ObjectiveReset();
				this.activeQuest.QuestStatusChanged(QuestStatus.READY);
				this.activeQuest = null;
			}
		}
	}
}
