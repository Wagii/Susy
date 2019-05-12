using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Renderer))]
public class StartPoint : MonoBehaviour
{
	public const string SHADERFRESNELCOLOR = "_FresnelColor";
	
	[Header("Collider needs to be triggered")]
	[SerializeField]private Collider startCollider = null;
	
	private Renderer rd = null;
	
	[Space]
	
	public QuestStatus status = QuestStatus.READY;
	[HideInInspector] public Next objective = new Next();
	
	public List<Checkpoint> checkpoints = new List<Checkpoint>();
	
	public float maxTime = 0.001f, score = 0;
	
	[ColorUsageAttribute(true,true)]public Color readyColor;
	[ColorUsageAttribute(true,true)]public Color activeColor;
	[ColorUsageAttribute(true,true)]public Color disabledColor;
	[ColorUsageAttribute(true,true)]public Color completeColor;
	
	protected void Start() {
		maxTime = (maxTime == 0)? 0.001f : maxTime;
		if (this.checkpoints.Count == 0) {
			Destroy(this);
			return;
		}
		if (this.startCollider == null) return;
		this.startCollider.isTrigger = true;
		this.objective.number = 0;
		this.objective.checkpoint = checkpoints[0];
		
		this.rd = GetComponent<Renderer>();
		this.rd.materials[0].SetColor(SHADERFRESNELCOLOR, (status == QuestStatus.ACTIVE? activeColor : status== QuestStatus.COMPLETE? completeColor : status == QuestStatus.DISABLED? disabledColor : readyColor));
	}
	
	public void QuestStatusChanged (QuestStatus status) {
		this.status = status;
		
		this.rd = GetComponent<Renderer>();
		
		switch (status) {
		case QuestStatus.ACTIVE:
			this.startCollider.enabled = false;
			this.objective.checkpoint = checkpoints[0];
			this.objective.number = 0;
			
			this.rd.materials[0].SetColor(SHADERFRESNELCOLOR, this.activeColor);
			
			break;
			
		case QuestStatus.COMPLETE:
			this.startCollider.enabled = false;
			this.objective = new Next();
			
			this.rd.materials[0].SetColor(SHADERFRESNELCOLOR, this.completeColor);
			
			this.enabled = false;
			break;
			
		case QuestStatus.DISABLED:
			this.startCollider.enabled = false;
			
			this.rd.materials[0].SetColor(SHADERFRESNELCOLOR, this.disabledColor);
			
			break;
			
		case QuestStatus.READY:
			this.startCollider.enabled = true;
			
			this.rd.materials[0].SetColor(SHADERFRESNELCOLOR, this.readyColor);
			
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
		if (this.status != QuestStatus.READY || Manager.quest.Status != PlayerQuestStatus.SEARCHING || other.tag != "Player") return;
		Manager.quest.StartQuest(this);
	}
	
	public void ObjectiveReset () {
		this.objective.checkpoint = checkpoints[0];
		this.objective.number = 0;
	}
}
