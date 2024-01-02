using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charInfo : MonoBehaviour
{
    public float health;
    public Text healthText;
    public float playerDeath=0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void gameOver()
    {
        print("oyun bitti");
        playerDeath = 1;
    }
}
