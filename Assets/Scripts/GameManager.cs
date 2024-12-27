using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool flick = false;

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

    public void playAgain()
    {
        if (flick == true){
            setFlick();
        }
        else noFlick();
    }
}