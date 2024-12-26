using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
        FlickTargetSpawner.early = true; // Ganti "Main" dengan nama scene Main Anda
    }
}
