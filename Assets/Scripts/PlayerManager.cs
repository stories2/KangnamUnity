using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	static readonly float PLAYER_JUMP_TRUST = 10.0f,
		PLAYER_OUT_OF_SCREEN_Y = -10f;
	Rigidbody rigidbodyManager;

	// Use this for initialization
	void Start () {
		rigidbodyManager = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckJump (PLAYER_JUMP_TRUST);
		DestroyWhenOutOfScreen ();
	}

	void CheckJump(float trust) {
		if (Input.GetKeyDown (KeyCode.Space)) {
//			rigidbodyManager.AddForce (Vector3.up * trust);
			rigidbodyManager.velocity = Vector3.up * trust;
		}
	}

	void DestroyWhenOutOfScreen() {
		Vector3 pos = gameObject.transform.position;
		if (pos.y < PLAYER_OUT_OF_SCREEN_Y) {
			Destroy (gameObject);
			ResetGame ();
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		switch (otherObj.gameObject.tag) {
		case "Block":
			ResetGame ();
			break;
		default:
			Debug.Log ("coll: " + otherObj.gameObject.tag);
			break;
		}
	}

	void ResetGame() {
		SceneManager.LoadScene ("HW1");
	}
}
