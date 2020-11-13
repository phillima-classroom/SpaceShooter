using UnityEngine;
using System.Collections;

namespace Assets.Scripts.observer
{
    public interface Observador 
    {
        void atualiza(object observavel, Eventos evento);
    }
}