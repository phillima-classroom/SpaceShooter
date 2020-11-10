using UnityEngine;
using System.Collections;
using Assets.Scripts.municao;

namespace Assets.Scripts.asteroide
{
    public class AsteroidePadrao : Asteroide
    {
        void Awake() {
            init(50, 10, 3);
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