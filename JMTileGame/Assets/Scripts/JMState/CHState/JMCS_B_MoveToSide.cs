using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreativeSpore.SuperTilemapEditor;

public class JMCS_B_MoveToSide : JMCS_B_Move
{
	protected bool ChangedState;

	public override void BeginState(string InPrevStateName)
	{
		base.BeginState(InPrevStateName);

		ChangedState = false;
	}
	
	protected Tile GetTile(Collision2D other)
	{
		Tilemap Tilemap = other.gameObject.GetComponentInParent<Tilemap>();
		if (Tilemap == null)
			return null;

		Vector2 OwnerPosition2D = new Vector2(Owner.transform.position.x , Owner.transform.position.y);
		Vector2 Gap = other.contacts[0].point - OwnerPosition2D;
		Vector2 BiasPosition2D = (Gap * 1.1f) + OwnerPosition2D;
		return Tilemap.GetTile(BiasPosition2D);
	}
}
