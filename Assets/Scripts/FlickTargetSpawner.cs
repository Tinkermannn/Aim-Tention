using System.Collections;
using UnityEngine;

public class FlickTargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab; // Target prefab to spawn
    [SerializeField] private float spawnInterval = 1f; // Interval between spawns
    [SerializeField] private float targetLifetime = 3f; // Lifetime of targets
    [SerializeField] private float gameDuration = 30f; // Durasi permainan dalam detik

    private bool isFlickModeActive = false;
    private bool isGameRunning = false;
    void Start()
    {
        Timer.gameOver = false;
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
            Timer.start = true;
            isGameRunning = true;
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

    private void StopGame()
    {
        isGameRunning = false;
        isFlickModeActive = false;
        Timer.start = false;

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