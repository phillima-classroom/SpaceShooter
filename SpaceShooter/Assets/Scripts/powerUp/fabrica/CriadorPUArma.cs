using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.utils;

namespace Assets.Scripts.powerUp.fabrica
{
    public class CriadorPUArma : FabricaAleatoria
    {

        [SerializeField]
        List<PowerUpArma> puArmas;

        void Start() {
            spawnPoints = new List<Vector3>();
            foreach (Transform spawnPoint in transform) {
                spawnPoints.Add(spawnPoint.position);
            }
            spawnPointsNum = spawnPoints.Count;
        }

        public override void criaInstancia() {
            //Fabrica
            int pos = definirPosicao();
            if (contador == puArmas.Count)
                contador = 0;
            Instantiate(puArmas[contador++], spawnPoints[pos], Quaternion.identity);
        }
               

    }
}