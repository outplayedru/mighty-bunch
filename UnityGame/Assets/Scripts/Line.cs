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

}
