using UnityEngine;

public struct BattleStats
{
	private int attackDamage;
	private int spellDamage;
	private int healingAmount;
	private int spellMpCost;

	public BattleStats(int attackDamage, int spellDamage, int healingAmount, int spellMpCost)
	{
		this.attackDamage = attackDamage;
		this.spellDamage = spellDamage;
		this.healingAmount = healingAmount;
		this.spellMpCost = spellMpCost;
	}

	public int GetAttackDamage()
	{
		return attackDamage;
	}

	public int GetSpellDamage()
	{
		return spellDamage;
	}

	public int GetHealingAmount()
	{
		return healingAmount;
	}

	public int GetSpellMpCost()
	{
		return spellMpCost;
	}
}