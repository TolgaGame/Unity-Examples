// EXAMPLE SCRIPTS @2020 TOLGA
// Basic Movement Script
// Mechanics : None
// Control : Swipe


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour {

	private Vector2 startTouchPosition, endTouchPosition;
	private Rigidbody2D rb;

    private float jumpForce = 700f;
	private bool jumpAllowed = false;

	// -------
	private void Start ()
    {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	private void Update ()
    {
		SwipeCheck();
        
    }

	private void FixedUpdate()
	{
        JumpIfAllowed();
    }


	private void SwipeCheck()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

        }

        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)
        {
			endTouchPosition = Input.GetTouch (0).position;
			if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
				jumpAllowed = true;
		}
	}

	private void JumpIfAllowed()
	{
		if (jumpAllowed)
        {
			rb.AddForce (Vector2.up * jumpForce);
			jumpAllowed = false;
		}
	}

}
