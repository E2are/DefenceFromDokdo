using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int stage_cnt=1;
    
    public Slider slider;
    public Text Score_text; 
    public Base bs;
    void Awake() 
    {
        instance = this;
    }
    void Update()
    {
        Score_text.text = "Stage : " + stage_cnt.ToString();
        
    }

    
}
