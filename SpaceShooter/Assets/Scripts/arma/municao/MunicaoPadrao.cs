using UnityEngine;
using System.Collections;

namespace Assets.Scripts.arma.municao
{
    public class MunicaoPadrao : Municao
    {

        // Use this for initialization
        void Start() {
            Velocidade = 6;
            Dano = 10;
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector2(Velocidade,0);
        }
               
    }
}