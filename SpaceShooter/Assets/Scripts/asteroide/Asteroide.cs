using UnityEngine;
using System.Collections;
using Assets.Scripts.observer;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public abstract class Asteroide : MonoBehaviour, Observavel
    {

        protected float Vida { get; set; }
        protected float Dano { get; set; }
        protected float Velocidade { get; set; }
        public int Ponto { get; set; }

        protected Rigidbody2D rb;
        protected AudioSource audioSource;
        protected SpriteRenderer spriteRenderer;
        protected Collider2D colliderAst;

        List<Observador> observadores;

        [SerializeField]
        protected GameObject explosionAST;

        [SerializeField]
        protected GameObject popUpDmg;

        protected void movimento() {
            rb.velocity = new Vector2(Velocidade * -1, 0);
        }

        protected void tomarDano(float danoRecebido) {
            Vida -= danoRecebido;
            GameObject popUpDmgClone = Instantiate(popUpDmg, transform.position, Quaternion.identity);
            popUpDmgClone.GetComponentInChildren<MeshRenderer>().sortingLayerName = "VFX";
            popUpDmgClone.GetComponentInChildren<TextMesh>().text = danoRecebido.ToString();
            Destroy(popUpDmgClone, 1.5f);
            if (Vida <= 0) {
                audioSource.PlayOneShot(audioSource.clip);
                makeInvisible();
                GameObject animClone = Instantiate(explosionAST, transform);
                Destroy(gameObject, audioSource.clip.length + 1);
                Destroy(animClone, animClone.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
                notifica(this, Eventos.AST_DESTRUIDO);
            }
        }

        protected void init(float vida, float dano, float velocidade, int ponto) {
            Dano = dano;
            Vida = vida;
            Velocidade = velocidade;
            Ponto = ponto;
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
            colliderAst = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            observadores = new List<Observador>();
        }
        private void makeInvisible() {
            spriteRenderer.enabled = false;
            colliderAst.enabled = false;
        }

        public void registarObservador(Observador obs) {
            observadores.Add(obs);
        }

        public void cancelaObservador(Observador obs) {
            observadores.Remove(obs);
        }

        public void notifica(object observavel, Eventos evento) {
            foreach (var observador in observadores) {
                observador.atualiza(this, evento);
            }
        }
    }
}