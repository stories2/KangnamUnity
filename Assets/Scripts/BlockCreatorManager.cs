using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreatorManager : MonoBehaviour {

	static readonly float CREATE_BLOCK_TIME_GAP = 3f, ZERO = 0f,
		CREATE_BLOCK_POS_X = 10f, CREATE_BLOCK_POS_Y = 1f;

	public GameObject blockPrefab;

	float currentTime, lastCreateTime;

	// Use this for initialization
	void Start () {
		currentTime = CREATE_BLOCK_TIME_GAP;
		lastCreateTime = ZERO;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (Time.deltaTime);
		CheckCreateTime();
	}

	void CheckCreateTime() {
		currentTime = currentTime + Time.deltaTime;
		if (currentTime - lastCreateTime > CREATE_BLOCK_TIME_GAP) {
			Vector3 createPos = Vector3.zero;
			createPos.y = Random.Range (-CREATE_BLOCK_POS_Y, CREATE_BLOCK_POS_Y);
			createPos.x = CREATE_BLOCK_POS_X;
			Instantiate (blockPrefab, createPos, transform.rotation);
			lastCreateTime = currentTime;
		}
	}
}
