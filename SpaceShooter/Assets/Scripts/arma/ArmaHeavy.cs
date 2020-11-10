using UnityEngine;
using System.Collections;

namespace Assets.Scripts.arma
{
    public class ArmaHeavy : Arma
    {

        private void Awake() {
            init(0.25f);
        }
        public override void atirar() {
            if (Time.time > NextFire) {
                NextFire = FireRate + Time.time;
                Vector3 pos = GameObject.FindGameObjectWithTag("Ponta_Nave").transform.position;
                Instantiate(municao, pos, Quaternion.identity);
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }
}