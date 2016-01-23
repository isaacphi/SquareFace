using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float speed;
	private Rigidbody body;

	// Use this for initialization
	void Awake () {
		body = GetComponent<Rigidbody> ();
		body.angularVelocity = Vector3.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
