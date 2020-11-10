using UnityEngine;
using System.Collections;

namespace Assets.Scripts.municao
{
    
    public abstract class Municao : MonoBehaviour
    {
        protected Rigidbody2D rigidBody;
        public float Dano { get; set; } = 10;
        protected float Velocidade { get; set; } = 5;
    }
}