using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    //残りターゲット
    private GameObject GameController;
    private gameControllerScript _gameControllerScript;
  

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController");
        _gameControllerScript = GameController.GetComponent<gameControllerScript>();
    }



    private void OnDestroy()
    {
        _gameControllerScript.changeTargetText();
    }
}
