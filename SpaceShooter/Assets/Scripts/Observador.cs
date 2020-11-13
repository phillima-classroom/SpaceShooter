using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public interface Observador 
    {
        void atualiza(object observavel, Eventos evento);
    }
}