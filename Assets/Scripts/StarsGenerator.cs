using UnityEngine;

public class StarsGenerator : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject parentObject;
    public float minSpawnTime = 5, maxSpawnTime = 10;
    private float _time;
    private float GeneratedRandomTime;
    void Start()
    {
        GeneratedRandomTime = GenerateRandomTime();
    }

    void FixedUpdate()
    {
        _time += Time.deltaTime;

        if (_time >= GeneratedRandomTime)
        {
            SpawnObject();
            _time = 0;
        }
    }

    private float GenerateRandomTime()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void SpawnObject()
    {
        
        var obj = Instantiate(spawnObject, transform.position = GenerateRandomPosition(), transform.rotation);
        obj.transform.SetParent(parentObject.transform, true);
        obj.transform.localScale = Vector3.one * Random.Range(0.8f, 1.0f);
        print("generating");
    }

    private Vector2 GenerateRandomPosition()
    {
        return new Vector2(Random.Range(-16, 17), Random.Range(-9, 9.5f));
    }
    
}
