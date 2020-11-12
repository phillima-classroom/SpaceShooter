using UnityEngine;
using System.Collections;
using Assets.Scripts.asteroide;

namespace Assets.Scripts
{
    public interface Observavel
    {
        void notify(object entidade, Eventos evento);
        void registraObservador(Observador observador);
        void cancelaObservador(Observador observador);
            
    }
}