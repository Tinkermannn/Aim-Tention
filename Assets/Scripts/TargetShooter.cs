using System.Collections;
using System.Data.Common;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    public static TargetShooter instance;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject muzzleEffect;
    [SerializeField] private Weapon weapon;

    private Animator animator;
    private bool isGameRunning = false; // Permainan dimulai dengan false
    public static bool gameOver = false; // Permainan dimulai dengan false

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start(){
        instance = this;
        gameOver = false;
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

        if (gameOver == true){
            EndGame();
        }
    }

    private void StartGame()
    {
        gameOver = false;
        isGameRunning = true;
        Debug.Log("Game Started!");
    }

    private void EndGame()
    {
        isGameRunning = false;
        Debug.Log("Game Over! Time's up.");
        // Tambahkan logika untuk mengakhiri permainan, seperti menampilkan UI game over
    }
}
