using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCS_B_Move : JMCharacterState
{
	protected Vector3 MoveVector;

	public virtual void Move(float InDeltaTime)
	{
		MoveVector += new Vector3(0, Constant.ForwardSpeed, 0) * InDeltaTime;
	}

	public override void Tick(float InDeltaTime)
	{
		base.Tick(InDeltaTime);

		// 이동량 초기화
		MoveVector = Vector3.zero;

		Move(InDeltaTime);

		// 움직임 적용
		Owner.transform.position += MoveVector;

		Vector3 NewCamPosition = Camera.main.transform.position;
		NewCamPosition.y += MoveVector.y;
		Camera.main.transform.position = NewCamPosition;
	}

	public override void OnCollisionEnter2D(Collision2D other)
	{
		base.OnCollisionEnter2D(other);

		if (other.gameObject.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
		}
	}
}
