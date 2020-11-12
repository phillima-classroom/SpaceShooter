using UnityEngine;
using System.Collections;
using Assets.Scripts.asteroide;
using Assets.Scripts.asteroide.fabrica;

namespace Assets.Scripts
{
    public class Achiv5AST : Achievment
    {
        int numAstMorto;
        bool unlocked = false;
        [SerializeField]
        GameObject achiv;

        private void Start() {
            numAstMorto = 0;
            FindObjectOfType<CriadorAsteroide>().registraObservador(this);
        }

        public override void atualiza(object dados, Eventos evento) {
            if(evento == Eventos.AST_DESTRUIDO) {
                Asteroide ast = (Asteroide)dados;
                numAstMorto++;
                if (numAstMorto >= 5 && !unlocked)
                    unlock();
            } else if(evento == Eventos.AST_CRIADO) {
                Asteroide ast = (Asteroide)dados;
                ast.registraObservador(this);
            }
        }

        public override void unlock() {
            unlocked = true;
            Vector3 pos = GameObject.FindGameObjectWithTag("Achiv_Spawner").transform.position;
            GameObject achivClone = Instantiate(achiv,pos,Quaternion.identity);
            Destroy(achivClone, 3.0f);
            Destroy(this);
            Destroy(gameObject);
        }
    }
}