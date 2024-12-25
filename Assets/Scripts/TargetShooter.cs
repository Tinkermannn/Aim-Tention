using System.Collections;
using System.Data.Common;
using UnityEditor.SearchService;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject muzzleEffect;
    [SerializeField] private Weapon weapon;

    public static int shootCount = 0;

    private Animator animator; // Permainan dimulai dengan false

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
