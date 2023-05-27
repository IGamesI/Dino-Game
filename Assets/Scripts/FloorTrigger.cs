using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject _floorPrefab;
	[SerializeField] LayerMask _groundLayer;
	float floorXDifference = 22.33363f;
	#endregion

	#region UnityFunctions
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
			float newFloorX = collision.transform.position.x + floorXDifference;
			Instantiate(_floorPrefab, new Vector3(newFloorX, 0, 0),
				collision.transform.rotation);
		}
        
	}
    #endregion

    #region CustomFunctions
    #endregion
}
