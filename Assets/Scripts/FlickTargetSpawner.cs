using System.Collections;
using TMPro;
using UnityEngine;

public class FlickTargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject EndStats; // Target prefab to spawn
    [SerializeField] private float spawnInterval = 1f; // Interval between spawns
    [SerializeField] private float targetLifetime = 3f; // Lifetime of targets

    public static bool isGameRunning = false;
    public static bool early = false;
    public static int targetCount = 0;
    public static int spawned = 0;

    private Vector3 statsInitPos;
    void Start()
    {
        statsInitPos = EndStats.transform.position;
        hideStats();
    }

    void Update ()
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
        if (Timer.gameOver == true){
            showStats();
            ClearTargets();
            StopGame();
            Timer.gameOver = false;
        }
    }
    private void StartNormal()
    {
        spawned = 0;
        hideStats();
        TargetShooter.shootCount = 1;
        TargetShooter.hitCount = 1;
        Activate();
        StartCoroutine(SpawnNormalTargets());
    }

    private void StartFlick()
    {
        spawned = 0;
        hideStats();
        TargetShooter.shootCount = 1;
        TargetShooter.hitCount = 1;
        Activate();
        StartCoroutine(SpawnFlickTargets());
    }
    private IEnumerator SpawnFlickTargets()
    {
        while (true)
        {
            SpawnFlickTarget();
            spawned++;
            yield return new WaitForSeconds(spawnInterval);

            if (Timer.gameOver == true||isGameRunning == false) break;
        }
    }

    private void SpawnFlickTarget()
    {
        Vector3 spawnPosition = TargetBounds.Instance.GetRandomPosition();
        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        float randomNumber = Random.Range(1.0f, targetLifetime);
        Destroy(target, randomNumber);  
    }

    private IEnumerator SpawnNormalTargets()
    {
        while (true)
        {
            if (targetCount<2){
                SpawnNormalTarget();
                targetCount++;
                spawned++;
            }
            yield return null;

            if (Timer.gameOver == true||isGameRunning == false) break;
        }
    }

    private void SpawnNormalTarget()
    {
        Vector3 spawnPosition = TargetBounds.Instance.GetRandomPosition();
        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }

    private void ClearTargets()
    {
        GameObject[] normalTargets = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject target in normalTargets)
        {
            Destroy(target);// Sembunyikan atau tampilkan
        }
        targetCount = 0;
    }

    public void Activate()
    {
        Timer.start = true;
        isGameRunning = true;
    }

    private void StopGame()
    {
        isGameRunning = false;
        Timer.start = false; // Tampilkan kembali target "Normal"
        Debug.Log("Game Over! Timer Ended.");
    }

    private void hideStats()
    {
        EndStats.transform.position += new Vector3(0,-10,0);
        Debug.Log("StatsHidden");
    }
    private void showStats()
    {
        EndStats.transform.position = statsInitPos;
        Debug.Log("StatsShown");
    }
}