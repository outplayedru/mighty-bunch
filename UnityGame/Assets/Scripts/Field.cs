using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Field 
{
	private static Field instance;
	private static object instanceLock = new object();

	List<Line> lines;
	Barracks barracks;

	protected Field(int linesCount)
	{
		this.lines = new List<Line>(linesCount);
	}

	public static Field getInstance(int linesCount)
	{
		if (instance == null)
		{
			lock (instanceLock)
			{
				if(instance == null)
				{
					instance = new Field(linesCount);
				}
			}
		}
		return instance;
	}

	public void AddUnitsToLine(int[] unitId,int lineNumber, bool isPlayerFront = true)
	{
		foreach (var id in unitId)
		{
			Line line = lines[lineNumber];

			if(isPlayerFront)
			{
				line.addLeft(barracks.Birth(id));
			}
			else
			{
				line.addRight(barracks.Birth(id));
			}
		}
	}

	public void Wasted()
	{
		//Подписчик на проигрыш линии
		//Переносит юнитов в другую линию если пришло сообщение о проигрыше 
	}

	public void MovementIteration()
	{
		foreach (var line in lines)
		{
			line.Movement();
		}
	}
}
