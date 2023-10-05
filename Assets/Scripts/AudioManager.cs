using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;


    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            audioSource.Stop();
        }
    }
}