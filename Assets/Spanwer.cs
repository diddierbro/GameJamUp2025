using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objetoASpawnear;   // Prefab de la esfera recogible
    public Transform puntoSpawn;         // Punto alrededor del cual se generarán
    public float rango = 2f;             // Rango aleatorio alrededor del punto
    public float tiempoEntreSpawns = 5f; // Tiempo entre cada aparición

    private float tiempoProximoSpawn;

    void Start()
    {
        tiempoProximoSpawn = Time.time + tiempoEntreSpawns;
    }

    void Update()
    {
        if (Time.time >= tiempoProximoSpawn)
        {
            SpawnObjeto();
            tiempoProximoSpawn = Time.time + tiempoEntreSpawns;
        }
    }

    void SpawnObjeto()
    {
        Vector2 offset = Random.insideUnitCircle * rango;
        Vector3 posicionFinal = new Vector3(
            puntoSpawn.position.x + offset.x,
            puntoSpawn.position.y,
            puntoSpawn.position.z + offset.y
        );

        Instantiate(objetoASpawnear, posicionFinal, Quaternion.identity);
    }
}
