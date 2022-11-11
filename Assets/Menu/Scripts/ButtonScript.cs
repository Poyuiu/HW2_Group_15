using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public GameObject HelpCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) closeHelp();
    }

    void closeHelp() {
        HelpCanvas.SetActive(false);
    } 

    public void onQuit() {
        Application.Quit();
    }

    public void onHelp() {
        HelpCanvas.SetActive(true);
    }

    public void onCloseHelp() {
        closeHelp();
    }

    public void onStart() {

    }

}
