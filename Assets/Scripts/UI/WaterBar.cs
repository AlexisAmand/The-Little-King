using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Slider slider; /* référence au Slider, il faut ajouter using UnityEngine.UI en haut du script */
    public Gradient gradient; 
    public Image fill;

    /* application de la quantité d'oxygène max */
    public void SetMaxOxygen(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    /* modification de la quantité d'oxygène pendant une partie */
    public void SetOxygen(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Debug.LogWarning("Le joueur a maintenant " + health + " Points de vie");
    }
}