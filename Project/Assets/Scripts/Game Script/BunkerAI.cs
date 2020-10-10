using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunkerAI : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Slider healthBar;

    public void SetHealth(int healthValue)
    {
        healthBar.value = healthValue;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            health--;
            SetHealth(health);
            Handheld.Vibrate();
            if (health == 0)
            {
                GameManager.instance.Restart();
            }
        }
    }
}
