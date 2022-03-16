using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;
    public GameObject buttonSelectedInMain, buttonSelectedInOptions;
    public Slider leftDifficultySlider, rightDifficultySlider;

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonSelectedInOptions);
        GameSettings.ComputerPlayOnLeft = GameSettings.ComputerPlayOnRight = false;
        if (GameSettings.ComputerPlayOnLeft)
        {
            leftDifficultySlider.interactable = true;
        }
        else
        {
            leftDifficultySlider.interactable = false;
        }
        
        if (GameSettings.ComputerPlayOnRight)
        {
            rightDifficultySlider.interactable = true;
        }
        else
        {
            rightDifficultySlider.interactable = false;
        }
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonSelectedInMain);
    }
}
