using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Main"); // Ganti "Main" dengan nama scene Main Anda 
    }

    public void LoaStartScene()
    {
        SceneManager.LoadScene("Start"); // Ganti "Start" dengan nama scene Main Anda
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void FirstEntry()
    {
        FlickTargetSpawner.early = true; 
    }

    public void Exit()
    {
        Application.Quit();
    }
}
