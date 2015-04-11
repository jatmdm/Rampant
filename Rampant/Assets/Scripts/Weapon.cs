using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float damage;
	public float damageMultiplier;

	public float defense;

	public Vector2 genderMinimum;
	public Vector2 genderMaximum;

	public bool phys;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float dealDamage(float enemyDefense){

		float baseDmg = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventurerStats>().baseDamage;
		float power = 0;
		float wit = 0;


		if(phys){
			power = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventurerStats>().power;
		}
		else{
			wit = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventurerStats>().wit;
		}
		float totalDamage = (damage*damageMultiplier) + baseDmg + (power*damageMultiplier) + (wit * damageMultiplier);

		return totalDamage;
	}
}
