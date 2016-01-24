using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform target;
	public float trackSpeed = 30;

	// Set target
	public void SetTarget(Transform t) {
		target = t;
	}

	// Track target
	void LateUpdate() {
		if (target) {
			var v = transform.position;
			v.x = target.position.x;
			transform.position = Vector3.MoveTowards (transform.position, v, trackSpeed * Time.deltaTime);
		}
	}

}
