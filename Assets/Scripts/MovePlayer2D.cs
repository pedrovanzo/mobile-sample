using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer2D : MonoBehaviour {

	public Joystick joystick;

	public static int mitoPoints;
	public Text mitoScore;

	public GameObject bat;
	public Transform batRotation;
	public Transform batPos;

	public static float joyValue;
	
	// Update is called once per frame
	void FixedUpdate () {

		Twist();

        joyValue = joystick.Horizontal;
        Debug.Log(MovePlayer2D.joyValue);

        mitoScore.text = mitoPoints.ToString();

		if(Input.GetKeyDown(KeyCode.B)){
			GameObject swing = Instantiate (bat, batPos.position, batPos.rotation);
			swing.transform.parent = gameObject.transform;
			Destroy (swing, .18f);
		}

		// Move Left
		//if(joystick.Horizontal < 0.2f){
			//gameObject.transform.Translate (new Vector3 (-0.035f, 0, 0));
		//}
		//Move Right
		//if(joystick.Horizontal > -0.2f){
			//gameObject.transform.Translate (new Vector3 (0.035f, 0, 0));
		//}
		//Move Up
		//if(joystick.Vertical > 0.2f){
			//gameObject.transform.Translate (new Vector3 (0, 0.035f, 0));
		//}
		//Move Down
		//if(joystick.Vertical < -0.2f){
			//gameObject.transform.Translate (new Vector3 (0, -0.035f, 0));
		//}
		// Move Left
		if (joystick.Horizontal < 0.2f)
		{
			gameObject.transform.Translate(new Vector3(-0.035f, 0, 0),Space.World);
		}
		//Move Right
		if (joystick.Horizontal > -0.2f)
		{
			gameObject.transform.Translate(new Vector3(0.035f, 0, 0), Space.World);
		}
		//Move Up
		if (joystick.Vertical > 0.2f)
		{
			gameObject.transform.Translate(new Vector3(0, 0.035f, 0), Space.World);
		}
		//Move Down
		if (joystick.Vertical < -0.2f)
		{
			gameObject.transform.Translate(new Vector3(0, -0.035f, 0), Space.World);
		}

	}

	public void AttackFunc(){

		GameObject swing = Instantiate (bat, batPos.position, batPos.rotation);
		swing.transform.parent = gameObject.transform;
		Destroy (swing, .28f);
		
	}	

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "MitoCoin"){
			mitoPoints += 5;
			Destroy (other.gameObject);
			Debug.Log ("Coin");
		}
	}

	void OnCollisionEnter2D(){
		Debug.Log ("Collided");
	}

	public float h1;
	public float v1;

	void Twist ()
	{
		h1 = joystick.Vertical; // set as your inputs 
		v1 = joystick.Horizontal;
		if (h1 == 0f && v1 == 0f) { // this statement allows it to recenter once the inputs are at zero 
			Vector3 curRot = gameObject.transform.localEulerAngles; // the object you are rotating
			Vector3 homeRot;
			if (curRot.z > 180f) { // this section determines the direction it returns home 
				Debug.Log (curRot.z);
				homeRot = new Vector3 (0f, 0f, 359.999f); //it doesnt return to perfect zero 
			} else {                                                                      // otherwise it rotates wrong direction 
				homeRot = Vector3.zero;
			}
			gameObject.transform.localEulerAngles = Vector3.Slerp (curRot, homeRot, Time.deltaTime*2);
		} else {
			gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, Mathf.Atan2 (h1, v1) * 180 / Mathf.PI); // this does the actual rotaion according to inputs
		}
	}

}
