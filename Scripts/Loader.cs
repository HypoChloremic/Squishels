using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    // In order to generate a level
    // we would like to create a loader script which is attached
    // to the camera, as the camera will always be associated with the 
    // game starting.
    // By also introducing a public parameter, where we move the GameManager
    // prefab into, it allows us to introduce the GameManager everytime we load
    // a scene.

    public GameObject gameManager;

    // for initialization
    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }
}
