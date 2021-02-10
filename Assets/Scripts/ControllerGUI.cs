using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGUI : MonoBehaviour
{
    public Transform imgKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        imgKey.gameObject.SetActive(Inventory.main.hasKey);
    }
}
