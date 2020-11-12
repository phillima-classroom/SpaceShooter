using UnityEngine;
using System.Collections;
using Assets.Scripts.observer;

namespace Assets.Scripts.achievment
{
    public abstract class Achievement : MonoBehaviour, Observador
    {
        public abstract void atualiza(object observavel, Eventos evento);
        protected abstract void unlock();


    }
}