using UnityEngine;
using TMPro;

public class PlanetInfo : MonoBehaviour
{
    public string infoText;
    public GameObject infoPanel;
    public TextMeshProUGUI infoTextComponent;

    void OnMouseDown()
    {
        bool sameText = infoTextComponent.text == infoText;
        infoTextComponent.text = infoText;

        if(sameText)
        {
            infoTextComponent.text = "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoTextComponent.text = infoText;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoTextComponent.text = "";
        }
    }
}
