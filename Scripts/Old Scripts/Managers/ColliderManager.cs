// EXAMPLE SCRIPTS @2020 TOLGA
// Basic Collider Control Script
// Mechanics : None
// Control : Swipe



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    public GameManagers gm;
    public Rigidbody playerBody;
    public BallMovement ballmoves;


    // ------------------------

    // COLLISION
    private void OnCollisionEnter(Collision obj)
    {
        // WALL & PLAYER
        if (obj.gameObject.tag == "Wall" && gameObject.tag == "Player")
        {
            gm.GameCam.GetComponent<Camera>().fieldOfView = 75;

            GameObject.FindGameObjectWithTag("splat").GetComponent<ParticleSystem>().Play();
            GameObject.FindGameObjectWithTag("Wall").GetComponent<Renderer>().material.color = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color;
            GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled = false;

            playerBody.velocity = Vector3.zero;
            playerBody.angularVelocity = Vector3.zero;
            ballmoves.enabled = false;
            gm.WinLevel();
          
        }
       
        
        // Topun Gameoverla Carpismasi
        if (obj.gameObject.tag == "gameover" && gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled = false;
            ballmoves.enabled = false;
            gm.GameOver();

        }
    }

    // IS TRIGGER
    private void OnTriggerEnter(Collider other)
    {
        
        // Gem ve player 
        if (other.gameObject.tag == "Gem" && gameObject.tag == "Player")
        {
            int prevGem = PlayerPrefs.GetInt("gem");
            PlayerPrefs.SetInt("gem", prevGem + 1);
            gm.GemText.text = (prevGem + 1).ToString();

            gm.sound[4].Play();
            Destroy(other.gameObject);
        }
        
            
        // SpeedBoost ve player
        if (other.gameObject.tag == "SpeedBoost" && gameObject.tag == "Player")
        {            
            playerBody.AddForce(new Vector3(0, 0, 5000));
            GameObject.FindGameObjectWithTag("Confeti").GetComponent<ParticleSystem>().Play();
            GameObject.FindGameObjectWithTag("Boom").GetComponent<ParticleSystem>().Play();

            ballmoves.filler = false;
        }

    }

}