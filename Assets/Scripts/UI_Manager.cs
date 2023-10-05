using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text healthText;
    public GameObject replayButton;
    public int totalScore = 0;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // totalScore.ToString();
        scoreText.text = $"Score: {totalScore.ToString()}";
        if(player != null)
            healthText.text = $"Health: {player.GetComponent<Player>().m_Health.ToString()}";
        else
            healthText.text = "Health: 0";
    }
}
