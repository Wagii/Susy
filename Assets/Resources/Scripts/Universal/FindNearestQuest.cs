using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Direction))]
public class FindNearestQuest : MonoBehaviour {
	
	public static FindNearestQuest nearestQuest = null;
	
	private Coroutine routine;
	private List<StartPoint> starts;
	
	protected void Start() {
		FindNearestQuest.nearestQuest = this;
		starts = new List<StartPoint>(FindObjectsOfType<StartPoint>());
	}
	
	public void StartSearch () {
		if (routine == null) StartCoroutine(GetStarts());
	}
	
	public void StopSearch () {
		StopCoroutine(routine);
		routine = null;
	}
	
	private IEnumerator GetStarts() {
		if (starts.Count == 0) yield break;
		var minDist = (starts[0].transform.position - transform.position).magnitude;
		var dist = minDist;
		var nearest = starts[0];
		while(true) {
			for (int i = 0; i < starts.Count; i++) {
				if (starts[i].status != QuestStatus.READY) continue;
				dist = (starts[i].transform.position - transform.position).magnitude;
				if (dist < minDist) {
					nearest = starts[i];
					minDist = dist;
				}
			}
			QuestManager.ChangeTarget(nearest.transform);
			yield return new WaitForSeconds(1f);
		}
	}
}
