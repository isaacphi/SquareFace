using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {

	private Animator animator;
	private PlayerMovement playerMovement;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
		playerMovement = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerMovement.walking) {
			animator.SetBool ("walking", true);
		} else {
			animator.SetBool ("walking", false);
		}
		if (playerMovement.jumping) {
			animator.SetBool ("jumping", true);
		} else {
			animator.SetBool ("jumping", false);
		}
		if (playerMovement.ground) {
			animator.SetBool ("grounded", true);
		} else {
			animator.SetBool ("grounded", false);
		}
	}
}
