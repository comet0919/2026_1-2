using NUnit.Framework;
using UnityEngine;

public class NewMonoBehaviourScript2 : MonoBehaviour
{
    public GameObject coiPprefabs;
    public GameObject missilePrefabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawnlnterval = 0.5f;
    public float maxspawnlnterval = 2.0f;

    public float timer = 0.0f;
    public float nextSpawnTime;

    [Header("동전 스폰 확률 설정")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;
    void Start()
    {
        setNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > nextSpawnTime)
        {
            SpawnObject();
            timer = 0.0f;
            setNextSpawnTime();
        }
    }

    void SpawnObject()
    {
        Transform spawnTransform = transform;
        int randomValue = Random.Range(0, 100);

        if(randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        {
            Instantiate(missilePrefabs, spawnTransform.position, spawnTransform.rotation);
        }
    }
    void setNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnlnterval, maxspawnlnterval);
    }
}
