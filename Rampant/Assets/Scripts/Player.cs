using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject weapon;
	public float sBounce;
	public float weaponDist = 1;
	private float sheathCoolDown;
	private bool Unsheathed;
	public Vector2 vel;
	private float speed;
	private float fakeMax;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 8);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		sheathCoolDown -= Time.fixedDeltaTime;
		sBounce = Mathf.Lerp (sBounce, 0, Time.fixedDeltaTime * 5);

		vel = Vector2.Lerp (vel, Vector2.zero, Time.fixedDeltaTime * 3);

		if(Input.GetKey(KeyCode.W))
		{
			vel.y = Mathf.Lerp(vel.y, 1, Time.fixedDeltaTime*5);
		}
		if(Input.GetKey(KeyCode.S))
		{
			vel.y = Mathf.Lerp(vel.y, -1, Time.fixedDeltaTime*5);
		}
		if(Input.GetKey(KeyCode.D))
		{
			vel.x = Mathf.Lerp(vel.x, 1, Time.fixedDeltaTime*5);
		}
		if(Input.GetKey(KeyCode.A))
		{
			vel.x = Mathf.Lerp(vel.x, -1, Time.fixedDeltaTime*5);
		}

		GetComponent<Rigidbody2D> ().MovePosition (GetComponent<Rigidbody2D> ().position + (vel * (fakeMax) * Time.fixedDeltaTime));

		if(Unsheathed)
		{
			if(!weapon.activeSelf) 
			{
				sBounce = 360;
			}
			weapon.SetActive(true);
			fakeMax = Mathf.Lerp(fakeMax, maxSpeed*.65f, Time.fixedDeltaTime*5);
		}
		else
		{
			fakeMax = Mathf.Lerp(fakeMax, maxSpeed, Time.fixedDeltaTime*5);
			weapon.SetActive(false);
		}

		if(Input.GetMouseButtonDown(0) && sheathCoolDown < 0)
		{
			Unsheathed = !Unsheathed;
			sheathCoolDown = 1;
		}
	
		float cameraDif = Camera.main.transform.position.y - transform.position.y;
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector2 mWorldPos = Camera.main.ScreenToWorldPoint( new Vector3(mouseX, mouseY, cameraDif));
		Vector2 mainPos = transform.position;
		
		float diffX = mWorldPos.x - mainPos.x;
		float diffY = mWorldPos.y - mainPos.y;

		weaponDist = Mathf.Lerp(weaponDist, Mathf.Clamp (Vector2.Distance (mWorldPos, transform.position), .5f, 1f), Time.fixedDeltaTime*5);

		Vector2 dist = new Vector2(Mathf.Cos(Mathf.Atan2 (diffY, diffX)-(sBounce)*Mathf.Deg2Rad)*weaponDist, Mathf.Sin(Mathf.Atan2 (diffY, diffX)-(sBounce)*Mathf.Deg2Rad)*weaponDist);
		weapon.GetComponent<Rigidbody2D> ().MovePosition ((Vector2)this.transform.position+dist);

		weapon.transform.rotation = Quaternion.Euler (0, 0, Mathf.Rad2Deg * Mathf.Atan2 (diffY, diffX)+90-sBounce);
	}
}
