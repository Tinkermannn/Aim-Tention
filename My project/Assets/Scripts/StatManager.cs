using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public GameObject statGame;

    private void Start()
    {
        statGame = GameObject.Find("EndGameStats");
        /*if (statGame != null)
        {
            statGame.SetActive(false); // Sembunyikan saat awal
        }*/
    }

    public void ShowStats()
    {
        if (statGame != null)
        {
            statGame.SetActive(true);
        }
    }

    public void HideStats()
    {
        if (statGame != null)
        {
            statGame.SetActive(false);
        }
    }
}
