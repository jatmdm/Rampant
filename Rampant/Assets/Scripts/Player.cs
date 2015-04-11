using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject weapon;
	public float sBounce;
	public float weaponDist = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		sBounce = Mathf.Lerp (sBounce, 0, Time.fixedDeltaTime * 5);

		if(Input.GetMouseButton(0))
		{
			sBounce = 360;
			weapon.SetActive(true);
		}
		else
		{
			weapon.SetActive(false);
		}
	
		float cameraDif = Camera.main.transform.position.y - transform.position.y;
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector2 mWorldPos = Camera.main.ScreenToWorldPoint( new Vector3(mouseX, mouseY, cameraDif));
		Vector2 mainPos = transform.position;
		
		float diffX = mWorldPos.x - mainPos.x;
		float diffY = mWorldPos.y - mainPos.y;

		Vector2 dist = new Vector2(Mathf.Cos(Mathf.Atan2 (diffY, diffX)-(sBounce)*Mathf.Deg2Rad)*weaponDist, Mathf.Sin(Mathf.Atan2 (diffY, diffX)-(sBounce)*Mathf.Deg2Rad)*weaponDist);
		weapon.GetComponent<Rigidbody2D> ().MovePosition ((Vector2)this.transform.position+dist);

		weapon.transform.rotation = Quaternion.Lerp(weapon.transform.rotation, Quaternion.Euler(0, 0, Mathf.Rad2Deg*Mathf.Atan2 (diffY, diffX)+90+sBounce), Time.fixedDeltaTime*10);
	}
}
