using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ElementalityNamespace;

public class PlayerElementality : MonoBehaviour
{
    [SerializeField]
    private List<Elementality> m_near_elements;
    [SerializeField]
    private Elementality m_curr_elementality;
    [SerializeField]
    private Elementality m_max_elementality;

    private void Start()
    {
        m_curr_elementality = new Elementality(0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        m_max_elementality = new Elementality(100.0f, 100.0f, 100.0f, 100.0f, 100.0f);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Draw(ElementalityType.LIFE);
        }
    }

    public void Draw(ElementalityType elementality_type)
    {
        foreach (Elementality elementality in m_near_elements)
        {
            switch (elementality_type) 
            {
                case ElementalityType.LIFE:
                {
                    if (elementality != null && elementality.Life > 0)
                    {
                        elementality.Life--;
                        m_curr_elementality.Life--;
                    }
                    break;
                }
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
