using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameStats : MonoBehaviour
{
    public static float accuracy = 0f;
    public static int points = 0;
    public static int totalTarget = 0;

    public static int missed = 0;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI TargetHit;
    public TextMeshProUGUI ShotsFired;
    public TextMeshProUGUI Accuracy;

    void Update()
    {
        if (points < 0)
        {
            points = 0;
        }
        else points = (TargetShooter.hitCount * 50) - ((FlickTargetSpawner.spawned - TargetShooter.hitCount) * 25) - 25;
        totalTarget = FlickTargetSpawner.spawned;
        if (totalTarget==0)
        {
            accuracy = TargetShooter.hitCount;
        }
        else accuracy = (TargetShooter.hitCount-1) * 100 / totalTarget;
        Debug.Log("Accuracy : " + accuracy);
        ShowAccuracy();
        ShowPoints();
        ShowHit();
        ShowShots();
    }

    private void ShowAccuracy()
    {
        Accuracy.text = $"{accuracy}%";
    }

    private void ShowPoints()
    {
        Score.text = $"{points}";
    }

    private void ShowHit()
    {
        TargetHit.text = $"{TargetShooter.hitCount-1}/{totalTarget}";
    }

    private void ShowShots()
    {
        ShotsFired.text = $"{TargetShooter.shootCount}";
    }



}
