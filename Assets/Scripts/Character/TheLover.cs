using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLover : MonoBehaviour {

	private const float baseSpeed = 6.0f;
	private const float rotSens = 9.0f;

	[SerializeField] private GameObject testSpritePrefab;
	private GameObject testSprite;

	private CharacterController lover;

	void Start() {
		lover = GetComponent<CharacterController> ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		// lover movement
		float movY = Input.GetAxis ("Vertical") * baseSpeed;
		float movX = Input.GetAxis ("Horizontal") * baseSpeed;

		Vector3 mov = new Vector3 (movX, movY, 0);
		mov = Vector3.ClampMagnitude (mov, baseSpeed);
		mov *= Time.deltaTime;

		lover.Move (mov);

		// lover rotation
		float rot = Input.GetAxis("Mouse X") * rotSens;
		transform.Rotate(0, 0, -rot);

		// wind time
		if (Input.GetMouseButtonDown(0)) {
			testSprite = Instantiate (testSpritePrefab) as GameObject;
			testSprite.transform.position = transform.TransformPoint(transform.forward * 1.5f);
			testSprite.transform.rotation = transform.rotation;
			RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up);
			if (hit.collider) {
				Debug.Log("hit");
			}
		}

		if (testSprite) {
			testSprite.transform.Translate (0, 1.0f * Time.deltaTime, 0);
		}
	}
}
