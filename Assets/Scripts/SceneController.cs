using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main"); // Ganti "Main" dengan nama scene Main Anda
    }
    
    public void LoaStartScene()
    {
        SceneManager.LoadScene("Start"); // Ganti "Start" dengan nama scene Main Anda
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
