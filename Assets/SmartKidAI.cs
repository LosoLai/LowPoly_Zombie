using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartKidAI : MonoBehaviour {
	Animator animator;
	public GameObject player;

	public GameObject GetPlayer ()
	{
		return player;
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		animator.SetFloat ("distance", Vector3.Distance(transform.position, player.transform.position));
	}

	void OnCollisionEnter(Collision collisionInfo){
		Debug.Log ("Detect collision between" + gameObject.name + "&" + collisionInfo.gameObject.name);
	}

	void OnCollisionStay(Collision collisionInfo){
		Debug.Log ("Detect collision between" + gameObject.name + "&" + collisionInfo.gameObject.name);
	}
}
