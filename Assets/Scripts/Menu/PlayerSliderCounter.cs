using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * <summary> Script to show the number of players specified by the player slider </summary>
 */
public class PlayerSliderCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_text;


    /**
     * <summary> Function called when the slider value is changed. Updates the text with the new slider value. </summary>
     */
    public void UpdateText(float sliderValue)
    {
        m_text.text = sliderValue.ToString();
    }
}
