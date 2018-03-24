using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSM : StateMachineBehaviour {
	public static float WLAKTIME = 0.5f;
	public static float ROTSPEED = 1.0f;
	public static float SPEED = 0.95f;

	public GameObject zombie;
	public bool isTimeout;
	public float wonderWalkTime = WLAKTIME;
	public Vector3 randomRange;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		zombie = animator.gameObject;
	}
}
