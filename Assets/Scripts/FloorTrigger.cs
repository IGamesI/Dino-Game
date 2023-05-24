using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject _floorPrefab;
    float floorXDifference = 22.33363f;
	#endregion

	#region UnityFunctions
	private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Made New Floor!");
        float newFloorX = collision.transform.position.x + floorXDifference;
		Instantiate(_floorPrefab, new Vector3(newFloorX, 0, 0), 
            collision.transform.rotation);
	}
    #endregion

    #region CustomFunctions
    #endregion
}
