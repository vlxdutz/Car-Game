using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour {

    // Referinta la componenta audio
    AudioSource audioClip;

    // Referinta la pitch-ul din sursa audio
    public float minPitch;

    // Pitch-ul masinii
    private float pitchFromCar;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = GetComponent<AudioSource>();

        // Seteam pitch-ul
        audioClip.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = Player.playerScript.carCurrentSpeed;

        if(pitchFromCar < minPitch) {
            audioClip.pitch = minPitch;
        } else {
            audioClip.pitch = pitchFromCar;
        }

        if(PauseMenu.gameIsPaused) {
            audioClip.pitch = 0f;
        }
    }
}
