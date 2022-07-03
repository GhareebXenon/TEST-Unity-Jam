using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace Aud.SFX
{
    public class Sfx : MonoBehaviour
    {
        public AudioSource[] soundFX;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                soundFX[0].Play();
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                soundFX[1].Play();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                soundFX[2].Play();
            }
        }

        void OnCollisionEnter2D(Collision2D groundCollision)
        {
            if (groundCollision.relativeVelocity.magnitude > 1)
            {
                if (!soundFX[4].isPlaying)
                    soundFX[4].Play();
            }
            else
            {
                Debug.Log("OnCollisionEnter");
            }
        }
    }
}
