using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerPlace : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] float spawnInterval = 100f;
    [SerializeField] int limit = 30;
    private int count = 0;
    private GameObject _spawnedObject;

    void Start()
    {
        StartCoroutine(SpawnSpecter());
    }

    IEnumerator SpawnSpecter()
    {
        while (count < limit) {
        // Desactiva la capacidad de spawnear para evitar instanciar repetidamente

        // Espera el tiempo de intervalo antes de activar la capacidad de spawnear
        yield return new WaitForSeconds(spawnInterval);
        Spawn();
             }
    }

    void Spawn()
    {
        // Instancia un nuevo objeto en la posición del Spawner
        _spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}