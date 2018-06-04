using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void LobbyMapSceneChange()
    {
        SceneManager.LoadScene("TestMap");
    }

    public void MapLobbySceneChange()
    {
        SceneManager.LoadScene("Lobby");
    }

<<<<<<< HEAD
    public void LobbyGameStartSceneChange()
    {
        SceneManager.LoadScene("TestMap2");
=======
    public void IntroLobbySceneChange()
    {
        SceneManager.LoadScene("Lobby");
>>>>>>> 5a439ae95d819318c991d7289ab0b0773fb73caf
    }
}
