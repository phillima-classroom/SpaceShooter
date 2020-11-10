using UnityEngine;
using System.Collections;

namespace Assets.Scripts.asteroide
{
    public abstract class Asteroide : MonoBehaviour
    {
        protected float Vida { get; set; }
        protected float Dano { get; set; }
        protected float Velocidade { get; set; } 

        protected Rigidbody2D rb;
        protected AudioSource audioSource;
        protected SpriteRenderer spriteRenderer;
        protected Collider2D colliderAst;

        [SerializeField]
        protected GameObject explosionAST;

        protected void movimento() {
            rb.velocity = new Vector2(Velocidade*-1, 0);
        }

        protected void tomarDano(float danoRecebido) {
            Vida -= danoRecebido;
            if(Vida <= 0) {
                audioSource.PlayOneShot(audioSource.clip);
                makeInvisible();
                GameObject animClone = Instantiate(explosionAST,transform);
                Destroy(gameObject, audioSource.clip.length + 1);
                Destroy(animClone, animClone.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
            }
        }

        protected void init(float vida, float dano, float velocidade) {
            Dano = dano;
            Vida = vida;
            Velocidade = velocidade;
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
            colliderAst = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void makeInvisible() {
            spriteRenderer.enabled = false;
            colliderAst.enabled = false;
        }
    }
}