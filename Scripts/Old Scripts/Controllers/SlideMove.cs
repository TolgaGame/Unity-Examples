// EXAMPLE SCRIPTS @2020 TOLGA
// Basic Movement Script
// Mechanics : Runner
// Control : Slide


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMove : MonoBehaviour
{

    private float deltaX, deltaY;
    private Rigidbody rb;

    // ------
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, transform.position.y));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;


            }
        }
    }

}
