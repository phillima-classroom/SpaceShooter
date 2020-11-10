using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Assets.Scripts.powerup.fabrica
{
    public class CriadorPUArma : MonoBehaviour
    {

        [SerializeField]
        List<PowerUpArma> puArmas;

        List<Vector3> spawnPoints;
        int spawnPointsNum;
        bool gerarOrdem = false;
        int contOrdemSpawn;
        List<int> ordemSpawn;

        int contador = 0;

        private void Awake() {
            spawnPoints = new List<Vector3>();
            foreach (Transform spawnPoint in transform) {
                spawnPoints.Add(spawnPoint.position);
            }
            spawnPointsNum = spawnPoints.Count;
        }

        public PowerUpArma criaPUArma() {
            int pos = definirPosicao();
            if (contador == puArmas.Count)
                contador = 0;
            PowerUpArma puArma = Instantiate(puArmas[contador++], spawnPoints[pos], Quaternion.identity);
            return puArma;
        }

       
        private int definirPosicao() {

            if (!gerarOrdem) {
                ordemSpawn = getUniqueRandomArray(0, spawnPointsNum, spawnPointsNum);
                contOrdemSpawn = 0;
            } else if (contOrdemSpawn == ordemSpawn.Count - 1) {
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
                var randomIndex = Random.Range(0, numbersInOrder.Count);
                result[x] = numbersInOrder[randomIndex];
                numbersInOrder.RemoveAt(randomIndex);
            }
            return new List<int>(result);
        }
    }
}