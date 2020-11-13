using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {

        [SerializeField]
        FabricaAleatoria criadorPUArma, criadorAst;


        // Use this for initialization
        void Awake() {
            InvokeRepeating("buscaPUArma", 2.0f, 3.0f);
            InvokeRepeating("buscaAsteroide", 0.0f, 2.0f);
        }
               

        void buscaAsteroide() {
            //Delegando para a fabrica
            criadorAst.criaInstancia();
        }

        void buscaPUArma() {
            //Delegando para a fabrica
            criadorPUArma.criaInstancia();
        }
    }
}