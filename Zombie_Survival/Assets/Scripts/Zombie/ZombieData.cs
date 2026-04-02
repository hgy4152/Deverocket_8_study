using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Scriptable Objects/ZombieData")]
public class ZombieData : ScriptableObject
{
    public float maxHP = 100f;
    public float damage = 20f;
    public float speed = 100f;

    public Color skinCol = Color.white; // float 0.0~1.0 사이 값


    
}
