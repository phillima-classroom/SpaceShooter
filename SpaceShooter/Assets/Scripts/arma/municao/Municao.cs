using UnityEngine;
using System.Collections;

namespace Assets.Scripts.arma.municao
{
    public abstract class Municao : MonoBehaviour
    {

        protected Rigidbody2D rigidBody;

        public int Dano { get; set; } = 10;

        protected float Velocidade { get; set; } = 5;

    }
}