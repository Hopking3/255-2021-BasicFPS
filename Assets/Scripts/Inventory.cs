using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory _main;
    public static Inventory main
    {
        get { return _main; }
    }

    public bool hasKey = false;

    private void Start()
    {
        if (_main == null)
        {
            _main = this;
            DontDestroyOnLoad(gameObject); // prevents object from being destroyed on a new scene
        }
        else
        {
            Destroy(gameObject); //destroys any extra inventories made
        }
        
    }
    

}
