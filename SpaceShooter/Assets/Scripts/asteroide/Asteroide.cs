using Assets.Scripts;
using Assets.Scripts.observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Asteroide : MonoBehaviour, Observavel
{

    public float Vida { get; set; }
    public float Dano { get; set; }

    public float Velocidade { get; set; }

    public int Ponto { get; set; }

    protected Rigidbody2D rb;
    protected AudioSource audioSource;
    protected SpriteRenderer spriteRenderer;
    protected Collider2D colliderAst;

    protected List<Observador> observadores;

    [SerializeField]
    protected GameObject explosionAST;

    [SerializeField]
    protected GameObject popUpDmg;

    protected void movimentacao() {
        rb.velocity = new Vector2(Velocidade * -1, 0);
    }

    public void tomarDano(int dano) {

        Vida -= dano;

        GameObject popUpDmgClone = Instantiate(popUpDmg, transform.position, Quaternion.identity);
        popUpDmgClone.GetComponentInChildren<MeshRenderer>().sortingLayerName = "VFX";
        popUpDmgClone.GetComponentInChildren<TextMesh>().text = dano.ToString();
        Destroy(popUpDmgClone, 1.5f);

        if (Vida <= 0) {
            audioSource.PlayOneShot(audioSource.clip);
            makeInvisible();
            GameObject animClone = Instantiate(explosionAST, transform);
            Destroy(gameObject, audioSource.clip.length + 1);
            Destroy(animClone, animClone.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
            //notifica
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

    //Metodo de apoio interno
    private void makeInvisible() {
        spriteRenderer.enabled = false;
        colliderAst.enabled = false;
    }

    //Observer
    public void cancelaRegistro(Observador obs) {
        observadores.Remove(obs);
    }

    public void notifica(object observavel, Eventos evento) {
        foreach (var observador in observadores) {
            observador.atualiza(this, evento);
        }
    }
    public void resgistraObs(Observador obs) {
        observadores.Add(obs);
    }
}
