using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void NormalMode()
    {
        SceneManager.LoadScene("Main"); // Ganti "Main" dengan nama scene Main Anda
    }

    public void SetFlick()
    {
        SceneManager.LoadScene("Main");
        GameManager.flick = true;
    }
}
