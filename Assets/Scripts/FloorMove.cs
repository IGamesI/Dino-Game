using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    #region Variables
    [SerializeField] float _moveSpeed;
    #endregion

    #region UnityFunctions
    void Update()
    {
        transform.Translate(new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime);
    }
    #endregion

    #region CustomFunctions
    #endregion
}
