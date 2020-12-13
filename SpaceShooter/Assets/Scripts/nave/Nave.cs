using Assets.Scripts.arma;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField]
    Arma arma;

    public float Velocidade { get; set; } = 4.0f;

    private void Awake() {
        arma = Instantiate(arma,transform);
    }

    private void Update() {
        movimentacao();
        atirar();
    }

    void movimentacao() {
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(new Vector2(0, Velocidade * -1 * Time.deltaTime));
        } else if (Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector2(0, Velocidade * 1 * Time.deltaTime));
        }
    }

    void atirar() {
        if (Input.GetKey(KeyCode.Space)) {
            arma.atirar();
        }
    }

    public void setArma(Arma arma) {
        Destroy(this.arma.gameObject);
        this.arma = arma;
    }

}