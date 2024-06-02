using UnityEngine;
using TMPro;

public class PlanetInfo : MonoBehaviour
{
    public string infoText; // The info text that will be displayed on the panel
    public GameObject infoPanel; // Reference to the information panel
    public TextMeshProUGUI infoTextComponent; // Reference to the TextMeshPro component in the panel

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
        if (other.CompareTag("Player")) // Make sure your player has a tag "Player"
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
