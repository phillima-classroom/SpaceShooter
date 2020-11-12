using Assets.Scripts;
using Assets.Scripts.asteroide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AchimentManager : MonoBehaviour, Observador
{

    GameObject achivSpawnPoint;

    [SerializeField]
    List<Achievment> achivments;

    public void atualiza(object dados, Eventos evento) {
        foreach (var item in achivments) {
            item.unlock();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        achivSpawnPoint = GameObject.FindGameObjectWithTag("Achiv_Spawner");
    }

    protected void removeAchiv(Achievment achiv) {
        achivments.Remove(achiv);
    }

    
}
