using System.Collections;
using UnityEngine;

public class FlickTargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab; // Target prefab to spawn
    [SerializeField] private float spawnInterval = 1f; // Interval between spawns
    [SerializeField] private float targetLifetime = 3f; // Lifetime of targets
    [SerializeField] private float gameDuration = 30f; // Durasi permainan dalam detik

    private bool isFlickModeActive = false;
    private float timer = 0f; // Timer internal
    private bool isGameRunning = false;
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            if (isFlickModeActive && isGameRunning)
            {
                SpawnTarget();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnTarget()
    {
        Vector3 spawnPosition = TargetBounds.Instance.GetRandomPosition();
        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        Destroy(target, targetLifetime);
    }

    public void ActivateFlickMode(bool isActive)
    {
        isFlickModeActive = isActive;

        ToggleNormalTargets(!isActive);

        if (isActive)
        {
            StartGameTimer();
        }
        else
        {
            StopGame();
        }
    }

    private void ToggleNormalTargets(bool show)
    {
        GameObject[] normalTargets = GameObject.FindGameObjectsWithTag("Normal");
        foreach (GameObject target in normalTargets)
        {
            target.SetActive(show); // Sembunyikan atau tampilkan
        }
    }

    private void StartGameTimer()
    {
        timer = 0f;
        isGameRunning = true;
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        while (timer < gameDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        StopGame(); // Hentikan permainan setelah waktu habis
    }

    private void StopGame()
    {
        isGameRunning = false;
        isFlickModeActive = false;

        ToggleNormalTargets(true); // Tampilkan kembali target "Normal"
        Debug.Log("Game Over! Timer Ended.");
    }

    public bool GetFlickModeStatus()
    {
        return isFlickModeActive;
    }

    private int destroyedTargets = 0;

    public void OnTargetDestroyed()
    {
        destroyedTargets++;
        Debug.Log($"Destroyed Targets: {destroyedTargets}");
    }
}