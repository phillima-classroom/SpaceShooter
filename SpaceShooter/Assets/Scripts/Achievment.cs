using UnityEngine;
using System.Collections;
using Assets.Scripts.asteroide;

namespace Assets.Scripts
{
    public abstract class Achievment : MonoBehaviour, Observador
    {

        public abstract void unlock();

        public abstract void atualiza(object dados, Eventos evento);
    }
}