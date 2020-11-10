using UnityEngine;
using System.Collections;
using Assets.Scripts.municao;

namespace Assets.Scripts.arma.municao
{
    public class MunicaoHeavy : Municao
    {
        void Start() {
            Velocidade = 12;
            Dano = 25;
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector2(Velocidade, 0);
        }
    }
}