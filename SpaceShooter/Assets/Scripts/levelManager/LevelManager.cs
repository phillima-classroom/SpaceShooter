using Assets.Scripts;
using Assets.Scripts.powerUp.fabrica;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    FabricaAleatoria criadorPUArma, criadorAsteroide;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("buscaPUArma", 2.0f, 4.0f);
        InvokeRepeating("buscaAsteroide", 1.0f, 3.0f);
    }

    // Update is called once per frame
    
    void buscaPUArma() {
        //Delegar para uma fabrica
        criadorPUArma.criaInstancia();
    }

    void buscaAsteroide() {
        //Delegar para uma fabrica
        criadorAsteroide.criaInstancia();
    }
}
