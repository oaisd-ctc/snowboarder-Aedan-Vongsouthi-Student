using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float ReloadDelay = 1f;

    [SerializeField] ParticleSystem deathEffect;

    [SerializeField] AudioClip deathSFX;
    bool aliveStatus = true;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControl();
            if (aliveStatus)
            {
                deathEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(deathSFX);
                aliveStatus = false;
            }
            Invoke("ReloadScene", ReloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
