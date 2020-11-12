using UnityEngine;
using System.Collections;

namespace Assets.Scripts.observer
{
    public interface Observavel 
    {
        void registarObservador(Observador obs);
        void cancelaObservador(Observador obs);
        void notifica(object observavel, Eventos evento);
        
    }
}