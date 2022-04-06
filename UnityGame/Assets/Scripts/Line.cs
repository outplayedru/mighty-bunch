using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
	public List<IUnit> leftFront = new List<IUnit>();
	public List<IUnit> rightFront = new List<IUnit>();

	public int leftDeath;
	public int rightDeath;
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

		//Добавляет умершего юнита в счетчик смертей фронта линии
	}

	public void Movement()
	{
		for (int i = 0; i < leftFront.Count; i++)
		{
			if (rightFront.Count > 0 && leftFront[i].AttackRange > i)
			{
				rightFront[0].Hit(leftFront[i].Damage);
				leftFront[i].SpecialAbility(this, (uint)i, 'l');
			}
		}
		for (int i = 0; i < rightFront.Count; i++)
		{
			if (leftFront.Count > 0 && rightFront[i].AttackRange > i)
			{
				leftFront[0].Hit(rightFront[i].Damage);
				rightFront[i].SpecialAbility(this, (uint)i, 'r');
			}
		}
	}
}
