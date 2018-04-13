using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	static readonly float BLOCK_MOVE_SPEED = 2.0f,
		OUT_OF_SCREEN_X = -10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveCurrentObj (BLOCK_MOVE_SPEED);
		DestroyWhenObjectOutOfScreen ();
	}

	void MoveCurrentObj(float speed) {
		transform.Translate (Vector3.left * Time.deltaTime * speed);
	}

	void DestroyWhenObjectOutOfScreen() {
		Vector3 pos = gameObject.transform.position;
		if (pos.x < OUT_OF_SCREEN_X) {
			Destroy (gameObject);
		}
	}
}
