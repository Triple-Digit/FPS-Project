using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject arCamera;

    public void Shooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if(hit.transform.gameObject.tag == "Zombie" || hit.transform.gameObject.tag == "Human")
            {
                hit.transform.gameObject.GetComponent<AI>().Die();
            }
        }
    }


}
