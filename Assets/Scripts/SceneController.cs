using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Main"); // Ganti "Main" dengan nama scene Main Anda
        FlickTargetSpawner.early = true; 
    }

    public void LoaStartScene()
    {
        SceneManager.LoadScene("Start"); // Ganti "Start" dengan nama scene Main Anda
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
