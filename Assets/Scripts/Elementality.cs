using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Elementality
{
    public Elementality(
        float in_life,
        float in_stone,
        float in_fire,
        float in_water,
        float in_earth)
    {
        life = in_life;
        stone = in_stone;
        fire = in_fire;
        water = in_water;
        earth = in_earth;
    }

    [SerializeField]
    private float life;
    [SerializeField]
    private float stone;
    [SerializeField]
    private float fire;
    [SerializeField]
    private float water;
    [SerializeField]
    private float earth;

    public float Life { get { return life; } set { life = value; } }
    public float Stone { get { return stone; } set { stone = value; } }
    public float Fire { get { return fire; } set { fire = value; } }
    public float Water { get { return water; } set { water = value; } }
    public float Earth { get { return earth; } set {  earth = value; } }
    public static Elementality operator -(Elementality a, Elementality b)
    {
        return new Elementality(a.Life - b.Life, a.Stone - b.Stone, a.Fire - b.Fire, a.Water - b.Water, a.Earth - b.Earth); 
    }
        
    public static Elementality operator +(Elementality a, Elementality b)
    => new Elementality(a.life + b.life, a.stone + b.stone, a.fire + b.fire, a.water + b.water, a.earth + b.earth);

}
