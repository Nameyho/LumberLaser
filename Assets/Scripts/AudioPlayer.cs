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
    private Transform _player;
    private Transform _transform;
    [SerializeField] private float _distanceFromPlayer;

    #endregion fields



    #region public methods

    #endregion public methods



    #region unity messages

    private void Start()
    {
        _timeBeforePlay = 0f;
        _audio = transform.GetComponent<AudioSource>();
        _player = GameObject.Find("Player").transform;
        _transform = transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        PlayAudio();
        
    }

    #endregion unity messages



    #region private methods


    private void PlayAudio()
    {
        float distance = Vector3.Distance(_player.position, _transform.position);

        if (Time.time >= _timeBeforePlay && distance <= _distanceFromPlayer)
        {
            _audio.Play();
            _timeBeforePlay = Time.time + Random.Range(0, MaxAudioDelay);
        }
    }

    #endregion private methods
}
