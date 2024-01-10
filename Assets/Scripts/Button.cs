using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Base;
    public int tcnt;
    public SpawnManager Spawn;
    public float cost;

    public void SetType()
    {
        Spawn = Spawn.GetComponent<SpawnManager>();
        Spawn.type = tcnt;
        if(GameManager.instance.bs.fishCoin >= cost){
            Spawn.selected = !Spawn.selected;
            GameManager.instance.bs.fishCoin -= cost;
        }
        
    }
}
