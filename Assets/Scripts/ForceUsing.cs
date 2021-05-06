using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceUsing : MonoBehaviour
{
    #region Fields
    [SerializeField] private Collider _hitArea;
    #endregion


    #region Unity messages

    private void FixedUpdate()
    {
        DetectTargets();
    }
    #endregion


    #region private methods
    private void DetectTargets()
    {
        Vector3 colliderSize = _hitArea.bounds.extents;

        Collider[] colliderArray = Physics.OverlapBox(_hitArea.transform.position, colliderSize);
        foreach(Collider collider in colliderArray)
        {
            if(collider == _hitArea)
            {
                continue;
            }

           if(collider.gameObject.layer == 3)
            {
                
                if (Input.GetMouseButton(1))
                {
                    Debug.Log("Découper aux sabres");
                    CutWithLaser();
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("Utilisation de la force");
                    UseForce(collider);

                    
                }
            }
        

            

        }
    }

    public void CutWithLaser()
    {

    }

    public void UseForce(Collider collider)
    {
        collider.attachedRigidbody.AddForce(transform.forward *500);
    }


    #endregion






}
