using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _volumeStep = 0.1f;
    private float _minVolumeValue = 0f;
    private float _maxVolumeValue = 1f;
    private float _delay = 1f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource.volume = 0f;
    }

    public void EnableSignal()
    {

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _audioSource.Play();
        _coroutine = StartCoroutine(ChangeVolume(_maxVolumeValue));
    }

    public void DisableSignal()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeVolume(_minVolumeValue));
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        var wait = new WaitForSeconds(_delay);

        while (_audioSource.isPlaying && _audioSource.volume != targetVolume    )
        {
            if (targetVolume > _audioSource.volume)
            {
                _audioSource.volume += _volumeStep;
            }
            else
            {
                _audioSource.volume -= _volumeStep;
            }

            yield return wait;
        }

        if (targetVolume == _minVolumeValue)
        {
            _audioSource.Stop();
        }
    }
}