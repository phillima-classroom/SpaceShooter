using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;


    void Awake() {
        
        if (FindObjectsOfType<Audio>().Length>1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else
            DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    
   
}
