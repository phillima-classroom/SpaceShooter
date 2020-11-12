using Assets.Scripts;
using Assets.Scripts.asteroide;
using Assets.Scripts.asteroide.fabrica;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour, Observador
{
    static Text text;
    public static int pont = 0;

    Observavel observaCriacaoAST;
    
    // Start is called before the first frame update
    void Start() {
        text = GetComponent<Text>();
        observaCriacaoAST = FindObjectOfType<CriadorAsteroide>();
        observaCriacaoAST.registraObservador(this);

    }
  
    //Observador
    public void atualiza(object dados, Eventos evento) {
        if(evento == Eventos.AST_CRIADO) {
            Asteroide ast = (Asteroide)dados;
            ast.registraObservador(this);
        }else if(evento == Eventos.AST_DESTRUIDO) {
            Asteroide ast = (Asteroide)dados;
            pont += ast.Ponto;
            text.text = pont.ToString();
        }
    }
}
