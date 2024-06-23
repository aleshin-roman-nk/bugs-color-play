using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateRotationStep : StaticStepBase
{
	public Quaternion startRotation;
	public Quaternion endRotation;

	public override bool update(ChainRunner prg)
	{
		return false;
	}
}
