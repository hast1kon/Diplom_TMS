using System;
using Characters;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Others
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private EnemyPlayer[] enemyPlayers;
        [SerializeField] private GameObject ammoPrefab;
        [SerializeField] private GameObject healthPrefab;
        [SerializeField] private float spawnRange = 15f;
        [SerializeField] private int enemyCount;
        [SerializeField] private int waveNumber = 1;
        [SerializeField] private Text textWaveNumber;
        [SerializeField] private Text textEnemyNumber;
        private float randomPosY = 0.5f;

        private void Start()
        {
            SpawnEnemyWave(waveNumber);
            SpawnAmmo();
            SpawnHealth();

        }

        private void Update()
        {
            InstantiateSpawner();
        }

        public void InstantiateSpawner()
        {
            enemyCount = FindObjectsOfType<EnemyPlayer>().Length;
            textEnemyNumber.text = enemyCount.ToString();
            if (enemyCount==0)
            {
                waveNumber++;
                textWaveNumber.text = waveNumber.ToString();
                SpawnEnemyWave(waveNumber);
                SpawnAmmo();
                SpawnHealth();
            }
        }

        public void SpawnAmmo()
        {
            Instantiate(ammoPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
        public void SpawnHealth()
        {
            Instantiate(healthPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }

        public void SpawnEnemyWave(int enemiesToSpawn)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                for (int j = 0; j < enemyPlayers.Length; j++)
                {
                    Instantiate(enemyPlayers[j], GenerateSpawnPosition(), Quaternion.identity);
                }
            }
        }

        private Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(spawnRange, -spawnRange);
            float spawnPosZ = Random.Range(spawnRange, -spawnRange);
            
            Vector3 randomPos=new Vector3(spawnPosX,randomPosY,spawnPosZ);
            return randomPos;
        }
    }
}