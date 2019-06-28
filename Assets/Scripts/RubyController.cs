using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get set button from axes
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = transform.position; // Create var and set to our pos

        position.x = position.x + 3.0f * horizontal * Time.deltaTime; // Update new pos if needed
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        transform.position = position; // Set our pos to new pos
    }
}
