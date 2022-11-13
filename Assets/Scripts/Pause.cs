using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite pauseImg;
    public Sprite startImg;
    bool pauseState;
    void Start()
    {
        pauseState = false;
        gameObject.GetComponent<Image>().sprite = pauseImg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pauseOnClick()
    {
        pauseState = !pauseState;
        if(pauseState)
            gameObject.GetComponent<Image>().sprite = pauseImg;
        else
            gameObject.GetComponent<Image>().sprite = startImg;
    }
}
