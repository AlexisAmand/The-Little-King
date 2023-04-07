using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider; /* référence au Slider, il faut ajouter using UnityEngine.UI */
    public Gradient gradient;
    public Image fill;

    /* application de la vie max */
    public void SetMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Debug.LogWarning("Le joueur a maintenant " + health + " Points de vie");
    }

}
