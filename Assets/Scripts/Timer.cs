using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public TextMeshProUGUI timerLbl;
    [SerializeField] private float timer = 30f;
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            DisplayTime(timer);
        }
        else
        {
            TargetShooter.gameOver = true;
            timerLbl.text = "Time's Up";
        }
    }
    private void DisplayTime(float displayTime){
        float minutes = Mathf.FloorToInt(displayTime/60);
        float seconds = Mathf.FloorToInt(displayTime%60);
        timerLbl.text = $"{minutes}:{seconds}";
    }

}