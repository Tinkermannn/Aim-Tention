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
    private const float time = 5f;
    // Update is called once per frame
    public TextMeshProUGUI timerLbl;
    public static bool start;
    public static bool gameOver;
    [SerializeField] public static float timer = time;
    private void Update()
    {
        if (start == true) 
        {
            if (timer > 0)
            {
                gameOver=false;
                timer -= Time.deltaTime;
                DisplayTime(timer);
                Debug.Log("GameOver = false");
            }
            else
            {
                //start=false;
                gameOver = true;
                timer = time;
                timerLbl.text = "Time's Up";
                Debug.Log("GameOver = true");
            }
        }
    }

    private void DisplayTime(float displayTime){
        float minutes = Mathf.FloorToInt(displayTime/60);
        float seconds = Mathf.FloorToInt(displayTime%60);
        timerLbl.text = $"{minutes}:{seconds}";
    }

}