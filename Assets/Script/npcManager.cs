using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcManager : MonoBehaviour
{
    GameObject[] enemies1;
    GameObject[] enemies2;
    void Start()
    {
        enemies1 = GameObject.FindGameObjectsWithTag("enemy");
        enemies2 = GameObject.FindGameObjectsWithTag("enemy2");
    }

    void Update()
    {

    }

    public void removeNpcScript()
    {
        foreach (GameObject npc in enemies1)
        {
            npc.GetComponent<npcHumanoid>().enabled = false;
        }

        foreach (GameObject npc in enemies2)
        {
            npc.GetComponent<npcEgg>().enabled = false;
        }
    }
}
