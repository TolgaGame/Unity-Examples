using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    [Header("Strings")]
    private string gameLink;
    private string imageUrl = "http://tetagames.com/demoGame.png";
    private string url = "http://www.tetagames.com/gameURL.txt";   
    public Renderer gameImage;



    // -------- GAME LOADER SYSTEM
    private void Start()
    {
        StartCoroutine(LoadImage());
        StartCoroutine(LoadGameUrl());
    }

    // LOAD IMAGE
    private IEnumerator LoadImage()
    {
        WWW wwwLoader = new WWW(imageUrl);
        yield return wwwLoader;
        gameImage.material.mainTexture = wwwLoader.texture;

    }


    // LOAD GAME URL
    private IEnumerator LoadGameUrl()
    {
        WWW www = new WWW(url);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("Ooops, something went wrong...");
        }
        else
        {
            gameLink = www.text;
            Debug.Log(gameLink);
        }
    }

    // OPEN BUTTON
    public void OpenButton()
    {

        Application.OpenURL(gameLink);
    }


}
