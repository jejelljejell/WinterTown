using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePercentage : MonoBehaviour
{
    Text percentageText;

    // Start is called before the first frame update
    void Start()
    {
        percentageText = GetComponent<Text>();
    }

    public void showVolumePercentage(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
