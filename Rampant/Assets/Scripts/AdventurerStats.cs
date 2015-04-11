using UnityEngine;
using System.Collections;

public class AdventurerStats : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float maxStamina;
	public float stamina;
	public float staminaRegen;

	public int power; //Strength & Dexterity (Phys Damage)
	public int wit; //Intelligence & Wisdom (Magic Damage)
	public int vit; //Constitution  & Charisma (Health and Defense)

	public Vector2 gender; //x axis is feminitity, y axis is masculinity

	public float baseDamage; //Base damage done
	
	public float physicalDefense; //Damage Reduction (Physical)
	public float magicDefense; //Damage Reduction (Magic)

	public bool dead;


	// Use this for initialization
	void Start () {
		initStats();
		dead = false;
	}

	public void initStats(){
		power = Random.Range(1,4);
		wit = Random.Range (1,4);
		vit = Random.Range (1,4);

		maxHealth = vit*10f;
		stamina = health = maxStamina =  maxHealth;
		staminaRegen = (vit/2f)*Time.deltaTime;

		gender = new Vector2(Random.Range(0f, 6f), Random.Range(0f, 6f));

		baseDamage = (power*10f)*1.257f;
		physicalDefense = (power/2f) + (10f * vit);
		magicDefense = (wit/2f) + (8f * vit);
	}

	public void updateStats(){

	}



	public void takeDamage(float magicDmg, float physicalDmg){ //Phys is whether or not damage is physical or not
		float magicTaken = magicDmg-magicDefense;
		float physTaken = physicalDmg-physicalDefense;
		if(magicTaken > 0){
			health-= magicTaken;
		}
		if(physTaken > 0){
			health-= physTaken;
		}
	}

	// Update is called once per frame
	void Update () {
		if(health <= 0){
			dead = true;
		}
	}
}
