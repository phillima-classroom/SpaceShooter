using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.observer;

namespace Assets.Scripts.asteroide.fabrica
{
    public class CriadorAsteroide : FabricaAleatoria, Observavel
    {
        [SerializeField]
        List<Asteroide> asteroides;

        List<Observador> observadores;

        void Awake() {
            spawnPoints = new List<Vector3>();
            foreach (Transform spawnPoint in transform) {
                spawnPoints.Add(spawnPoint.position);
            }
            spawnPointsNum = spawnPoints.Count;

            observadores = new List<Observador>();
        }

        public override void criaInstancia() {
            //Fabrica
            int pos = definirPosicao();
            if (contador == asteroides.Count)
                contador = 0;
            Asteroide ast = Instantiate(asteroides[contador++], spawnPoints[pos], Quaternion.identity);
            notifica(ast, Eventos.AST_CRIADO);
        }

        //Observer
        public void registarObservador(Observador obs) {
            print(obs);
            observadores.Add(obs);
        }

        public void cancelaObservador(Observador obs) {
            observadores.Remove(obs);
        }

        public void notifica(object observavel, Eventos evento) {
            foreach (var observador in observadores) {
                observador.atualiza(observavel, evento);
            }
        }
    }
}