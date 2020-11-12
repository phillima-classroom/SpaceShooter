using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public interface Observavel 
    {

        void resgistraObs(Observador obs);
        void cancelaRegistro(Observador obs);
        void notifica(object observavel, Eventos evento);
        
    }
}