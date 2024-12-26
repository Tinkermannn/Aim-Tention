using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static bool isHit = false;

    public void Hit()
    {
        /*
        if (spawner != null && spawner.GetFlickModeStatus())
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = TargetBounds.Instance.GetRandomPosition();
        }
        */
        Destroy(gameObject);
        FlickTargetSpawner.targetCount--;

        if (SoundManager.Instance != null && SoundManager.Instance.destroyedSound != null)
        {
            SoundManager.Instance.destroyedSound.Play();
        }
        else
        {
            Debug.LogWarning("SoundManager or shootingSound1911 is not assigned!");
        }
    }
}
