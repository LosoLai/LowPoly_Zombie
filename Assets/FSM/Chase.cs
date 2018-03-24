﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : SmartKidFSM {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(Vector3.Distance(opponent.transform.position, Kid.transform.position) < 1.0f)
			return;

		var direction = opponent.transform.position - Kid.transform.position;
		Kid.transform.rotation = Quaternion.Slerp (Kid.transform.rotation,
												   Quaternion.LookRotation(direction),
												   ROTSPEED * Time.deltaTime);
		Kid.transform.Translate (0, 0, Time.deltaTime * SPEED);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}

}
