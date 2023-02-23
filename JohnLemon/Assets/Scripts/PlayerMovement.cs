using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 m_Movement;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    public float turnSpeed= 20f;
    Quaternion  m_Rotation = Quaternion.identity;
    private AudioSource m_AudioSource;


    // stamina
    public float duracionstamina = 2f;
    float staminatimer;
    [Range(1f,3f)]
    public float aumentovelocidad=1f;
    float multiplicadorvelocidad=1f;
    


    private void Start()
    {
        staminatimer=duracionstamina;
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        stamina();
        float horizontal = Input.GetAxis("Horizontal") * multiplicadorvelocidad;
        float vertical = Input.GetAxis("Vertical") * multiplicadorvelocidad;
        Debug.Log(horizontal);
        Debug.Log(vertical);


        m_Movement.Set(horizontal,0f,vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal,0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical,0f);

        bool IsWalking = hasHorizontalInput || hasVerticalInput;
        Debug.Log(IsWalking);
        m_Animator.SetBool("IsWalking", IsWalking);
        
        if(IsWalking)
        {
            if(!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();

            }

            
        }
        else
        {
            m_AudioSource.Stop();

        }


        Vector3 desiredForward=Vector3.RotateTowards(transform.forward, m_Movement,turnSpeed * Time.deltaTime,0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);

    }
    public void stamina()
    {
        if(Input.GetAxis("sprint")>0f  && staminatimer>0)
        {
            staminatimer -= Time.deltaTime;
            multiplicadorvelocidad = aumentovelocidad;
        }
        else
        { 
            if (staminatimer<duracionstamina)
            {
                staminatimer+= Time.deltaTime*0.5f;

            }
            multiplicadorvelocidad=1f;

        }
    }
}
