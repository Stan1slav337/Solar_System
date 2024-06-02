using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUIHandler : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject earth;

    void Start()
    {
        if (slider == null)
            return;
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    void Update()
    {
        
    }

    public void ValueChangeCheck()
    {
        if(slider == null || earth == null)
            return;
        Debug.Log(slider.value);
    }
}
