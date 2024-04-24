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
        foreach (Elementality elementality in m_near_elements)
        {
            if (elementality != null)
            {
                switch (elementality_type)
                {
                    case ElementalityType.LIFE:
                    {
                        if (elementality.Life > 0)
                        {
                            elementality.Life--;
                            m_curr_elementality.Life++;
                        }
                        break;
                    }
                    case ElementalityType.DEATH:
                    {
                        if(elementality.Death > 0)
                        {
                            elementality.Death--;
                            m_curr_elementality.Death++;
                        }
                        break;
                    }
                    case ElementalityType.EARTH:
                    {
                        if(elementality.Earth > 0)
                        {
                            elementality.Earth--;
                            m_curr_elementality.Earth++;
                        }
                        break;
                    }
                    case ElementalityType.AIR:
                    {
                        if(elementality.Air > 0)
                        {
                            elementality.Air--;
                            m_curr_elementality.Air++;
                        }
                        break;
                    }
                    case ElementalityType.FIRE:
                    {
                        if(elementality.Fire > 0)
                        {
                            elementality.Fire--;
                            m_curr_elementality.Fire++;
                        }
                        break;
                    }
                    case ElementalityType.WATER:
                    {
                        if (elementality.Water > 0)
                        {
                            elementality.Water--;
                            m_curr_elementality.Water++;
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
        m_curr_elementality += elementality;
    }

    public void RemoveElementality(ref Elementality elementality)
    {
        m_near_elements.Remove(elementality);
        m_curr_elementality -= elementality;
    }
}
