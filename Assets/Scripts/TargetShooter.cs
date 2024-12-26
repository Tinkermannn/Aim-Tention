using System.Collections;
<<<<<<< HEAD
using UnityEngine;
using UnityEngine.UI;
=======
using System.Data.Common;
using UnityEditor.SearchService;
using UnityEngine;
>>>>>>> 2eded99efb4cb4bc2eac0f8a0b1c7c83036cae1d

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject muzzleEffect;
    [SerializeField] private Weapon weapon;
<<<<<<< HEAD
    [SerializeField] private float gameDuration = 30f;

    private Animator animator;
    private float timer = 0f;
    private bool isGameRunning = false;
=======

    public static int shootCount = 0;

    private Animator animator; // Permainan dimulai dengan false
>>>>>>> 2eded99efb4cb4bc2eac0f8a0b1c7c83036cae1d

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
            shootCount++;

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
