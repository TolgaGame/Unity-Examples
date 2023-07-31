// EXAMPLE SCRIPTS @2020 TOLGA
// Basic Movement Script
// Mechanics : None
// Control : Swipe


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour {

    private Vector2 startTouchPosition, endTouchPosition;
    private PlayerController _playerController;


    // -----------------
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }


    private void Update()
    {
        if (!GameManager.GameStarted || !PlayerController.Instance.inputPermission)
        {
            return;
        }
        
        if (Input.GetButtonDown("Fire1"))
            startTouchPosition = Input.mousePosition;

        if (Input.GetButtonUp("Fire1"))
        {
            endTouchPosition = Input.mousePosition;
            if (Vector3.Distance(endTouchPosition, startTouchPosition) < 100f)
            {
                return;
            }
            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x > -1.75f&&_playerController.currentLine != 2)
            {
                _playerController.currentLine += 1;
            }


            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x < 1.75f&&_playerController.currentLine != 0)
            {
                _playerController.currentLine -= 1;
            }
            startTouchPosition = Vector3.zero;
            endTouchPosition = Vector3.zero;
        }
    }    

}
