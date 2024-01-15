using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundOnCollision_simple : MonoBehaviour
{
    private AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = this.GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
        myAudioSource.spatialBlend = 1;
        myAudioSource.minDistance = 1;
        myAudioSource.maxDistance = 5;
    }


    void OnCollisionEnter(Collision Col)
    {
        myAudioSource.PlayOneShot(myAudioSource.clip);
        myAudioSource.pitch = (Col.impulse).sqrMagnitude;
        myAudioSource.volume = (Col.impulse).sqrMagnitude;
    }
}
