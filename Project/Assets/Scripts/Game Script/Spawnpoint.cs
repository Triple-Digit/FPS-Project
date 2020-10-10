using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    private int randomnumber;

    public void Spawn()
    {
        randomnumber = Random.Range(0, GameManager.instance.characters.Length);
        GameObject newBlock = GameManager.instance.characters[randomnumber];
        Instantiate(newBlock, transform.position, newBlock.transform.rotation);
    }
}
