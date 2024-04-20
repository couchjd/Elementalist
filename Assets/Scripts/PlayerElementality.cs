using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerElementality : MonoBehaviour
{
    [SerializeField]
    private List<Elementality> m_near_elements;
    [SerializeField]
    private Elementality m_curr_elementality;

    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Cast();
        }
    }

    public void Cast()
    {
        foreach(Elementality elementality in m_near_elements)
        {
            if(elementality != null && elementality.Life > 0)
            {
                elementality.Life--;
                m_curr_elementality.Life--;
            }
        }
    }

    public void AddElementality(ref Elementality elementality)
    {
        m_near_elements.Add(elementality);
        m_curr_elementality += elementality;
    }

    public void RemoveElementality(ref Elementality elementality)
    {
        m_near_elements.Remove(elementality);
        m_curr_elementality -= elementality;
    }
}
