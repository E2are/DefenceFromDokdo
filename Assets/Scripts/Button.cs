using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public int tcnt;
    public SpawnManager Spawn;
    public float cost;
    public int ans;
    public void SetType()
    {
        Spawn = Spawn.GetComponent<SpawnManager>();
        Spawn.type = tcnt;
        Spawn.selected = true;
        Spawn.P_cost = cost;
    }
    public void Re()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void answer()
    {
        GameManager.instance.qz.answer = ans;
    }
}
