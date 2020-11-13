using Assets.Scripts.observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Achievment : MonoBehaviour, Observador
{
    protected bool unlocked;
    
    protected abstract void unlock();
    public abstract void atualiza(object observavel, Eventos evento);
}
