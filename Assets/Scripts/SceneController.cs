using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void NormalMode()
    {
        SceneManager.LoadScene("Main"); // Ganti "Main" dengan nama scene Main Anda
    }

    public static void SetFlick()
    {
        SceneManager.LoadScene("Main");
        GameManager.flick = true;
    }
}
