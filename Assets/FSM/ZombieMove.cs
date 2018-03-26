using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour {
	private Rigidbody rb;
	public Vector3 circleCenter;
	public float circleDistance = 10.0f;


	public Vector3 displaceForce; 
	public float circleRadius = 20.0f;
	private float wanderAngle = 60.0f;
	public float rotateChange = 60.0f;

	private Vector3 wanderForce;

	public float maxspeed = 2.0f;


	//variables used for character facing
	public float rotateSpeed = 10.0f;
	public float rotateMag = 0.2f;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		wanderForce = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (Vector3.Distance (transform.position, wanderForce) < 0.5f) {
			WanderForce ();

		} else {
			//moves the character to the new position
			transform.position = Vector3.MoveTowards (transform.position, wanderForce, maxspeed * Time.deltaTime);

			//draws a line to show the target point in the Camera scene. Can delete this eventually
			Debug.DrawLine (transform.position, wanderForce, Color.yellow, 1);


			//character slowly faces towards new target direction 
			Vector3 targetDir = wanderForce - transform.position;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, rotateSpeed * Time.deltaTime, rotateMag);
			transform.rotation = Quaternion.LookRotation (newDir);
		}
	}

	void WanderForce(){
		circleCenter = transform.position + (transform.forward * circleDistance);
		Debug.DrawLine (transform.position, circleCenter, Color.red, 100.0f);
		//print ("Circle Center: " + circleCenter);

		displaceForce = new Vector3 (0.0f, 0.0f, 0.1f);
		displaceForce = displaceForce * circleRadius;

		float len = displaceForce.magnitude;
		displaceForce.x = Mathf.Cos (wanderAngle * (Mathf.PI / 180)) * len;
		displaceForce.z = Mathf.Sin (wanderAngle * (Mathf.PI / 180)) * len;

		//this is supposed to make sure that the new target point is never anywhere above/below ground
		//need to ask someone if there is a better solution for this one

		/*
		Debug.Log ("Y-pos: " + displaceForce.y);
		Debug.Log ("X-pos: " + displaceForce.x);
		Debug.Log ("Z-pos: " + displaceForce.z);
		*/

		//randomly calculates the wander angle for the next wander point
		wanderAngle += ((Random.Range (0.0f, rotateChange) - (rotateChange * 0.5f))) % 360;
		//print (wanderAngle);

		//adding up the circle position and displacement force for the wander point
		wanderForce = circleCenter + displaceForce;


		/*
		Debug.DrawLine (circleCenter, circleCenter + displaceForce, Color.green, 100.0f);
		Debug.DrawLine (transform.position, wanderForce, Color.blue, 100.0f);
		Debug.Log ("Wander-x-pos: " + wanderForce.x);
		Debug.Log ("Wander-y-pos: " + wanderForce.z);
		*/
	}
}
