using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider timeSlider;

    void Start()
    {
        timeSlider.value = 1;
    }

    void Update()
    {
        Time.timeScale = timeSlider.value;
    }
}
