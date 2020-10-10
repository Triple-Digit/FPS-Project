using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AI : MonoBehaviour
{
    [Header("AI Type")]
    public bool isHuman;

    [Header("Speed")]
    public float speed;
    
    private Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Bunker").GetComponent<Transform>();        
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, (speed/10) * Time.deltaTime);        
    }

    public void Die()
    {
        if(isHuman)
        {
            GameManager.instance.MinusScore();
        }
        else
        {
            GameManager.instance.Score();
        }
        transform.DORotate(new Vector3(90, 0, 0), 2f);
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Human" && !isHuman)
        {
            Destroy(collision.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }        
    }



}
