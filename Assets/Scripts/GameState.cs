using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameState : MonoBehaviour
{
    private GameObject[] monsters;
    private bool clear = false;
    private float countDown;
    public int playerHP;
    private bool initialized;

    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(this);
        Cursor.visible = false;
    }

    public void Initialize(int maxHP) {
        if (initialized) return;
        playerHP = maxHP;

        initialized = true;
    }

    public void restart(int maxHP) {
        playerHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (clear)
        {
            if (countDown <= 0)
            {
                int curScene = SceneManager.GetActiveScene().buildIndex;
                int nextScene = (curScene + 1) % 4;
                clear = false;
                if (nextScene == 0)
                {
                    SceneManager.LoadSceneAsync(nextScene);
                    Cursor.visible = true;
                    //Destroy(GameObject.Find("GameState"));
                    Destroy(this.gameObject);
                }
                else
                    SceneManager.LoadScene(nextScene);
            } else
            {
                countDown -= Time.deltaTime;
            }
        } else {
            monsters = GameObject.FindGameObjectsWithTag("monster");
            if (monsters.Length == 0 && !clear && SceneManager.GetActiveScene().buildIndex > 0)
            {
                countDown = 3;
                clear = true;
            }
        }
        
    }
}
