using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionPlayerManager : MonoBehaviour
{

    public enum ColorOption
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    [Header("Player Settings")]
    [SerializeField] private ColorOption colorOption;
    [SerializeField] private ColorOption colorWeapon;
    public Color weaponColor;

    public ActionPlayerManager enemy;
    public Renderer playerRenderer;
    public Renderer weapon;
    public TMPro.TextMeshPro scoreText;
    private int score = 0;

    private void Start()
    {
        ActionPlayer((int)colorOption, 1);
    }

    private Color GetColorFromOption(ColorOption option)
    {
        switch (option)
        {
            case ColorOption.Red:
                return Color.red;
            case ColorOption.Blue:
                return Color.blue;
            case ColorOption.Green:
                return Color.green;
            case ColorOption.Yellow:
                return Color.yellow;
            default:
                return Color.yellow;
        }
    }

    public void ChangeColor(int colorToChange)
    {
        colorOption = (ColorOption)colorToChange;
        playerRenderer.material.color = GetColorFromOption((ColorOption)colorToChange);
    }

    public void ActionPlayer(int colorToChange, int targetColor)
    {
        ChangeColor(colorToChange);
        AttackColor(targetColor);
    }

    // Método para realizar un ataque al jugador objetivo
    public void AttackColor(int targetColor)
    {

        Color waepomColor = GetColorFromOption((ColorOption)targetColor);
        colorWeapon = (ColorOption)targetColor;
        weapon.material.color = waepomColor;
    }
    public void Action()
    {
        if (enemy.colorOption == colorWeapon)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
