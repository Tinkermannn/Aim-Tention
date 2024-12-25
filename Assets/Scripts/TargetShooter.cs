using System.Collections;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject muzzleEffect;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float gameDuration = 30f; // Durasi permainan dalam detik

    private Animator animator;
    private float timer = 0f; // Timer internal
    private bool isGameRunning = false; // Permainan dimulai dengan false

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

    private void StartGame()
    {
        isGameRunning = true;
        timer = 0f; // Reset timer
        StartCoroutine(GameTimer());
        Debug.Log("Game Started!");
    }

    private IEnumerator GameTimer()
    {
        while (timer < gameDuration)
        {
            timer += Time.deltaTime;
            Debug.Log($"Game Timer: {timer:F2} seconds"); // Logging waktu berjalan
            yield return null;
        }

        EndGame(); // Panggil fungsi untuk mengakhiri permainan setelah waktu habis
    }

    private void EndGame()
    {
        isGameRunning = false;
        Debug.Log("Game Over! Time's up.");
        // Tambahkan logika untuk mengakhiri permainan, seperti menampilkan UI game over
    }
}
