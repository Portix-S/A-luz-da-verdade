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
        LoadNewInventor(); // TODO: remove later
    }

    public void StartGame()
    {
        LoadNewInventor();
    }

    public void Approve()
    {
        _patentManager.ShowExitDialog(true);
    }

    public void Reprove()
    {
        _patentManager.ShowExitDialog(false);
    }

    private void LoadNewInventor() // maybe use as scriptable
    {
        _patentManager.LoadNewInventor(); // pass scriptable?
    }
    

}
