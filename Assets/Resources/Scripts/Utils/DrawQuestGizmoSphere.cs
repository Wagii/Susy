using UnityEngine;

public class DrawQuestGizmoSphere : MonoBehaviour {
	[SerializeField] private StartPoint quest = null;
	private int posInQuest = 0;
	
	protected void OnValidate() {
		if (this.quest == null) return;
		
		for (posInQuest = 0; posInQuest < quest.checkpoints.Count; posInQuest++)
			if (this.transform == quest.checkpoints[posInQuest].transform)
				break;
	}
	
	protected void OnDrawGizmos() {
		if (this.quest == null) return;
		if (GetComponent<StartPoint>()){
			Gizmos.color = Color.cyan;
			Gizmos.DrawSphere(this.transform.position, GetComponent<SphereCollider>().radius);
			return;
		}
	
		Gizmos.color = (posInQuest == quest.checkpoints.Count - 1)? Color.magenta : Color.yellow;
		Gizmos.DrawSphere(this.transform.position, quest.checkpoints[posInQuest].validationRange);
	}
}
