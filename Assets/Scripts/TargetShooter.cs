using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    public GameObject muzzleEffect;
    private Animator animator;
    public Weapon weapon;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Klik kiri untuk menembak
        {
            muzzleEffect.GetComponent<ParticleSystem>().Play();
            weapon.Shoot();

            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.GetComponent<Target>();
                if (target != null)
                {
                    target.Hit(); // Hancurkan target jika terkena tembakan
                }
            }
        }
    }
}
