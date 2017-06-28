using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potential : MonoBehaviour {

	private float rot = 0;

	private float speed = 2.0f;
	private float maxSpeed = 3.0f;
	private float minSpeed = .5f;

	float wait = 0;

	private float delta;
	private float lastTime;
	private float currentTime;

	void Start () {
		rot = Random.Range(0, 360);
		delta = 0;
	}

	void Update () {
		transform.Translate (0, speed * Time.deltaTime, 0);
		transform.localEulerAngles = new Vector3 (0, 0, rot);
		Debug.Log (speed);
		currentTime = Time.fixedTime - lastTime;
		if (currentTime >= delta) {
			speed = 0;
		}
		if (currentTime >= delta + wait) {
			ChangeDirection ();
		}
	}

	private void ChangeDirection() {
		wait = Random.Range (0f, 2.0f);
		rot = Random.Range (0, 360);
		delta = Random.Range (.05f, 2.0f);
		lastTime = Time.fixedTime;
		speed = Random.Range (minSpeed, maxSpeed);
	}
}
