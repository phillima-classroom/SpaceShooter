using Assets.Scripts.arma;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpArma : MonoBehaviour
{
    [SerializeField]
    Arma arma;
   
    AudioSource audioSource;

    Rigidbody2D rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-5, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        Nave nave = collision.GetComponent<Nave>();
        if (nave != null) {
           nave.setArma(Instantiate(arma,nave.transform));
           audioSource.PlayOneShot(audioSource.clip);
           Destroy(gameObject,audioSource.clip.length);
        }
        
    }
}
