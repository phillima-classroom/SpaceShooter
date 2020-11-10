using UnityEngine;
using System.Collections;
using Assets.Scripts.municao;
using System;

namespace Assets.Scripts.arma
{
    public abstract class Arma : MonoBehaviour {
        [SerializeField]
        protected Municao municao;

        protected AudioSource audioSource;

        public float FireRate { get; set; }
        public float NextFire { get; set; } = 0.0f;

        public abstract void atirar();
        protected void init(float fireRate){
            FireRate = fireRate;
            audioSource = GetComponent<AudioSource>();
            NextFire = 0.0f;
        }

    }
        
}