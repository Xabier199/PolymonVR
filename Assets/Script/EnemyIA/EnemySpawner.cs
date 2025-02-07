using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject enemyPrefab; // Prefab del enemigo
        public int spawnCount; // Cantidad de enemigos a spawnear de este tipo
        public string tag; // Tag del enemigo para identificaci�n
    }

    [SerializeField] private EnemyType[] enemyTypes; // Array de tipos de enemigos
    [SerializeField] private Vector3 spawnAreaCenter = Vector3.zero; // Centro del �rea de spawn
    [SerializeField] private Vector3 spawnAreaSize = new Vector3(10, 1, 10); // Tama�o del �rea de spawn (X, Y, Z)
    [SerializeField] private float checkInterval = 5f; // Intervalo de tiempo para verificar y spawnear enemigos

    private void Start()
    {
        SpawnEnemies();
        InvokeRepeating("CheckAndSpawnEnemies", checkInterval, checkInterval);
    }

    private void SpawnEnemies()
    {
        foreach (EnemyType enemyType in enemyTypes)
        {
            for (int i = 0; i < enemyType.spawnCount; i++)
            {
                Vector3 spawnPosition = GenerateRandomPosition();
                Instantiate(enemyType.enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private void CheckAndSpawnEnemies()
    {
        foreach (EnemyType enemyType in enemyTypes)
        {
            GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag(enemyType.tag);
            int enemiesToSpawn = enemyType.spawnCount - existingEnemies.Length;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Vector3 spawnPosition = GenerateRandomPosition();
                Instantiate(enemyType.enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        // Genera una posici�n aleatoria dentro del �rea de spawn
        float spawnX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float spawnY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
        float spawnZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);
        return new Vector3(spawnX, spawnY, spawnZ);
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el �rea de spawn en la ventana de Scene para visualizaci�n
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
}


/*using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject enemyPrefab; // Prefab del enemigo
        public int spawnCount; // Cantidad de enemigos a spawnear de este tipo
    }

    [SerializeField] private EnemyType[] enemyTypes; // Array de tipos de enemigos
    [SerializeField] private Vector3 spawnAreaCenter = Vector3.zero; // Centro del �rea de spawn
    [SerializeField] private Vector3 spawnAreaSize = new Vector3(10, 1, 10); // Tama�o del �rea de spawn (X, Y, Z)

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (EnemyType enemyType in enemyTypes)
        {
            for (int i = 0; i < enemyType.spawnCount; i++)
            {
                Vector3 spawnPosition = GenerateRandomPosition();
                Instantiate(enemyType.enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        // Genera una posici�n aleatoria dentro del �rea de spawn
        float spawnX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float spawnY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
        float spawnZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);
        return new Vector3(spawnX, spawnY, spawnZ);
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el �rea de spawn en la ventana de Scene para visualizaci�n
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
}*/
