using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
	private List<IUnit> leftFront = new List<IUnit>();
	private List<IUnit> rightFront = new List<IUnit>();

	public void addLeft(IUnit unit)
	{
		leftFront.Add(unit);
	}

	public void addRight(IUnit unit)
	{
		rightFront.Add(unit);
	}

	public void Wasted()
	{
		//Подписчик на смерть юнита
		//Удаляет юнита если пришло сообщение о смерти

		//Если все юниты умерли, то отправляет сообщение о проигрыше полю 
	}

	public void Movement()
	{
		for (int i = 0; i < leftFront.Count; i++)
		{
			if (rightFront.Count > 0 && leftFront[i].AttackRange > i)
			{
				rightFront[0].Hit(leftFront[i].Damage);
				leftFront[i].SpecialAbility();
			}
		}
		for (int i = 0; i < rightFront.Count; i++)
		{
			if (leftFront.Count > 0 && rightFront[i].AttackRange > i)
			{
				leftFront[0].Hit(rightFront[i].Damage);
				rightFront[i].SpecialAbility();
			}
		}
	}
}
