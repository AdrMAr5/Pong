using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSettings : MonoBehaviour
{
    public Slider leftDifficultySlider, rightDifficultySlider;

    public void ChangeComputerOnLeft()
    {
        GameSettings.ComputerPlayOnLeft = !GameSettings.ComputerPlayOnLeft;
        if (GameSettings.ComputerPlayOnLeft)
        {
            leftDifficultySlider.interactable = true;
        }
        else
        {
            leftDifficultySlider.interactable = false;
        }
    }

    public void ChangeComputerOnRight()
    {
        GameSettings.ComputerPlayOnRight = !GameSettings.ComputerPlayOnRight;
        if (GameSettings.ComputerPlayOnRight)
        {
            rightDifficultySlider.interactable = true;
        }
        else
        {
            rightDifficultySlider.interactable = false;
        }
    }

    public void ChangeLevelLeft()
    {
        GameSettings.ComputerLeftDifficulty = (int) leftDifficultySlider.value;
    }

    public void ChangeLevelRight()
    {
        GameSettings.ComputerRightDifficulty = (int) rightDifficultySlider.value;
    }
    
}
