using Assets.Scripts.asteroide;
using Assets.Scripts.asteroide.fabrica;
using Assets.Scripts.powerup.fabrica;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    CriadorAsteroide criadorAsteroide;

    [SerializeField]
    CriadorPUArma criadorPowerUpArma;

    private void Awake() {
        criadorAsteroide = Instantiate(criadorAsteroide);
        InvokeRepeating("criaAsteroide", 0.0f, 2.0f);
        InvokeRepeating("criaPUArma", 2.0f, 4.0f);
    }
    // Update is called once per frame
    
    void criaAsteroide() {
        criadorAsteroide.criaAsteroide();
    }

    void criaPUArma() {
        criadorPowerUpArma.criaPUArma();
    }
}
