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

		// lover rotation
		float rot = Input.GetAxis("Mouse X") * rotSens;

		if (testSprite == null) {
			lover.Move (mov);
			transform.Rotate (0, 0, -rot);

			// wind time
			if (Input.GetMouseButtonDown (0)) {
				testSprite = Instantiate (testSpritePrefab) as GameObject;
				testSprite.transform.position = transform.TransformPoint (0, .1f, 0);
				testSprite.transform.rotation = transform.rotation;
				RaycastHit2D hit = Physics2D.CircleCast (transform.position, 2.0f, transform.up, 2.0f);
				if (hit.collider) {
                    if (hit.transform.gameObject.GetComponent<Potential>()) {
                        Debug.Log("Test");
                    }
				}
			}
		}

		if (testSprite) {
			float scale = Random.Range (1.0f, 4.0f);
			testSprite.transform.localScale = new Vector3(scale, scale, 0);
			StartCoroutine (EndScream ());
		}
	}

	private IEnumerator EndScream()	{
		yield return new WaitForSeconds (1.0f);
		Destroy (testSprite);
	}
}
