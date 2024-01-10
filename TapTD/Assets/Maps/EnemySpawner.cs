using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Splines;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private SplineContainer path;
    [SerializeField]
    private SerializedDictionary<EnemyConfig, float> spawnDelays;

    [SerializeField]
    private bool isRunning;
    public bool IsRunning
    { 
        get { return isRunning; }
        set
        {
            isRunning = value;
            OnRunningStateChanged(isRunning);
        }
    }

    private Coroutine spawningCoroutine;

    private void Start()
    {
        IsRunning = true;
    }

    private IEnumerator SpawnEnemies()
    {
        GameObject newEnemy;
        SplineAnimate splineAnimate;
        while (IsRunning)
        {
            foreach(var spawn in spawnDelays)
            {
                newEnemy = Instantiate(spawn.Key.EnemyPrefab);
                splineAnimate = newEnemy.GetComponent<SplineAnimate>();
                if(splineAnimate != null )
                    splineAnimate.Container = path;

                yield return new WaitForSeconds(spawn.Value);
            }
            yield return null;
        }
    }

    private void OnRunningStateChanged(bool isRunning)
    {
        if (isRunning)
        {
            if(spawningCoroutine == null)
                StartCoroutine(SpawnEnemies());
        }
        else
        {
            if(spawningCoroutine != null)
            {
                StopCoroutine(spawningCoroutine);
                spawningCoroutine = null;
            }
        }
    }
}
