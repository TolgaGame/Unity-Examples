// EXAMPLE SCRIPTS @2020 TOLGA ---- NOT COMPLETE THIS SCIRPT
// Basic Movement Script
// Mechanics : None
// Control : Swipe


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class GameManagers : MonoBehaviour
{

    public Rigidbody playerBody;
    public BallMovement ballmove;
    public SampleAgent sampleagent;

    // GAMEOBJECT
    public GameObject MenuCanvas, MainCam, GameCam, quads;
    public GameObject AIBall, player, soundButton, AllSound, BonusText
    public GameObject winPanel, gameOverPanel, SettingsPanel, LeftBtn, RightBtn;

    // UI
    public Text LevelText, GemText, WinGemTxt;

    // ARRAYS
    public GameObject[] Levels;
    public Material[] SkyColor;
    public Material[] BallColor;
    public AudioSource[] ses;
    public Sprite[] soundIcons;

    private int gem, level;

    // --------
    private void Start()
    {


        GetDatas();
        soundControl();
        WriteUI();

        if (level != 1)
        {
            LoadLevel();
        }
        else
        {
            Levels[0].SetActive(true);
        }
    }

    public void LoadLevel()
    {       
        if (level != 1) Levels[level - 2].SetActive(false);
        Levels[level - 1].SetActive(true);
        LevelControl();
    }

    public void GetDatas()
    {
        // LEVEL
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
        }

        // GEM
        if (PlayerPrefs.HasKey("gem"))
        {
            gem = PlayerPrefs.GetInt("gem");
        }
        else
        {
            PlayerPrefs.SetInt("gem", 5);
        }

        // SOUND
        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 1);
        }
    }

    public void TopEtkin()
    {
        // Player
        player.GetComponent<BallMovement>().enabled = true;
        quads.GetComponent<Renderer>().material = player.GetComponent<Renderer>().material;
        
        // AI Ball
        AIBall.GetComponent<NavMeshAgent>().speed = 8;
        AIBall.GetComponent<SampleAgent>().workAI = true;

        // Renkleri Esitleme
        GameObject.FindGameObjectWithTag("splat").GetComponent<ParticleSystem>().startColor = player.GetComponent<Renderer>().material.color;
        GameObject.FindGameObjectWithTag("altsplat").GetComponent<ParticleSystem>().startColor = player.GetComponent<Renderer>().material.color;
        GameObject.FindGameObjectWithTag("colorparty").GetComponent<ParticleSystem>().startColor = player.GetComponent<Renderer>().material.color;

        GameCam.GetComponent<CameraFollow>().enabled = true;
        ses[3].Play();

    }


    // GAME EVENT
    public void RestartGame()
    {
        ses[0].Play(0);
        MenuCanvas.SetActive(true);
        winPanel.SetActive(false);
        GameObject.FindGameObjectWithTag("wall").GetComponent<Renderer>().material.color = Color.black;
        GameCam.GetComponent<CameraFollow>().enabled = false;
        
        //PLAYER
        player.transform.position = new Vector3(0, 0.75f, 0);
        playerBody.velocity = Vector3.zero;
        playerBody.angularVelocity = Vector3.zero;
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<BallMovement>().filler = true;
        GameCam.GetComponent<Camera>().fieldOfView = 60;

        // AI BALL
        AIBall.GetComponent<NavMeshAgent>().speed = 0;
        AIBall.GetComponent<SampleAgent>().workAI = false;
        AIBall.transform.position = new Vector3(1.5f, 0.75f, 0f);

        LoadLevel();
        WriteUI();

        GameObject[] fills = GameObject.FindGameObjectsWithTag("fill");
        foreach (var item in fills)
        {
            Destroy(item);
        }
    }

    public void WinLevel()
    {
        ses[1].Play();
        LevelUp();
        AddGem(30);
        StartCoroutine(openWinPanel());
        LeftBtn.SetActive(false);
        RightBtn.SetActive(false);
        AIBall.GetComponent<NavMeshAgent>().speed = 0;
        AIBall.GetComponent<SampleAgent>().workAI = false;

        TinySauce.OnGameFinished(levelNumber: level.ToString(), gem);
    }

    IEnumerator openWinPanel()
    {
        yield return new WaitForSeconds(3);
        winPanel.SetActive(true);
        GameCam.SetActive(false);
        MainCam.SetActive(true);
    }

    public void GameOver()
    {
        ses[2].Play();
        AIBall.GetComponent<NavMeshAgent>().speed = 0;
        AIBall.GetComponent<SampleAgent>().workAI = false;
        StartCoroutine(openGameOverPanel());
        playerBody.velocity = Vector3.zero;
        playerBody.angularVelocity = Vector3.zero;


        LeftBtn.SetActive(false);
        RightBtn.SetActive(false);
    }

    IEnumerator openGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        gameOverPanel.SetActive(true);
        GameCam.SetActive(false);
        MainCam.SetActive(true);
    }

    public void LevelUp()
    {
        level++;
        int prevLevel = PlayerPrefs.GetInt("level");
        PlayerPrefs.SetInt("level", prevLevel + 1);
    }

    public void AddGem(int newGem)
    {
        int prevGem = PlayerPrefs.GetInt("gem");
        PlayerPrefs.SetInt("gem", prevGem + newGem);
        gem = newGem;
    }

    public void WriteUI()
    {
        gem = PlayerPrefs.GetInt("gem");
        GemText.text = PlayerPrefs.GetInt("gem").ToString();

        level = PlayerPrefs.GetInt("level");
        LevelText.text = "LEVEL " + PlayerPrefs.GetInt("level").ToString();
    }

    public void LevelControl()
    {
        switch (level)
        {
            case 1:
                RenderSettings.skybox = SkyColor[0];
                player.GetComponent<Renderer>().material = BallColor[0];
                break;
            case 2:
                RenderSettings.skybox = SkyColor[1];
                player.GetComponent<Renderer>().material = BallColor[2];
                break;
            case 3:
                RenderSettings.skybox = SkyColor[2];
                player.GetComponent<Renderer>().material = BallColor[1];
                break;
            case 4:
                RenderSettings.skybox = SkyColor[3];
                player.GetComponent<Renderer>().material = BallColor[2];
                break;
            case 5:
                RenderSettings.skybox = SkyColor[4];
                player.GetComponent<Renderer>().material = BallColor[4];
                BonusText.SetActive(true); // Bonus Level
                break;
            case 6:
                RenderSettings.skybox = SkyColor[0];
                player.GetComponent<Renderer>().material = BallColor[0];
                BonusText.SetActive(false);
                break;
            case 7:
                RenderSettings.skybox = SkyColor[1];
                player.GetComponent<Renderer>().material = BallColor[2];
                break;
            case 8:
                RenderSettings.skybox = SkyColor[2];
                player.GetComponent<Renderer>().material = BallColor[1];
                break;
            case 9:
                RenderSettings.skybox = SkyColor[3];
                player.GetComponent<Renderer>().material = BallColor[3];
                break;
            case 10:
                RenderSettings.skybox = SkyColor[4];
                player.GetComponent<Renderer>().material = BallColor[4];
                BonusText.SetActive(true); // Bonus Level
                break;
            case 11:
                RenderSettings.skybox = SkyColor[2];
                player.GetComponent<Renderer>().material = BallColor[1];
                BonusText.SetActive(false);
                break;
            case 12:
                RenderSettings.skybox = SkyColor[3];
                player.GetComponent<Renderer>().material = BallColor[3];
                break;
            case 13:
                RenderSettings.skybox = SkyColor[1];
                player.GetComponent<Renderer>().material = BallColor[2];
                break;
            case 14:
                RenderSettings.skybox = SkyColor[2];
                player.GetComponent<Renderer>().material = BallColor[1];
                break;
            case 15:
                RenderSettings.skybox = SkyColor[3];
                player.GetComponent<Renderer>().material = BallColor[3];
                break;
            case 16:
                RenderSettings.skybox = SkyColor[1];
                player.GetComponent<Renderer>().material = BallColor[2];
                break;
            case 17:
                RenderSettings.skybox = SkyColor[4];
                player.GetComponent<Renderer>().material = BallColor[4];
                BonusText.SetActive(true); // Bonus Level
                break;
            case 18:
                RenderSettings.skybox = SkyColor[3];
                player.GetComponent<Renderer>().material = BallColor[3];
                BonusText.SetActive(false);
                break;
            case 19:
                RenderSettings.skybox = SkyColor[1];
                player.GetComponent<Renderer>().material = BallColor[2];
                break;
            case 20:
                RenderSettings.skybox = SkyColor[2];
                player.GetComponent<Renderer>().material = BallColor[1];
                break;


            default:
                break;
        }
    }
     
   
    // BUTONLAR - UI
    public void StartGameBtn()
    {
        Invoke("TopEtkin", 2);
        sampleagent.target = GameObject.FindGameObjectWithTag("Target");

        // UI ve Cameras
        MenuCanvas.SetActive(false);
        MainCam.SetActive(false);
        GameCam.SetActive(true);
        LeftBtn.SetActive(true);
        RightBtn.SetActive(true);

        ses[0].Play(0);

        TinySauce.OnGameStarted(levelNumber: level.ToString());
    }

    //Win Panel
    public void NextLevelBtn()
    {
        RestartGame();
    }
    
    // GameOver Panel
    public void GameOverBtn()
    {
        RestartGame();
        gameOverPanel.SetActive(false);
    }

    // Sound ve Settings
    public void soundControl()
    {
        int soundBool = PlayerPrefs.GetInt("sound");
        // Ses açık
        if (soundBool == 1)
        {
            AllSound.SetActive(true);
            soundButton.GetComponent<Image>().sprite = soundIcons[0];
        }
        // Ses kapalı
        else
        {
            AllSound.SetActive(false);
            soundButton.GetComponent<Image>().sprite = soundIcons[1];
        }
    }

    public void toggleSound()
    {
        int soundBool = PlayerPrefs.GetInt("sound");

        // Ses kapatma
        if (soundBool == 1)
        {
            PlayerPrefs.SetInt("sound", 0);
            AllSound.SetActive(false);
            soundButton.GetComponent<Image>().sprite = soundIcons[1];
        }
        // Ses açma
        else
        {
            PlayerPrefs.SetInt("sound", 1);
            AllSound.SetActive(true);
            soundButton.GetComponent<Image>().sprite = soundIcons[0];
        }
    }

    public void SettingsBtn()
    {
        if (SettingsPanel.active)
        {
            SettingsPanel.SetActive(false);
        }
        else
        {
            SettingsPanel.SetActive(true);
        }
        ses[0].Play();

    }

    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}