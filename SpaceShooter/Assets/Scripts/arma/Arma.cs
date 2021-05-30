using UnityEngine;
using System.Collections;
using Assets.Scripts.arma.municao;

namespace Assets.Scripts.arma
{
    public abstract class Arma : MonoBehaviour
    {
        [SerializeField]
        protected Municao municao;

        protected AudioSource audioSource;

        [SerializeField]
        protected float fireRate;
        public float NextFire { get; set; }

        protected void init(float fireRate) {
            this.fireRate = fireRate;
            NextFire = 0.0f;
            audioSource = GetComponent<AudioSource>();
        }

        public abstract void atirar();

    }
}