using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroup : MonoBehaviour
{
    public GameObject[] E_array;
    int i = 1;
    void Update()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0 && i < E_array.Length)
        {
            E_array[i++].SetActive(true);
        }
    }
}
