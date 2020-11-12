using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.observer;
using Assets.Scripts.asteroide.fabrica;

namespace Assets.Scripts.ui
{
    public class UIScore : MonoBehaviour, Observador
    {
        Text textoPonto;
        int pontuacaoTotal;

        Observavel criadorAST;

        public void atualiza(object observavel, Eventos evento) {
            Asteroide ast = (Asteroide)observavel;
            if (evento == Eventos.AST_CRIADO) {
                ast.registarObservador(this);
            }else if (evento == Eventos.AST_DESTRUIDO) {
                int ponto = ast.Ponto;
                pontuacaoTotal += ponto;
                textoPonto.text = pontuacaoTotal.ToString();

            }
        }

        private void Start() {
            textoPonto = GetComponent<Text>();
            criadorAST = FindObjectOfType<CriadorAsteroide>();
            print(criadorAST);
            criadorAST.registarObservador(this);
            pontuacaoTotal += 0;
        }




    }
}