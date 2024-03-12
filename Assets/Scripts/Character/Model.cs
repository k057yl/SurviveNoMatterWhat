using UnityEngine;

public class Model
{
    private const float ZERRO = 0f;
    private const float MAX_HEALTH = 100f;
  
    private float _health;
    public float Health => _health;

    public Model(float health)
    {
        _health = health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= ZERRO)
        {
            Die();
        }
    }

    public void SetHealth(float health)
    {
        _health += health;
        if (health >= MAX_HEALTH)
        {
            _health = MAX_HEALTH;
        }
    }

    private void Die()
    {
        Debug.Log("Game Over");
    }
}
