using UnityEngine;
using System.Collections;
using Assets.Scripts.observer;
using Assets.Scripts.asteroide.fabrica;

namespace Assets.Scripts.achievment
{
    public class Achievement5AST : Achievement
    {

        int numAstMorto;
        bool unlocked = false;
        [SerializeField]
        GameObject achiv;
        protected override void unlock() {
            unlocked = true;
            Vector3 pos = GameObject.FindGameObjectWithTag("Achiev_Spawner").transform.position;
            GameObject achivClone = Instantiate(achiv, pos, Quaternion.identity);
            Destroy(achivClone, 3.0f);
            Destroy(this);
            Destroy(gameObject);
        }

        public override void atualiza(object observavel, Eventos evento) {
            if (evento == Eventos.AST_DESTRUIDO) {
                Asteroide ast = (Asteroide)observavel;
                numAstMorto++;
                if (numAstMorto >= 5 && !unlocked)
                    unlock();
            } else if (evento == Eventos.AST_CRIADO) {
                Asteroide ast = (Asteroide)observavel;
                ast.registarObservador(this);
            }
        }

        private void Start() {
            numAstMorto = 0;
            FindObjectOfType<CriadorAsteroide>().registarObservador(this);
        }

    }
}