using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void OnReplayButtonPressed()
    {
        SceneManager.LoadScene("Main_Game_Scene");
    }
}