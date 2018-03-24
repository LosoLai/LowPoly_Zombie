using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonder_Zombies : ZombieFSM {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		randomRange = new Vector3 (Random.Range(10.0f, -10.0f), Random.Range(0.3f, -0.3f), 0);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//check is it timeout or not
		if (wonderWalkTime <= 0)
			isTimeout = true;

		if (!isTimeout) {
			wonderWalkTime -= Time.deltaTime;
		} else {
			//if time out, default setting
			randomRange.Set(Random.Range(10.0f, -10.0f), Random.Range(0.3f, -0.3f), 0);
			wonderWalkTime = WLAKTIME;
			isTimeout = false;
		}
			
		zombie.transform.rotation = Quaternion.Slerp (zombie.transform.rotation,
													  Quaternion.LookRotation(randomRange),
												 	  ROTSPEED * Time.deltaTime);
		zombie.transform.Translate (Vector3.forward * Time.deltaTime);
		//zombie.transform.Translate (0, 0, Time.deltaTime * SPEED);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}
}
