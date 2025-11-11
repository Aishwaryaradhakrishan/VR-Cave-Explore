using UnityEngine;

public class BatFlySound : MonoBehaviour
{
    public AudioSource batAudio; // Assign bat sound AudioSource in Inspector
    public bool isFlying = false;

    void Update()
    {
        if (isFlying && !batAudio.isPlaying)
        {
            batAudio.Play();
        }
        else if (!isFlying && batAudio.isPlaying)
        {
            batAudio.Stop();
        }
    }

    // You can call this from another script or animation event
    public void StartFlying()
    {
        isFlying = true;
    }

    public void StopFlying()
    {
        isFlying = false;
    }
}

