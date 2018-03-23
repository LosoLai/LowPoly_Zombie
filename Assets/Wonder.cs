using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonder : DumbKidFSM {
	GameObject[] leaders;
	int currentLeader;

	void Awake()
	{
		leaders = GameObject.FindGameObjectsWithTag("SmartKid");
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		currentLeader = 0;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (leaders.Length == 0)
			return;
		
		Vector3 randomRange = new Vector3 (Random.Range(3.0f, -3.0f), Random.Range(0.3f, -0.3f), 0);
		Vector3 direction = leaders [currentLeader].transform.position - Kid.transform.position;
		direction += randomRange;

		Kid.transform.rotation = Quaternion.Slerp (Kid.transform.rotation,
												   Quaternion.LookRotation(direction),
												   1.0f * Time.deltaTime);
		Kid.transform.Translate (0, 0, Time.deltaTime * 0.8f);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}
}
