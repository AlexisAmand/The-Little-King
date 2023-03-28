using UnityEngine.SceneManagement;
using UnityEngine;
using System;


public class MainMenu : MonoBehaviour
{
    /* Niveau à charger */
    public string levelToload;

    public GameObject settingsWindow;
    public GameObject introWindow; 
    public GameObject exitConfirmWindow;
    public GameObject helpWindows;

    // cette fonction lance le jeu quand on appuye sur le bouton jouer de la popup intro
    public void StartGame()
    {    
        SceneManager.LoadScene(levelToload);
        // introWindow.SetActive(false);
    }

    // cette fonction affiche une sorte de popup avant de démarrer le jeu.
    public void ShowIntro()
    {
        introWindow.SetActive(true);
    }

    // cette fonction affiche fenêtre des options
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    // cette fonction ferme la fenêtre des options
    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        introWindow.SetActive(false);
        helpWindows.SetActive(false);
    }

    // cette fonction ouvre la scene qui contient les crédits
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    // cette fonction permet de quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
    }

    // TODO : les deux fonctions qui suivent sont surement fusionnables

    // afficher la confirmation avant de quitter le jeu
    public void exitConfirmWindowShow()
    {
        exitConfirmWindow.SetActive(true);
    }

    // cacher la confirmation avant de quitter le jeu
    public void exitConfirmWindowHidden()
    {
        exitConfirmWindow.SetActive(false);
    }

    // Affichage de l'aide
    public void LoadHelpScene()
    {
        // SceneManager.LoadScene("Help");
        helpWindows.SetActive(true);
    }

    // Retour sur le menu principal
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChooseYourLevel(string levelToload)
    {
        SceneManager.LoadScene(levelToload);
    }

}