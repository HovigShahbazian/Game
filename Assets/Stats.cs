using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text stats;
    private int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        stats.text = (num).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Add()
    {
        num++;
        stats.text = num.ToString();
    }

    public void Minus()
    {
        num--;
        stats.text = num.ToString();
    }
}
