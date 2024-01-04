using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Back2Menu()         { SceneManager.LoadScene("Menu"); }

    public void Gameplay()          { SceneManager.LoadScene("Gameplay"); }

    public void CharactersSelect()  { SceneManager.LoadScene("CharacterSelect"); }
}
