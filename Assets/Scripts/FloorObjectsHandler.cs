using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FloorObjectsHandler : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject _treePrefab;

	Random _treeAmmountRandom = new Random();
	Random _treeRandom = new Random();
	#endregion

	#region UnityFunctions
	void Start()
    {
		float treeAmmount = _treeAmmountRandom.Next(0, 10);
		for (int i = 0; i < treeAmmount; i++)
		{
			print("Added new tree!");
			float treeRandomX = _treeRandom.Next(-11, 11);
			Vector3 newTreePosition = new Vector3(gameObject.transform.localPosition.x + treeRandomX, 0, 0);
			Instantiate(_treePrefab, newTreePosition, _treePrefab.transform.rotation, gameObject.transform);

		}
	}
    #endregion

    #region CustomFunctions
    #endregion
}
