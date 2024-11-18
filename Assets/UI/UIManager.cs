using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Slider fuelSlider;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateFuel(float fuel)
    {
        fuelSlider.value = fuel;
    }
}
