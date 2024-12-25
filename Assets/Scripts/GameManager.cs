using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FlickTargetSpawner flickTargetSpawner;
    public static bool flick = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Example toggle with "F" key
        {
            flick = true;
        }
        SetFlick(flick);
    }

    public void SetFlick(bool flick)
    {
        flickTargetSpawner.ActivateFlickMode(flick);
    }
}