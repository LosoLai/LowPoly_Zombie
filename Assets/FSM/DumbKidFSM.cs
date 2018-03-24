using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbKidFSM : StateMachineBehaviour {

	public GameObject Kid;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Kid = animator.gameObject;
	}
}
