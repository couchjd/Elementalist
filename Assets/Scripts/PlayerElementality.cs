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

    private Dictionary<ElementalityType, int> m_elem_types_count;

    private void Start()
    {
        m_elem_types_count = new Dictionary<ElementalityType, int>()
        {
            { ElementalityType.LIFE, 0 },
            { ElementalityType.DEATH, 0 },
            { ElementalityType.EARTH, 0 },
            { ElementalityType.AIR, 0 },
            { ElementalityType.FIRE, 0 },
            { ElementalityType.WATER, 0 }
        };

        m_curr_elementality = new Elementality(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
        m_max_elementality = new Elementality(100.0f, 100.0f, 100.0f, 100.0f, 100.0f, 100.0f);
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
        // Calculate the correct amount to draw from each nearby element
        float type_count = m_elem_types_count[elementality_type];
        float draw_strength = 1.0f;

        float draw_amount = draw_strength / type_count;

        foreach (Elementality elementality in m_near_elements)
        {
            if (elementality != null)
            {
                switch (elementality_type)
                {
                    case ElementalityType.LIFE:
                    {
                        if (elementality.Life > 0 && m_curr_elementality.Life < m_max_elementality.Life)
                        {
                            elementality.Life -= draw_amount;
                            m_curr_elementality.Life += draw_amount;
                        }
                        break;
                    }
                    case ElementalityType.DEATH:
                    {
                        if(elementality.Death > 0 && m_curr_elementality.Death < m_max_elementality.Death)
                        {
                            elementality.Death -= draw_amount;
                            m_curr_elementality.Death += draw_amount;
                        }
                        break;
                    }
                    case ElementalityType.EARTH:
                    {
                        if(elementality.Earth > 0 && m_curr_elementality.Earth < m_max_elementality.Earth)
                        {
                            elementality.Earth -= draw_amount;
                            m_curr_elementality.Earth += draw_amount;
                        }
                        break;
                    }
                    case ElementalityType.AIR:
                    {
                        if(elementality.Air > 0 && m_curr_elementality.Air < m_max_elementality.Air)
                        {
                            elementality.Air -= draw_amount;
                            m_curr_elementality.Air += draw_amount;
                        }
                        break;
                    }
                    case ElementalityType.FIRE:
                    {
                        if(elementality.Fire > 0 && m_curr_elementality.Fire < m_max_elementality.Fire)
                        {
                            elementality.Fire -= draw_amount;
                            m_curr_elementality.Fire += draw_amount;
                        }
                        break;
                    }
                    case ElementalityType.WATER:
                    {
                        if (elementality.Water > 0 && m_curr_elementality.Water < m_max_elementality.Water)
                        {
                            elementality.Water -= draw_amount;
                            m_curr_elementality.Water += draw_amount;
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }
    }

    public void AddElementality(ref Elementality elementality)
    {
        m_near_elements.Add(elementality);
        //m_curr_elementality += elementality;

        // Increment the type count for each element in the newly added elementality
        // This is used to calculate the correct amount to draw from each nearby source.
        List<ElementalityType> elementality_types = elementality.GetElementalityTypes();
        foreach(ElementalityType type in elementality_types)
        {
            m_elem_types_count[type]++;
        }
    }

    public void RemoveElementality(ref Elementality elementality)
    {
        m_near_elements.Remove(elementality);
        //m_curr_elementality -= elementality;

        // Decrement the type count for each element in the newly added elementality
        // This is used to calculate the correct amount to draw from each nearby source.
        List<ElementalityType> elementality_types = elementality.GetElementalityTypes();
        foreach (ElementalityType type in elementality_types)
        {
            m_elem_types_count[type]--;
            if (m_elem_types_count[type] < 0)
            {
                m_elem_types_count[type] = 0;
            }
        }
    }
}
