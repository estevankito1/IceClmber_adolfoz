using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public Transform spawnPoint;    // Assign the spawn point object in the Inspector

    private GameObject currentEnemy;

    public bool someoneIsDead;

    void Spawn() 
    {

        if (someoneIsDead)
        {
            SpawnEnemy(); // Call the SpawnEnemy function if someone is dead
            someoneIsDead = false; // Reset the flag after spawning
        }


    }


    // Function to spawn a new enemy
    public void SpawnEnemy()
    {
        if (!currentEnemy) // Check if an enemy is already spawned
        {
            currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); // Instantiate the enemy
        }
    }

    // Function called when the enemy dies
    public void OnEnemyDeath()
    {
        // Destroy the current enemy
        //if (currentEnemy.activeSelf == false)
        //{
        //    //Destroy(currentEnemy);
        //    currentEnemy = null; // Clear the current enemy reference
        //    SpawnEnemy();
        //}
        SpawnEnemy();

        // Optionally, you can call SpawnEnemy here to respawn immediately after death
        //SpawnEnemy();
    }

}
