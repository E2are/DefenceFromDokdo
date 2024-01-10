using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int stage_cnt = 1;

    public Slider slider;
    public Base bs;
    public Quiz qz;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {

    }


}
