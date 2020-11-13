using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.asteroide
{
    public class CriadorAsteroide : FabricaAleatoria, Observavel
    {

        [SerializeField]
        List<Asteroide> asteroides;

        List<Observador> observadores;
        
        public override void criaInstancia() {
            int pos = definirPosicao();
            if (contador == asteroides.Count)
                contador = 0;
            Asteroide ast = Instantiate(asteroides[contador++], spawnPoints[pos], Quaternion.identity);
            notifica(ast, Eventos.AST_CRIADO);
        }

        // Use this for initialization
        void Awake() {
            spawnPoints = new List<Vector3>();
            foreach (Transform spawnPoint in transform) {
                spawnPoints.Add(spawnPoint.position);
            }
            spawnPointsNum = spawnPoints.Count;

            observadores = new List<Observador>();
                       
        }


        //Observavel
        public void notifica(object observavel, Eventos evento) {
            foreach (var observador in observadores) {
                observador.atualiza(observavel, evento);
            }
        }
        public void resgistraObs(Observador obs) {
            print(observadores);
            observadores.Add(obs);
        }
        public void cancelaRegistro(Observador obs) {
                observadores.Remove(obs);
        }

    }
}