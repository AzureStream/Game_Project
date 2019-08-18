using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 60;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        timeText.text = Mathf.RoundToInt(time).ToString() + " S";
        time -= Time.deltaTime;
    }
}
