using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleListen : MonoBehaviour {

    public KeyCode Key;
    public GameObject ConsoleHandler;
    public GameObject ConsoleObject;
	// Use this for initialization
	void Start () {
        Loader.DontDestroyOnLoad(ConsoleHandler);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Key))
        {
            if (ConsoleObject.activeInHierarchy)
            {
                Debug.Log("Active: False");
                ConsoleObject.SetActive(false);
            }
            else if (!ConsoleObject.activeInHierarchy)
            {
                Debug.Log("Active: True");
                ConsoleObject.SetActive(true);
            }
        }
    }
}
