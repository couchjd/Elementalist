using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ElementalityNamespace
{
    public enum ElementalityType
    {
        LIFE,
        DEATH,
        EARTH,
        AIR,
        FIRE,
        WATER
    }
}

[Serializable]
public class Elementality
{
    public Elementality(
        float in_life,
        float in_death,
        float in_earth,
        float in_air,
        float in_fire,
        float in_water)
    {
        m_life = in_life;
        m_death = in_death;
        m_earth = in_earth;
        m_air = in_air;
        m_fire = in_fire;
        m_water = in_water;
    }

    [SerializeField]
    private float m_life;
    [SerializeField] 
    private float m_death;
    [SerializeField]
    private float m_earth;
    [SerializeField] 
    private float m_air;
    [SerializeField]
    private float m_fire;
    [SerializeField]
    private float m_water;
    
    public float Life { get { return m_life; } set { m_life = value; } }
    public float Death { get { return m_death; } set { m_death = value; } }
    public float Earth { get { return m_earth; } set { m_earth = value; } }
    public float Air { get { return m_air; } set { m_air = value; } }
    public float Fire { get { return m_fire; } set { m_fire = value; } }
    public float Water { get { return m_water; } set { m_water = value; } }
    
    public static Elementality operator -(Elementality a, Elementality b)
    => new Elementality(a.Life - b.Life, a.Death - b.Death, a.Earth - b.Earth, a.Air - b.Air, a.Fire - b.Fire, a.Water - b.Water); 
        
    public static Elementality operator +(Elementality a, Elementality b)
    => new Elementality(a.Life + b.Life, a.Death + b.Death, a.Earth + b.Earth, a.Air + b.Air, a.Fire + b.Fire, a.Water + b.Water);

}
