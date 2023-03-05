using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDetection : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            logic.AddScore(1);
        }
    }
}