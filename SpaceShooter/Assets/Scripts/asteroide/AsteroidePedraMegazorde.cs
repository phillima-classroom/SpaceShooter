using UnityEngine;
using System.Collections;
using Assets.Scripts.arma.municao;

namespace Assets.Scripts.asteroide
{
    public class AsteroidePedraMegazorde : Asteroide
    {

        // Use this for initialization
        void Awake() {
            init(60, 10, 3, 10);
        }
        void Update() {
            movimento();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            Municao municao = collision.GetComponentInParent<Municao>();
            if (municao != null) {
                tomarDano(municao.Dano);
            }
        }
    }
}