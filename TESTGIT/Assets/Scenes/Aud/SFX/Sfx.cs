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
            if(Input.GetKeyDown(KeyCode.D))
            {
                soundFX[0].Play();
            }

            else if(Input.GetKeyDown(KeyCode.A))
            {
                soundFX[1].Play();
            }
            else if (Input.GetKeyDown(KeyCode.Space)) {
                soundFX[2].Play();
            }
            else {
                Debug.LogWarning("Error, sound files not found!");
                Thread.Sleep(5000);
            }
        }
    }
}
