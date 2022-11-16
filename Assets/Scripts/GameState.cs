using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private GameObject[] monsters;
    private bool clear = false;
    private float countDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clear)
        {
            Debug.Log(countDown);
            if (countDown <= 0)
            {
                int curScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(curScene+1);
            } else
            {
                countDown -= Time.deltaTime;
            }
        }
        monsters = GameObject.FindGameObjectsWithTag("monster");
        if (monsters.Length == 0 && !clear)
        {
            countDown = 3;
            clear = true;
        }
        
    }
}
