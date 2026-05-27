using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public float timing = 1f;
    public int dir;
    public GameObject prefab; // 생성할 프리팹
    public Transform spawnPoint; // 프리팹이 생성될 위치
    public float spawnDelay = 2f; // 생성 지연 시간

    private void Start()
    {
        // 주기적으로 프리팹 생성
        InvokeRepeating(nameof(SpawnPrefab), spawnDelay, spawnDelay); // nameof(어쩌고) == "어쩌고"
    }

    void Update()
    {
        timing -= Time.deltaTime;
        transform.Translate(new Vector3((0.1f * dir), 0));

        if (timing <= 0)
        {
            dir *= -1;
            timing = 2f;
        }
    }

    void SpawnPrefab()
    {
        if (prefab != null && spawnPoint != null)
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        else
            Debug.LogWarning("Prefab or Spawn Point is not assigned!");
    }
}
