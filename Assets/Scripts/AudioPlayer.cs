using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    #region properties

    public float MaxAudioDelay;

    #endregion properties



    #region fields

    private AudioSource _audio;
    private float _timeBeforePlay;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    private void Start()
    {
        _timeBeforePlay = 0f;
        _audio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (Time.time >= _timeBeforePlay)
        {
            _audio.Play();
            _timeBeforePlay = Time.time + Random.Range(0, MaxAudioDelay);
        }
    }





    #endregion unity messages



    #region private methods


    #endregion private methods
}
