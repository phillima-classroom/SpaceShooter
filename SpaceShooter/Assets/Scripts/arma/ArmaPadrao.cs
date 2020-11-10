using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.arma
{
    public class ArmaPadrao : Arma
    {
        void Awake() {
            init(0.5f);
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