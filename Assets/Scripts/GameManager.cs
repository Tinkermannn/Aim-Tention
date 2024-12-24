using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FlickTargetSpawner flickTargetSpawner;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Example toggle with "F" key
        {
            flickTargetSpawner.ActivateFlickMode(true);
        }
    }
}