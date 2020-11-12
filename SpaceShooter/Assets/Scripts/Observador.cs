using UnityEngine;
using UnityEditor;
using Assets.Scripts.asteroide;

namespace Assets.Scripts
{
    public interface Observador
    {
        void atualiza(object dados, Eventos evento);
    }
}