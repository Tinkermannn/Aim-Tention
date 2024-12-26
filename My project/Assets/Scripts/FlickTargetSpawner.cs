using System.Collections;
using UnityEngine;

public class FlickTargetSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPrefab; // Target prefab to spawn

    [SerializeField]
    private float spawnInterval = 1f; // Interval between spawns

    [SerializeField]
    private float targetLifetime = 3f; // Lifetime of targets
    private StatManager statManager;

    public static bool isGameRunning = false;
    public static bool early = false;
    public static int targetCount = 0;
    public static int targetSpawned = 0;

    private StatManager Stats;

    void Start()
    {
        statManager = FindObjectOfType<StatManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && isGameRunning == false)
        {
            StartNormal();
        }
        if (early == true && isGameRunning == false && GameManager.flick == false)
        {
            StartNormal();
            early = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && isGameRunning == false)
        {
            StartFlick();
        }
        if (early == true && isGameRunning == false && GameManager.flick == true)
        {
            StartFlick();
            early = false;
        }
        if (Timer.gameOver == true)
        {
            StopGame();
            Timer.gameOver = false;
        }
    }

    private void StartNormal()
    {
        TargetShooter.shootCount = 0;
        Activate();
        StartCoroutine(SpawnNormalTargets());
    }

    private void StartFlick()
    {
        TargetShooter.shootCount = 0;
        Activate();
        StartCoroutine(SpawnFlickTargets());
    }

    private IEnumerator SpawnFlickTargets()
    {
        while (true)
        {
            SpawnFlickTarget();

            yield return new WaitForSeconds(spawnInterval);

            if (Timer.gameOver == true || isGameRunning == false)
                break;
        }
    }

    private void SpawnFlickTarget()
    {
        Vector3 spawnPosition = TargetBounds.Instance.GetRandomPosition();
        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        Destroy(target, targetLifetime);
    }

    private IEnumerator SpawnNormalTargets()
    {
        while (true)
        {
            if (targetCount < 2)
            {
                SpawnNormalTarget();
                targetCount++;
            }
            yield return null;

            if (Timer.gameOver == true || isGameRunning == false)
                break;
        }
    }

    private void SpawnNormalTarget()
    {
        Vector3 spawnPosition = TargetBounds.Instance.GetRandomPosition();
        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }

    private void Activate()
    {
        Timer.start = true;
        isGameRunning = true;
        statManager?.HideStats();
    }

    private void StopGame()
    {
        isGameRunning = false;
        Timer.start = false;
        statManager?.ShowStats();
        Debug.Log("Game Over! Timer Ended.");
    }
}
