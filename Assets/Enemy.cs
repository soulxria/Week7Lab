using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float MoveSpeed = 100f;
    private Rigidbody _rb;
    public float timer = 2.0f;
    private bool MovingLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            if(!MovingLeft)
                _rb.MovePosition(this.transform.position + this.transform.right * MoveSpeed * Time.deltaTime);
            else
                _rb.MovePosition(this.transform.position - this.transform.right * MoveSpeed * Time.deltaTime);

        }
        if (timer <= 0)
        {
            timer = 2.0f;
            if (!MovingLeft)
                MovingLeft = true;
            else
                MovingLeft = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }

}
