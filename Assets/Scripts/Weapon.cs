using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon Instance { get; private set; }

    public Animator animator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        // Trigger the recoil animation
        animator.SetTrigger("RECOIL");

        // Play the shooting sound
        if (SoundManager.Instance != null && SoundManager.Instance.shootingSound1911 != null)
        {
            SoundManager.Instance.shootingSound1911.Play();
        }
        else
        {
            Debug.LogWarning("SoundManager or shootingSound1911 is not assigned!");
        }
    }
}
