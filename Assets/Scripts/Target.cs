using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private FlickTargetSpawner spawner;

    public void Initialize(FlickTargetSpawner spawner)
    {
        this.spawner = spawner;
    }

public void Hit()
{
    if (spawner != null && spawner.GetFlickModeStatus())
    {
        Destroy(gameObject);
    }
    else
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }
}

}
