// EXAMPLE SCRIPTS @2020 TOLGA
// Basic Camera Follow Script
// Mechanics : None
// Control : None


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;


    // -----
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}

