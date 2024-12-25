using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool flick = false;
    public static int targetHit = 0;
    public static int targetMissed = 0;
    void Update()
    {
        
    }

    void Start()
    {

    }

    public void setFlick(){
        flick = true;
    }
    
    public void noFlick(){
        flick = false;
    }
}