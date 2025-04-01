using System;
using UnityEngine;

public class MagicSystem
{
	private int mpMax;
	private int mp;

	public MagicSystem(int mpMax)
	{
		this.mpMax = mpMax;
		mp = mpMax;
	}

	public void SetMpAmount(int mp)
	{
		this.mp = mp;
		Actions.OnMpChanged?.Invoke();
	}

	public float GetMpPercent()
	{
		return (float)mp / mpMax;
	}

	public int GetMpAmount()
	{
		return mp;
	}

	public void GetsUsed(int amount)
	{
		mp -= amount;
		if (mp < 0)
		{
			mp = 0;
		}
		Actions.OnMpChanged?.Invoke();
	}
}
