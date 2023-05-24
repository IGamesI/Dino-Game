using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FloorObjectsHandler : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject _treePrefab;
	[SerializeField] float _treeWidth;
	[SerializeField] float _minTreeWidth;

	Random _treeAmountRandom = new Random();
	Random _treeRandom = new Random();
	#endregion

	#region UnityFunctions
	void Start()
    {
		float treeAmount = _treeAmountRandom.Next(0, 8);
		List<float> treeXPositions = new List<float>();
		for (int i = 0; i < treeAmount; i++)
		{
			float treeRandomX = 0f;
			bool tooClose = false;
			int counter = 0;
			while (tooClose && counter < 100)
			{
				treeRandomX = _treeRandom.Next(-8, 8);
				if (treeXPositions.Count > 0)
				{
					foreach (float x in treeXPositions)
					{
						if (Mathf.Abs(treeRandomX - x) <= _minTreeWidth)
						{
							tooClose = false;
						}
						else if(Mathf.Abs(treeRandomX - x) < _treeWidth)
						{
							tooClose = true;
							break;
						} 
						else
						{
							tooClose = false;
						}
					}
				}
				else
				{
					tooClose = false;
				}
				counter++;
			}

			if (counter < 100)
			{
				treeXPositions.Add(treeRandomX);
				Vector3 newTreePosition = new Vector3(gameObject.transform.localPosition.x + treeRandomX, 0, 0);
				Instantiate(_treePrefab, newTreePosition, _treePrefab.transform.rotation, gameObject.transform);
			}
		}


	}
	#endregion

	#region CustomFunctions
	#endregion
}
