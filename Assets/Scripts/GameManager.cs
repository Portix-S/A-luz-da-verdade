using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PatentManager _patentManager;
    public static GameManager GameManagerInstance;


    private void Awake()
    {
        if (GameManagerInstance == null)
        {
            GameManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _patentManager = GetComponent<PatentManager>();
        LoadNewInventor();
    }

    public void StartGame()
    {
        LoadNewInventor();
    }

    public void Approve()
    {
        
        Invoke(nameof(LoadNewInventor), 5f);
    }

    public void Reprove()
    {
        
        Invoke(nameof(LoadNewInventor), 5f);
    }

    private void LoadNewInventor() // maybe use as scriptable
    {
        _patentManager.LoadNewInventor(); // pass scriptable?
    }
    
    
}
