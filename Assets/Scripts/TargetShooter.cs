using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject muzzleEffect;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float gameDuration = 30f;

    private Animator animator;
    private float timer = 0f;
    private bool isGameRunning = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Mulai permainan dengan tombol N
        if (Input.GetKeyDown(KeyCode.N) && !isGameRunning)
        {
            StartGame();
        }

        if (Input.GetMouseButtonDown(0)) // Klik kiri untuk menembak
        {
            muzzleEffect.GetComponent<ParticleSystem>().Play();
            weapon.Shoot();

            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f)); // Ray dari tengah layar
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Debug: Tampilkan nama objek yang terkena
                Debug.Log($"Hit object: {hit.collider.gameObject.name}");

                // Mencari komponen Button di parent atau child dari objek yang terkena
                Button button = hit.collider.GetComponentInParent<Button>() ?? hit.collider.GetComponentInChildren<Button>();
                if (button != null)
                {
                    button.onClick.Invoke(); // Memanggil event onClick Button
                    Debug.Log($"Button {button.name} clicked via shooting!");
                }
                else
                {
                    // Jika bukan button, periksa apakah itu target
                    Target target = hit.collider.GetComponentInParent<Target>() ?? hit.collider.GetComponentInChildren<Target>();
                    if (target != null)
                    {
                        target.Hit(); // Hancurkan target jika terkena tembakan
                        Debug.Log($"Target {target.name} hit!");
                    }
                    else
                    {
                        Debug.Log("Hit object has no Button or Target component.");
                    }
                }
            }
            else
            {
                Debug.Log("No object hit by the ray.");
            }
        }
    }

    private void StartGame()
    {
        isGameRunning = true;
        timer = 0f;
        StartCoroutine(GameTimer());
        Debug.Log("Game Started!");
    }

    private IEnumerator GameTimer()
    {
        while (timer < gameDuration)
        {
            timer += Time.deltaTime;
            Debug.Log($"Game Timer: {timer:F2} seconds");
            yield return null;
        }

        EndGame();
    }

    private void EndGame()
    {
        isGameRunning = false;
        Debug.Log("Game Over! Time's up.");
    }
}