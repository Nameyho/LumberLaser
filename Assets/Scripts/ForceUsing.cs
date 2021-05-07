using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceUsing : MonoBehaviour
{
    #region Fields
    [SerializeField] private Collider _hitArea;
    private Transform _transform; 
    private List<Rigidbody> _attachedBodies;
    [SerializeField] private float _rejectForce;
    [SerializeField] private float _jointDistance;
    [SerializeField] private float _attractForce;
    private bool _mustAttract;
    private bool _mustReject;

    #endregion


    #region Unity messages

    private void FixedUpdate()
    {
        Vector3 colliderSize = _hitArea.bounds.extents;

        Collider[] colliderArray = Physics.OverlapBox(_hitArea.transform.position, colliderSize);
        if (_mustAttract)
        {
            Attract(colliderArray);
            _mustAttract = false;
        }
        if(_mustReject)
        {
            Reject(colliderArray);
            _mustReject = false;
        }
    }

    private void Update()
    {
        DetectInputs();      
    }

    private void Awake()
    {
        _transform = transform;
        _attachedBodies = new List<Rigidbody>();
    }
    #endregion


    #region private methods
    private void DetectInputs()
    {
        if (Input.GetMouseButton(1))
        {
            //Attirer vers soi
            _mustAttract = true;
            Debug.DrawRay(transform.position, transform.forward * 3, Color.blue,1f);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //repousser avec la force
             _mustReject = true;
            Debug.DrawRay(transform.position,transform.forward * 3,Color.red,1f);
        }  
    }



    private void Reject(Collider[] colliderArray)
    {
        foreach (Collider collider in colliderArray)
        {

            if (collider.gameObject.layer != 3) continue;

            Destroy(collider.GetComponent<FixedJoint>());
            _attachedBodies.Remove(collider.attachedRigidbody);
            collider.attachedRigidbody.AddForce(transform.forward * _rejectForce, ForceMode.Impulse);
            
        }
    }



    private void Attract(Collider[] colliderArray)
    {
        foreach (Collider collider in colliderArray)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;
            float distance = Vector3.Distance(_transform.position, rigidbody.position);
        
        
            if (_attachedBodies.Contains(rigidbody) || collider.gameObject.layer != 3)
            {
            
                continue;
            }

            if(distance >= _jointDistance)
            {
            
                rigidbody.AddForce(-transform.forward * _attractForce,ForceMode.Force);
            }
            else
            {
            
                FixedJoint fixedJoint =  collider.gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = GetComponent<Rigidbody>();
                fixedJoint.anchor = _hitArea.bounds.center;
            
                _attachedBodies.Add(rigidbody);
            }
       
        }
    }

    #endregion






}
