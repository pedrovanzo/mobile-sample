using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBat : MonoBehaviour {

	public Rigidbody2D test;

	void FixedUpdate()
	{
        test.AddForce(transform.right * 100f, ForceMode2D.Force);
	}

}
