using UnityEngine;
using System.Collections;
using Assets.Scripts.observer;
using Assets.Scripts.asteroide;

namespace Assets.Scripts.achievment
{
    public class Achievment5AST : Achievment
    {
        [SerializeField]
        GameObject achivPopUP;

        int numAstDestruido;

        private void Start() {
            FindObjectOfType<CriadorAsteroide>().resgistraObs(this);
        }

        public override void atualiza(object observavel, Eventos evento) {
            Asteroide ast = (Asteroide)observavel;
            if (evento == Eventos.AST_CRIADO) {
                ast.resgistraObs(this);
            } else if (evento == Eventos.AST_DESTRUIDO) {
                numAstDestruido++;
                if (numAstDestruido >= 5)
                    unlock();
            }
        }

        protected override void unlock() {
            if (!unlocked) {
                unlocked = true;
                Vector2 pos = GameObject.FindGameObjectWithTag("Achiev_Spawner").transform.position;
                GameObject achivPopUpClone = Instantiate(achivPopUP, pos, Quaternion.identity);
                Destroy(achivPopUpClone, 2f);
                Destroy(gameObject);
            }
        }
    }
}