using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.powerUp
{
    public class CriadorPUArma : FabricaAleatoria
    {

        [SerializeField]
        List<PowerUpArma> puArmas;

        public override void criaInstancia() {
            int pos = definirPosicao();

            if (contador == puArmas.Count)
                contador = 0;
            Instantiate(puArmas[contador++], spawnPoints[pos], Quaternion.identity);
        }

        // Use this for initialization
        void Start() {
            spawnPoints = new List<Vector3>();
            foreach (Transform spawnPoint in transform) {
                spawnPoints.Add(spawnPoint.position);
            }
            spawnPointsNum = spawnPoints.Count;
        }
               
    }
}