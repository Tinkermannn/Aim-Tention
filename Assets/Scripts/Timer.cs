using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public TextMeshProUGUI timerLbl;
    public static bool start;
    public static bool gameOver;
    [SerializeField] public static float timer = 30f;
    private void Update()
    {
        if (start == true) 
        {
            if (timer > 0)
            {
                gameOver=false;
                timer -= Time.deltaTime;
                DisplayTime(timer);
            }
            else
            {
                start=false;
                gameOver=true;
                timer = 30f;
                timerLbl.text = "Time's Up";
            }
        }
    }

    private void DisplayTime(float displayTime){
        float minutes = Mathf.FloorToInt(displayTime/60);
        float seconds = Mathf.FloorToInt(displayTime%60);
        timerLbl.text = $"{minutes}:{seconds}";
    }

}