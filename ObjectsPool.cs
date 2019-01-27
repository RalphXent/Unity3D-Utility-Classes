using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class uses Lists to use objects from a pool.
/// When an object is needed, get it from the pool.
/// If an object is not needed anymore, it returns to the pool.
/// </summary>
public static class ObjectsPool{

	// Create a pool for Enemy Bullets
    static GameObject prefabEnemyBullet;
    static List<GameObject> poolEnemyBullet;

	// Create a pool for Player Bullets
    static GameObject prefabPlayerBullet;
    static List<GameObject> poolPlayerBullet;

    /// <summary>
    /// Initializes the enemy bullet pool
    /// </summary>
    public static void InitializeEnemyBullet()
    {
        // create and fill pool
        prefabEnemyBullet = Resources.Load<GameObject>("EnemyBullet");
        poolEnemyBullet = new List<GameObject>(0);
        for (int i = 0; i < poolEnemyBullet.Capacity; i++)
        {
            poolEnemyBullet.Add(GetNewEnemyBullet());
        }
    }

    /// <summary>
    /// Gets a enemy bullet object from the pool
    /// </summary>
    /// <returns>enemy bullets</returns>
    public static GameObject GetEnemyBullets()
    {
        // check for an available object in the pool
        if (poolEnemyBullet.Count > 0)
        {
            GameObject enemyBullets = poolEnemyBullet[poolEnemyBullet.Count - 1];
            poolEnemyBullet.RemoveAt(poolEnemyBullet.Count - 1);
            return enemyBullets;
        }
        else
        {
            // the pool is empty, so expand pool and return new object
            poolEnemyBullet.Capacity++;
            return GetNewEnemyBullet();
        }
    }

    /// <summary>
    /// Returns an enemy bullet object to the pool
    /// </summary>
    /// <param name="enemyBullet">enemy bullets</param>
    public static void ReturnEnemyBullets(GameObject enemyBullet)
    {
        enemyBullet.SetActive(false);
        enemyBullet.GetComponent<EnemyBullet>().StopMoving();
        poolEnemyBullet.Add(enemyBullet);
    }

    /// <summary>
    /// Gets a new enemy bullet object
    /// </summary>
    /// <returns>enemy bullets</returns>
    static GameObject GetNewEnemyBullet()
    {
        GameObject enemyBullet = GameObject.Instantiate(prefabEnemyBullet);
        enemyBullet.GetComponent<EnemyBullet>().Initialize();
        enemyBullet.SetActive(false);
        return enemyBullet;
    }


    /// <summary>
    /// Initializes the player bullet pool
    /// </summary>
    public static void InitializePlayerBullet()
    {
        // create and fill pool
        prefabPlayerBullet = Resources.Load<GameObject>("PlayerBullet");
        poolPlayerBullet = new List<GameObject>(1);
        for (int i = 0; i < poolPlayerBullet.Capacity; i++)
        {
            poolPlayerBullet.Add(GetNewPlayerBullet());
        }
    }

    /// <summary>
    /// Gets a player bullet object from the pool
    /// </summary>
    /// <returns>player bullets</returns>
    public static GameObject GetPlayerBullets()
    {
        // check for available object in pool
        if (poolPlayerBullet.Count > 0)
        {
            GameObject playerBullets = poolPlayerBullet[poolPlayerBullet.Count - 1];
            poolPlayerBullet.RemoveAt(poolPlayerBullet.Count - 1);
            return playerBullets;
        }
        else
        {
            // the pool is empty, so expand pool and return new object
            poolPlayerBullet.Capacity++;
            return GetNewPlayerBullet();
        }
    }

    /// <summary>
    /// Returns a player bullet object to the pool
    /// </summary>
    /// <param name="playerBullet">player bullets</param>
    public static void ReturnPlayerBullets(GameObject playerBullet)
    {
        playerBullet.SetActive(false);
        playerBullet.GetComponent<PlayerBullet>().StopMoving();
        poolPlayerBullet.Add(playerBullet);
    }

    /// <summary>
    /// Gets a new player bullet object
    /// </summary>
    /// <returns>player bullets</returns>
    static GameObject GetNewPlayerBullet()
    {
        GameObject playerBullet = GameObject.Instantiate(prefabPlayerBullet);
        playerBullet.GetComponent<PlayerBullet>().Initialize();
        playerBullet.SetActive(false);
        return playerBullet;
    }
}
