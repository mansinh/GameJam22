using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FloatVariable health;
    [SerializeField] private FloatVariable score;
    [SerializeField] private FloatVariable projectileSpeed;
    [SerializeField] private FloatVariable enemyCooldown;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private float baseProjectileSpeed;
    [SerializeField] private float baseEnemyCooldown;

    [SerializeField] private int[] scoreThresholds;
    [SerializeField] int level = 1;
    int numberOfEnemies = 1;
    [SerializeField] float changeEnemiesTime;
    float timeSinceChangeEnemies;
    float timeSinceAction = 0;
    List<Enemy> activeEnemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        score.value = 0;
        enemyCooldown.value = baseEnemyCooldown;
        projectileSpeed.value = baseProjectileSpeed;
        activeEnemies.Add(enemies[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (score.value > (level + 1)*20)
        {
            level++;

            if (level >= 1)
            {
                projectileSpeed.value = Mathf.Min(baseProjectileSpeed + 0.2f * level,12);
                enemyCooldown.value = Mathf.Max(baseEnemyCooldown - 0.01f* level,0.15f);
            }

            if (level >= 4)
            {
                numberOfEnemies = 2;
            }
        }
        
        

        if (level >= 2)
        {
            if (timeSinceChangeEnemies > changeEnemiesTime)
            {
                ChangeEnemies();
                timeSinceChangeEnemies = 0;
            }
            timeSinceChangeEnemies += Time.deltaTime;        
        }

        if (timeSinceAction > enemyCooldown.value)
        {
            int enemyIndex = (int)(Random.value * activeEnemies.Count);
            activeEnemies[enemyIndex].RandomAction();
            timeSinceAction = 0;
        }
        timeSinceAction += Time.deltaTime;
    }

    void ChangeEnemies() {    
        foreach (Enemy enemy in enemies) 
        {
            enemy.gameObject.SetActive(false);
        }
        activeEnemies.Clear();
        for (int i = 0; i < numberOfEnemies;i++) 
        {
            int enemyIndex = (int)(Random.value * enemies.Length);
            enemies[enemyIndex].gameObject.SetActive(true);
            activeEnemies.Add(enemies[enemyIndex]);
        }
    }
}
