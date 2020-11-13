using Assets.Scripts;
using Assets.Scripts.asteroide;
using Assets.Scripts.observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour, Observador
{

    Text textoPonto;
    int pontuacaoTotal;

    Observavel criadorAST;

    public void atualiza(object observavel, Eventos evento) {
        Asteroide ast = (Asteroide)observavel;
        if (evento == Eventos.AST_CRIADO) {
            ast.resgistraObs(this);
        } else if (evento == Eventos.AST_DESTRUIDO) {
            int ponto = ast.Ponto;
            pontuacaoTotal += ponto;
            textoPonto.text = pontuacaoTotal.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textoPonto = GetComponent<Text>();
        criadorAST = FindObjectOfType<CriadorAsteroide>();
        criadorAST.resgistraObs(this);
        pontuacaoTotal = 0;
    }

    
}
