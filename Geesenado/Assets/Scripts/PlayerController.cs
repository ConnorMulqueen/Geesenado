using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	public PlayableCharacter player;
	public float speed;
	public float runningSpeed;
	public Slider staminaBar;
	public float timer=0f;
	public float timeToWait = 1.0f;
	//---------------------------------------------------------
	public float Stamina = 100.0f;
	public float MaxStamina = 100.0f;
	//---------------------------------------------------------
	private float StaminaRegenTimer = 0.0f;
	//---------------------------------------------------------
	private const float StaminaDecreasePerFrame = 1.0f;
	private const float StaminaIncreasePerFrame = 5.0f;
	private const float StaminaTimeToRegen = 3.0f;
	//---------------------------------------------------------
	new void Start(){
		staminaBar.value = MaxStamina;
	}
	void FixedUpdate () {
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0,0,transform.eulerAngles.z );

		GetComponent<Rigidbody2D> ().angularVelocity=0; 
		Vector2 targetVelocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (Stamina > 0) {
				GetComponent<Rigidbody2D> ().velocity = targetVelocity * runningSpeed;
				Stamina = Stamina - 1;
			}
			else{
				GetComponent<Rigidbody2D> ().velocity = targetVelocity * speed;
			}
		}
		else{
			GetComponent<Rigidbody2D> ().velocity = targetVelocity * speed;

			timer += Time.deltaTime;
			if(timer > timeToWait){
				recoverStamina ();
				timer = 0f;

			}
		}
		staminaBar.value = calcStamina();
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PLAYER COLLISION");
    }
	public float calcStamina(){
		return Stamina/MaxStamina;
	}
	void recoverStamina(){
		if (Stamina < 100) {
			Stamina = Stamina + 20;

		}

	}

}