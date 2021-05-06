using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceUsing : MonoBehaviour
{
    #region Fields
    [SerializeField] private Collider _hitArea;
    private Transform _transform;
    private FixedJoint _fixedJoint;
    
    private List<Rigidbody> _attachedBodies;
    [SerializeField] private float _rejectForce;
    #endregion


    #region Unity messages

    private void FixedUpdate()
    {
        DetectTargets();
    }

    private void Awake()
    {
        _transform = transform;
        _attachedBodies = new List<Rigidbody>();
    }
    #endregion


    #region private methods
    private void DetectTargets()
    {
        Vector3 colliderSize = _hitArea.bounds.extents;

        Collider[] colliderArray = Physics.OverlapBox(_hitArea.transform.position, colliderSize);
        foreach(Collider collider in colliderArray)
        {
            
           if(collider.gameObject.layer == 3)
            {
                
                if (Input.GetMouseButton(1))
                {
                    //Attirer vers soi
                   
                    Attract(collider);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //repousser avec la force
                    
                    Reject(collider);

                    
                }
            }
        

            

        }
    }



    private void Reject(Collider collider)
    {
        if(_fixedJoint != null)
        {
            Destroy(_fixedJoint);
            collider.attachedRigidbody.AddForce(transform.forward * _rejectForce, ForceMode.Impulse);
        }
        else
        {

            collider.attachedRigidbody.AddForce(transform.forward * _rejectForce, ForceMode.Impulse);
            
        }
        
        
    }



    private void Attract(Collider collider)
    {
        Rigidbody rigidbody = collider.attachedRigidbody;
        float distance = Vector3.Distance(_transform.position, rigidbody.position);
        
        
        if (_attachedBodies.Contains(rigidbody))
        {
            
            return;
        }

        if(distance >= 4)
        {
            
            rigidbody.AddForce(-transform.forward * 1000,ForceMode.Impulse);
        }
        else
        {
            
            _fixedJoint =  _transform.gameObject.AddComponent<FixedJoint>();
            _fixedJoint.connectedBody = rigidbody;
            
            _attachedBodies.Add(rigidbody);
        }
       
    }

    #endregion






}
