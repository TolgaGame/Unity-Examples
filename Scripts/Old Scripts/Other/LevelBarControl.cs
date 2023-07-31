using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarControl : MonoBehaviour
{
    [Header("Objects")]
    [Space]
    public Transform player;
    public Transform endLine;
    private float maxDistance;
    public Slider levelBar;

    private void Start()
    {
        maxDistance = getDistance();

    }

    private void Update()
    {
       
        if (player.position.z <= maxDistance && player.position.z <= endLine.position.z)
        {
            float distance = 1 - (getDistance() / maxDistance);
            setProgress(distance);
        }

    }

    float getDistance()
    {
        return Vector3.Distance(player.position, endLine.position);
    }

    private void setProgress(float p)
    {
        levelBar.value = p;
    }




}