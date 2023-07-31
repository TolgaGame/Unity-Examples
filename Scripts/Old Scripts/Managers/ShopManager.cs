using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [Header("GameObjects")]
    [Space]
    public GameObject playerBody;
    public GameObject stick;
    public GameObject[] buyButtons;
    public GameObject[] selectButtons;
    public GameObject[] stickselectButtons;
    public Text coinText;

    [Header("Colors")]
    [Space]
    public Material[] stickColors;
    public Material[] playerColor;

    [Header("Variables")]
    private int coin;
    private int colorManNum;
    private int stcikColorNum;

    private void Start()
    {
              
        coin = PlayerPrefs.GetInt("coin");
        ShopDataConrol();
        ButtonActivator();
    }

    public void ShopDataConrol()
    {
        
        // COLOR MAN
        if (PlayerPrefs.HasKey("colorMan"))
        {
            colorManNum = PlayerPrefs.GetInt("colorMan");
            ColorControl(colorManNum);
        }
        else
        {
            PlayerPrefs.SetInt("colorMan", 0);
            colorManNum = 0;
            playerBody.GetComponent<SkinnedMeshRenderer>().material = playerColor[6];

        }

        // STICK COLOR
        if (PlayerPrefs.HasKey("stickColor"))
        {
            stcikColorNum = PlayerPrefs.GetInt("stickColor");
            StickColorControl(stcikColorNum);
        }
        else
        {
            PlayerPrefs.SetInt("stickColor", 0);
            stcikColorNum = 0;
            stick.GetComponent<MeshRenderer>().material = stickColors[6];

        }

    }


    public void DiscardCoin(int newCoin)
    {
        int prevCoin = PlayerPrefs.GetInt("coin");
        PlayerPrefs.SetInt("coin", prevCoin - newCoin);
        coin = PlayerPrefs.GetInt("coin");
        coinText.text = coin.ToString();
        Debug.Log(coin);
    }


    #region SHOP CONTROLLER

    // BUY AND SELECT
    public void ColorBuyButton(int buttonNum)
    {
        
        coin = PlayerPrefs.GetInt("coin");

        if (buttonNum == 1 && coin >= 400)
        {
            ColorControl(1);
            PlayerPrefs.SetInt("button1", 1);
            DiscardCoin(400);
        }
        else if (buttonNum == 2 && coin >= 600)
        {
            ColorControl(2);
            PlayerPrefs.SetInt("button2", 1);
            DiscardCoin(600);
        }        
        else if (buttonNum == 3 && coin >= 800)
        {
            ColorControl(3);
            PlayerPrefs.SetInt("button3", 1);
            DiscardCoin(800);
        }        
        else if (buttonNum == 4 && coin >= 1000)
        {
            ColorControl(4);
            PlayerPrefs.SetInt("button4", 1);
            DiscardCoin(1000);
        }        
        else if (buttonNum == 5 && coin >= 1200)
        {
            ColorControl(5);
            PlayerPrefs.SetInt("button5", 1);
            DiscardCoin(1200);
        }
        else if (buttonNum == 6 && coin >= 1400)
        {
            ColorControl(6);
            PlayerPrefs.SetInt("button6", 1);
            DiscardCoin(1400);
        }

    }

    public void StickBuyButton(int buttonsNum)
    {

        coin = PlayerPrefs.GetInt("coin");

        if (buttonsNum == 1 && coin >= 400)
        {
            StickColorControl(1);
            PlayerPrefs.SetInt("buttonStick1", 1);
            DiscardCoin(400);
        }
        else if (buttonsNum == 2 && coin >= 600)
        {
            StickColorControl(2);
            PlayerPrefs.SetInt("buttonStick2", 1);
            DiscardCoin(600);
        }
        else if (buttonsNum == 3 && coin >= 800)
        {
            StickColorControl(3);
            PlayerPrefs.SetInt("buttonStick3", 1);
            DiscardCoin(800);
        }
        else if (buttonsNum == 4 && coin >= 1000)
        {
            StickColorControl(4);
            PlayerPrefs.SetInt("buttonStick4", 1);
            DiscardCoin(1000);
        }
        else if (buttonsNum == 5 && coin >= 1200)
        {
            StickColorControl(5);
            PlayerPrefs.SetInt("buttonStick5", 1);
            DiscardCoin(1200);
        }
        else if (buttonsNum == 6 && coin >= 1400)
        {
            StickColorControl(6);
            PlayerPrefs.SetInt("buttonStick6", 1);
            DiscardCoin(1400);
        }
    }

    public void SelectButton(int selectbuttonNum)
    {


        if (selectbuttonNum == 1)
        {
            ColorControl(1);

        }
        else if (selectbuttonNum == 2)
        {
            ColorControl(2);

        }
        else if (selectbuttonNum == 3)
        {
            ColorControl(3);

        }
        else if (selectbuttonNum == 4)
        {
            ColorControl(4);

        }
        else if (selectbuttonNum == 5)
        {
            ColorControl(5);

        }
        else if (selectbuttonNum == 6)
        {
            ColorControl(6);

        }
        else if (selectbuttonNum == 7)
        {
            StickColorControl(1);

        }
        else if (selectbuttonNum == 8)
        {
            StickColorControl(2);

        }
        else if (selectbuttonNum == 9)
        {
            StickColorControl(3);

        }
        else if (selectbuttonNum == 10)
        {
            StickColorControl(4);

        }
        else if (selectbuttonNum == 11)
        {
            StickColorControl(5);

        }
        else if (selectbuttonNum == 12)
        {
            StickColorControl(6);

        }

    }

    // MAN COLOR
    public void ColorControl(int colorNum)
    {
            switch (colorNum)

            {
            
                case 1:
                        playerBody.GetComponent<SkinnedMeshRenderer>().material = playerColor[0];
                        PlayerPrefs.SetInt("colorMan", 1);                       
                        buyButtons[0].SetActive(false);
                        selectButtons[0].SetActive(true);
                    break;                
                
                case 2:
                        playerBody.GetComponent<SkinnedMeshRenderer>().material = playerColor[1];
                        PlayerPrefs.SetInt("colorMan", 2);
                        buyButtons[1].SetActive(false);
                        selectButtons[1].SetActive(true);
                    break;            
                
                case 3:
                        playerBody.GetComponent<SkinnedMeshRenderer>().material = playerColor[2];
                        PlayerPrefs.SetInt("colorMan", 3);
                        buyButtons[2].SetActive(false);
                        selectButtons[2].SetActive(true);
                    break;            
                
                case 4:
                        playerBody.GetComponent<SkinnedMeshRenderer>().material = playerColor[3];
                        PlayerPrefs.SetInt("colorMan", 4);
                        buyButtons[3].SetActive(false);
                        selectButtons[3].SetActive(true);
                    break;
                
                case 5:
                         playerBody.GetComponent<SkinnedMeshRenderer>().material = playerColor[4];
                         PlayerPrefs.SetInt("colorMan", 5);
                         buyButtons[4].SetActive(false);
                         selectButtons[4].SetActive(true);
                    break;
                
                case 6:
                         playerBody.GetComponent<SkinnedMeshRenderer>().material = playerColor[5];
                         PlayerPrefs.SetInt("colorMan", 6);
                         buyButtons[5].SetActive(false);
                         selectButtons[5].SetActive(true);
                    break;

                default:
                        break;

            }
        }
 
   
    // STICK COLOR
    public void StickColorControl(int stickColor)
    {
        switch (stickColor)

        {

            case 1:
                    stick.GetComponent<MeshRenderer>().material = stickColors[0];
                    PlayerPrefs.SetInt("stickColor", 1);
                    buyButtons[6].SetActive(false);
                    stickselectButtons[0].SetActive(true);
                break;

            case 2:
                    stick.GetComponent<MeshRenderer>().material = stickColors[1];
                    PlayerPrefs.SetInt("stickColor", 2);
                    buyButtons[7].SetActive(false);
                    stickselectButtons[1].SetActive(true);
                break;

            case 3:
                    stick.GetComponent<MeshRenderer>().material = stickColors[2];
                    PlayerPrefs.SetInt("stickColor", 3);
                    buyButtons[8].SetActive(false);
                    stickselectButtons[2].SetActive(true);
                break;

            case 4:
                    stick.GetComponent<MeshRenderer>().material = stickColors[3];
                    PlayerPrefs.SetInt("stickColor", 4);
                    buyButtons[9].SetActive(false);
                    stickselectButtons[3].SetActive(true);
                break;

            case 5:
                     stick.GetComponent<MeshRenderer>().material = stickColors[4];
                     PlayerPrefs.SetInt("stickColor", 5);
                     buyButtons[10].SetActive(false);
                     stickselectButtons[4].SetActive(true);
                break;

            case 6:
                     stick.GetComponent<MeshRenderer>().material = stickColors[5];
                     PlayerPrefs.SetInt("stickColor", 6);
                     buyButtons[11].SetActive(false);
                     stickselectButtons[5].SetActive(true);
                break;

            default:
                break;

        }
    }


    #endregion


    public void ButtonActivator()
    {

        // BUTTON 1
        if (PlayerPrefs.HasKey("button1"))
        {
            buyButtons[0].SetActive(false);
            selectButtons[0].SetActive(true);
        }
        else
        {
            buyButtons[0].SetActive(true);
        }
       
        // BUTTON 2
        if (PlayerPrefs.HasKey("button2"))
        {
            selectButtons[1].SetActive(true);
            buyButtons[1].SetActive(false);
        }
        else
        {
            buyButtons[1].SetActive(true);
        }

        // BUTTON 3
        if (PlayerPrefs.HasKey("button3"))
        {
            selectButtons[2].SetActive(true);
            buyButtons[2].SetActive(false);
        }
        else
        {
            buyButtons[2].SetActive(true);
        }

        // BUTTON 4
        if (PlayerPrefs.HasKey("button4"))
        {
            selectButtons[3].SetActive(true);
            buyButtons[3].SetActive(false);
        }
        else
        {
            buyButtons[3].SetActive(true);
        }

        // BUTTON 5
        if (PlayerPrefs.HasKey("button5"))
        {
            selectButtons[4].SetActive(true);
            buyButtons[4].SetActive(false);
        }
        else
        {
            buyButtons[4].SetActive(true);
        }

        // BUTTON 6
        if (PlayerPrefs.HasKey("button6"))
        {
            selectButtons[5].SetActive(true);
            buyButtons[5].SetActive(false);
        }
        else
        {
            buyButtons[5].SetActive(true);
        }

        // ----- STICK BUY 

        // STICK BUTTON 1
        if (PlayerPrefs.HasKey("buttonStick1"))
        {
            stickselectButtons[0].SetActive(true);
            buyButtons[6].SetActive(false);
        }
        else
        {
            buyButtons[6].SetActive(true);
        }
       
        // STICK BUTTON 2
        if (PlayerPrefs.HasKey("buttonStick2"))
        {
            stickselectButtons[1].SetActive(true);
            buyButtons[7].SetActive(false);
        }
        else
        {
            buyButtons[7].SetActive(true);
        }

        // STICK BUTTON 3
        if (PlayerPrefs.HasKey("buttonStick3"))
        {
            stickselectButtons[2].SetActive(true);
            buyButtons[8].SetActive(false);
        }
        else
        {
            buyButtons[8].SetActive(true);
        }

        // STICK BUTTON 4
        if (PlayerPrefs.HasKey("buttonStick4"))
        {
            stickselectButtons[3].SetActive(true);
            buyButtons[9].SetActive(false);
        }
        else
        {
            buyButtons[9].SetActive(true);
        }

        // STICK BUTTON 5
        if (PlayerPrefs.HasKey("buttonStick5"))
        {
            stickselectButtons[4].SetActive(true);
            buyButtons[10].SetActive(false);
        }
        else
        {
            buyButtons[10].SetActive(true);
        }

        // STICK BUTTON 6
        if (PlayerPrefs.HasKey("buttonStick6"))
        {
            stickselectButtons[5].SetActive(true);
            buyButtons[11].SetActive(false);
        }
        else
        {
            buyButtons[11].SetActive(true);
        }


    }

}