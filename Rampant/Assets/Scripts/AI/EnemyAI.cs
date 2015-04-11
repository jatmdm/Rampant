﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Vector2 targetPosition;
	public Vector2 dir = Vector2.zero;

	public float followDistance;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, this.gameObject.transform.position) < followDistance){
			targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		}
		if(targetPosition == null){
			dir = Vector2.zero;
		}
		else{
			dir = Vector2.Lerp(dir, this.GetComponent<Agent>().pathing(targetPosition, 1f), Time.fixedDeltaTime*10);
		}
		GetComponent<Rigidbody2D> ().MovePosition (GetComponent<Rigidbody2D> ().position + dir * 5 * Time.fixedDeltaTime);

	}
}
