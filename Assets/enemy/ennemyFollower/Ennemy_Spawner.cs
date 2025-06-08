using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Spawner : MonoBehaviour
{
    [SerializeField] // sert à qu'on le voit dans l'inspecteur
    private GameObject _ennemyPrefab;
    [SerializeField]
    private float _minimumSpawnTime;
    [SerializeField]
    private float _maximumSpawnTime;

    private float _untilspawnTime;

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _untilspawnTime -= Time.deltaTime;

        if (_untilspawnTime <= 0 )
        {
            Instantiate(_ennemyPrefab,transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _untilspawnTime = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
