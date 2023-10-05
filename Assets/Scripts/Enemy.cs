using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float m_Health;
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_DamageAmount;
    [SerializeField] private EnemyData enemyDataRef;
    [SerializeField] private UI_Manager uiManager;

    private Player playerRef;
    private GameObject playerObj;

    private void Start()
    {
        playerObj       = GameObject.FindGameObjectWithTag("Player");
        uiManager       = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UI_Manager>();

        if(playerObj != null)
            playerRef = playerObj.GetComponent<Player>();

        m_Health        = enemyDataRef.health;
        m_Speed         = enemyDataRef.moveSpeed;
        m_DamageAmount  = enemyDataRef.damage;
    }

    private void Update()
    {
        if(playerObj)
        {
            Move();
        }

        KillPlayer();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, m_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") == true)
        {
            int randAttackAmount = Random.Range(4, m_DamageAmount);
            this.Attack(randAttackAmount);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Destroy player's gameobject when health amount is equal to zero
    /// </summary>
    private void KillPlayer()
    {
        if(playerRef.m_Health <= 0) 
        {
            // Destroy player object
            Destroy(playerObj.gameObject);
            // Destroy all enemies
            Destroy(GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnManager>().parentObj.gameObject);

            Time.timeScale = 0;
            SceneManager.LoadScene("Replay_Menu");
        }       
    }

    private void Attack(int damageAmount)
    {
        if(this.playerRef.m_Health < 0) 
        {
            this.playerRef.m_Health = 0;
        }
        
        this.playerRef.m_Health -= damageAmount;
    }

    public void Die(Enemy enemy)
    {
        if(enemy.m_Health <= 0)
        {
            Destroy(enemy.gameObject);
            uiManager.totalScore++;
        }
        if(enemy.m_Health < 0)
        {
            enemy.m_Health = 0;
        }
    }
}
