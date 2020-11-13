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

        public float FireRate { get; set; }
        public float NextFire { get; set; }

        protected void init(float fireRate) {
            FireRate = fireRate;
            NextFire = 0.0f;
            audioSource = GetComponent<AudioSource>();
        }

        public abstract void atirar();
        
    }
}