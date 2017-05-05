using CreativeSpore.SuperTilemapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCS_B_MoveToRight : JMCS_B_MoveToSide
{
	public override void Move(float InDeltaTime)
	{
		base.Move(InDeltaTime);

		MoveVector += (new Vector3(Constant.SideSpeed, 0, 0) * InDeltaTime);
	}
	public override void OnPressed()
	{
		base.OnPressed();
		ChangeStateMoveToLeft();
	}

	private void ChangeStateMoveToLeft()
	{
		ChangedState = true;
		ChangeState("MoveToLeft");
	}

	public override void OnCollisionEnter2D(Collision2D other)
	{
		base.OnCollisionEnter2D(other);
		if (ChangedState)
			return;

		Tile tile = GetTile(other);
		
		if (tile != null)
		{
			if (tile.paramContainer.GetBoolParam("TurnBlock"))
			{
				ChangeStateMoveToLeft();
			}
			else if(tile.paramContainer.GetBoolParam("DeadBlock"))
			{
				// 죽어라
				ChangeState("Dead");
			}
		}
	}
}
