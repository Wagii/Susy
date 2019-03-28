using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class StartPoint : MonoBehaviour
{
	[Header("Collider needs to be triggered")]
	[SerializeField]private Collider startCollider = null;
	
	[Space]
	
	[HideInInspector] public QuestStatus status = QuestStatus.READY;
	[HideInInspector] public Next objective = new Next();
	
	public List<Checkpoint> checkpoints = new List<Checkpoint>();
	
	public float maxTime = 0.001f, score = 0;
	
	protected void Start() {
		maxTime = (maxTime == 0)? 0.001f : maxTime;
		if (this.checkpoints.Count == 0) {
			Destroy(this);
			return;
		}
		if (this.startCollider == null) return;
		this.startCollider.isTrigger = true;
	}
	
	public void QuestStatusChanged (QuestStatus status) {
		this.status = status;
		
		switch (status) {
		case QuestStatus.ACTIVE:
			this.startCollider.enabled = false;
			this.objective.checkpoint = checkpoints[0];
			this.objective.number = 0;
			break;
			
		case QuestStatus.COMPLETE:
			this.startCollider.enabled = false;
			this.objective = new Next();
			this.enabled = false;
			break;
			
		case QuestStatus.DISABLED:
			this.startCollider.enabled = false;
			break;
			
		case QuestStatus.READY:
			this.startCollider.enabled = true;
			break;
			
		default:
			break;
		}
	}
	
	public bool Check () {
		if (++this.objective.number < this.checkpoints.Count)
			this.objective.checkpoint = this.checkpoints[this.objective.number];
		return (this.objective.number >= this.checkpoints.Count);
	}
	
	protected void OnTriggerEnter(Collider other) {
		if (this.status != QuestStatus.READY && Manager.quest.Status == PlayerQuestStatus.SEARCHING) return;
		
		if (other.tag == "Player") {
			Manager.quest.StartQuest(this);
			Manager.quest.DisableButOneQuest(this);
		}
	}
	
	public void ObjectiveReset () {
		this.objective.checkpoint = checkpoints[0];
		this.objective.number = 0;
	}
}
