// EXAMPLE SCRIPTS @2020 TOLGA
// Basic Movement Script
// Mechanics : Runner
// Control : Tap

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour
{

    public Rigidbody Player;
    public GameObject Fill;

    public bool filler = true;
    public string direction;
    public int PrevLine = 1;
    public int Line = 1;   
    private float PrevPosX;
    private float PrevPosZ;
    private float Speed = 50;

    // ----------
    private void FixedUpdate()
    {
              
         Player.AddForce(new Vector3(0, 0, 1) * Speed);
        
         if (Line == 0 || (Line == 1 && PrevLine == 2))
         {
             transform.position = Vector3.Lerp(transform.position, new Vector3(PrevPosX - 1.3f, transform.position.y, transform.position.z), Time.deltaTime * 4.0f);
         }
         else if (Line == 2 || (Line == 1 && PrevLine == 0))
         {
             transform.position = Vector3.Lerp(transform.position, new Vector3(PrevPosX + 1.3f, transform.position.y, transform.position.z), Time.deltaTime * 4.0f);
         }
       
    }

    //LEFT AND RIGHT SWITCH
    public void LeftActive()
    {
        if (Line > 0)
        {
            PrevPosX = transform.position.x;
            PrevPosZ = transform.position.z;
            PrevLine = Line;
            Line--;
        }
    }

    public void RightActive()
    {
        if (Line < 2)
        {
            PrevPosX = transform.position.x;
            PrevPosZ = transform.position.z;
            PrevLine = Line;
            Line++;
        }
    }

}