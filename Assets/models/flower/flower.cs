using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * color generation might be moved to different special class
 * 
 */

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] GameObject[] objectsToChangeColor;
	[SerializeField] Color[] colors;

	private Renderer objectRenderer;
	private Animator animator;
	private AnimateColor _animateColor;

	private int _currentColorIndex = 0;

	// Start is called before the first frame update
	void Start()
	{
		objectRenderer = GetComponent<Renderer>();
		animator = GetComponent<Animator>();

		changeColor(colors[_currentColorIndex]);

		_animateColor = new AnimateColor
		{
			//valueA = objectRenderer.material.color,
			//valueB = Color.red,
			duration = 0.4f,
			OnAnimationStep = (c) =>
			{
				if (objectRenderer != null)
				{
					changeColor(c);
				}
			}
		};
	}

	private bool go = false;

	AnimateFloat animateFloat = null;

	// Update is called once per frame
	void Update()
	{
		if (!go)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				go = true;
				_animateColor.valueA = colors[_currentColorIndex];
				if (_currentColorIndex == colors.Length - 1) _currentColorIndex = 0;
				else _currentColorIndex++;
				_animateColor.valueB = colors[_currentColorIndex];
				animator.SetTrigger("change");// или все можно упаковать в мою машину-программу
			}
		}

		if (go)
		{
			// Check if the Renderer component is found
			if (objectRenderer != null)
			{
				if(!_animateColor.update(null)) go = false;
			}
		}
	}

	private void changeColor(Color c)
	{
		// Change the color to red
		objectRenderer.material.color = Color.red;

		foreach (var obj in objectsToChangeColor)
		{
			var r = obj.GetComponent<Renderer>();
			r.material.color = c;
		}
	}
}
