using System;
using UnityEngine;

public class HealthSystem
{
	public event EventHandler OnHealthChanged;
	public event EventHandler OnDead;

	private int healthMax;
	private int health;

	public HealthSystem(int healthMax)
	{
		this.healthMax = healthMax;
		health = healthMax;
	}

	public void SetHealthAmount(int health)
	{
		this.health = health;
		OnHealthChanged?.Invoke(this, EventArgs.Empty);
	}

	public float GetHealthPercent()
	{
		return (float)health / healthMax;
	}

	public int GetHealthAmount()
	{
		return health;
	}

	public void GetsDamage(int amount)
	{
		health -= amount;
		if (health < 0)
		{
			health = 0;
		}

		Debug.Log(health);
		OnHealthChanged?.Invoke(this, EventArgs.Empty);

		if (health <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		OnDead?.Invoke(this, EventArgs.Empty);
	}

	public bool IsDead()
	{
		return health <= 0;
	}

	public void Heal(int amount)
	{
		health += amount;
		if (health > healthMax)
		{
			health = healthMax;
		}
		OnHealthChanged?.Invoke(this, EventArgs.Empty);
	}
}