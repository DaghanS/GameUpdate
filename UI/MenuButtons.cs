using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void ClassButton()
    {
        SceneManager.LoadScene("ClassMenu");
    }
    public void InventoryButton()
    {
        SceneManager.LoadScene("Loadouts");
    }
}
