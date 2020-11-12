using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts.asteroide.fabrica
{
    public class CriadorAsteroide : MonoBehaviour, Observavel
    {

        [SerializeField]
        List<Asteroide> asteroides;

        List<Observador> observadores;

        List<Vector3> spawnPoints;
        int spawnPointsNum;
        bool gerarOrdem = false;
        int contOrdemSpawn;
        List<int> ordemSpawn;

        private void Awake() {

            observadores = new List<Observador>();

            spawnPoints = new List<Vector3>();
            foreach (Transform spawnPoint in transform) {
                spawnPoints.Add(spawnPoint.position);
            }
            spawnPointsNum = spawnPoints.Count;
        }

        public Asteroide criaAsteroide() {
            int pos = definirPosicao();
            Asteroide ast = Instantiate(asteroides[Random.Range(0, asteroides.Count)], spawnPoints[pos], Quaternion.identity);
            notify(ast, Eventos.AST_CRIADO);
            return ast;
        }

        private int definirPosicao() {
            
            if (!gerarOrdem) {
                ordemSpawn = getUniqueRandomArray(0, spawnPointsNum, spawnPointsNum);
                contOrdemSpawn = 0;
            } else if(contOrdemSpawn == ordemSpawn.Count-1){
                gerarOrdem = false;
            }
            return ordemSpawn[contOrdemSpawn++];

        }

        public List<int> getUniqueRandomArray(int min, int max, int count) {
            int[] result = new int[count];
            List<int> numbersInOrder = new List<int>();
            for (var x = min; x < max; x++) {
                numbersInOrder.Add(x);
            }
            for (var x = 0; x < count; x++) {
                var randomIndex = UnityEngine.Random.Range(0, numbersInOrder.Count);
                result[x] = numbersInOrder[randomIndex];
                numbersInOrder.RemoveAt(randomIndex);
            }
            return new List<int>(result);
        }

        //Observavel
        
        public void cancelaObservador(Observador observador) {
            observadores.Remove(observador);
        }
        
        public void notify(object observavel, Eventos evento) {
            foreach (var observador in observadores) {
                observador.atualiza(observavel, evento);
            }
        }

        public void registraObservador(Observador observador) {
            observadores.Add(observador);
        }
        //Fim observavel
    }
}