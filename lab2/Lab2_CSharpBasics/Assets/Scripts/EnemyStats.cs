using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public string enemyName = "Orc";
    public int attackPower = 25;
    public int healthLevel = 100;
    public float moveSpeed = 3.5f;

    void Start()
    {
        int critMultiplier = 1;
        int finalDamage = attackPower * critMultiplier;

        Debug.Log("Enemy " + enemyName + " deals " + finalDamage + " damage");
    }
}