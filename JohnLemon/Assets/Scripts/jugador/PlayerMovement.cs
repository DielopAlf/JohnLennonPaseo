using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [HideInInspector]
    public float staminatimer;
    [Range(1f,3f)]
    public float aumentovelocidad=1f;
    float multiplicadorvelocidad=1f;
    public float duracionstun=1f;
    float stuntimer;
    public Slider staminaBar;

    [HideInInspector]
    public bool staminainfinita;
   

    private void Start()
    {
        staminainfinita=false;
        staminatimer=duracionstamina;
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
        staminaBar.maxValue = duracionstamina;
        stuntimer = duracionstun;
    }

    void FixedUpdate()
    {
        stamina();
        float horizontal = Input.GetAxis("Horizontal"); //* multiplicadorvelocidad;
        float vertical = Input.GetAxis("Vertical"); //* multiplicadorvelocidad;
        //Debug.Log(horizontal);
        //Debug.Log(vertical);


        m_Movement.Set(horizontal,0f,vertical);
        m_Movement.Normalize();
        m_Movement=m_Movement*multiplicadorvelocidad;
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
            if (staminainfinita == false)
            {
                staminatimer -= Time.deltaTime;

            }
            multiplicadorvelocidad = aumentovelocidad;
        }
        else
        {
            if (staminatimer <= 0  &&  stuntimer>0)
            {

                multiplicadorvelocidad=0.6f;
                stuntimer-= Time.deltaTime;

            }
            else if (staminatimer<duracionstamina)
            {
                staminatimer+= Time.deltaTime*0.5f;
                multiplicadorvelocidad=1f;
                stuntimer=duracionstun;

            }

        }
        staminaBar.value = staminatimer;
        
        
    }

}
