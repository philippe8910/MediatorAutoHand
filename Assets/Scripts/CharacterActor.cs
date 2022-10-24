using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActor : MonoBehaviour
{
    [SerializeField] private float m_Speed;

    [SerializeField] private Rigidbody m_rigidbody;


    public void Movement(Vector2 input)
    {
        Vector3 move = new Vector3(input.x, 0, input.y);

        m_rigidbody.velocity = new Vector3(input.x * m_Speed * Time.deltaTime, m_rigidbody.velocity.y,
            input.y * m_Speed * Time.deltaTime);

        if (input != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(input.x , input.y) * Mathf.Rad2Deg, 0));
        }
    }

    public void SetGravity(bool isGravity)
    {
        m_rigidbody.useGravity = isGravity;
    }

    public void SetRigidbodyVector(Vector3 vector3)
    {
        m_rigidbody.velocity = vector3;
    }

    public bool GetFallAction()
    {
        if (m_rigidbody.velocity.y >= -0.1f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Jump()
    {
        m_rigidbody.AddForce(Vector3.up * 1.9f , ForceMode.Impulse);
    }

    public void SetSpeed(float value)
    {
        m_Speed = value;
    }
    
}
