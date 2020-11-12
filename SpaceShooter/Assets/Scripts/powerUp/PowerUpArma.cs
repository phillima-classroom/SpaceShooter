using Assets.Scripts.arma;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpArma : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Arma arma;

    Rigidbody2D rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-5,0);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Nave nave = collision.GetComponent<Nave>();
        if (nave != null) {
            nave.setArma(Instantiate(arma,nave.transform));
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
