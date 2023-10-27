using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    // Referinta la rigidbody-ul masinii
    public Rigidbody theCar;

    // Referinta la SpeedText
    public TMPro.TMP_Text speedLabel;

    // Update is called once per frame
    void Update()
    {
        // Viteza masinii 
        float speed = theCar.velocity.magnitude * 3.6f;

        speedLabel.text = (int)speed + "";
        speedLabel.alignment = TMPro.TextAlignmentOptions.Center;
    }
}
