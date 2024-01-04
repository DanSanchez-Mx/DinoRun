using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;

    // Varable serializable para comprar personajes
    public Character[] character;

    public Button unlockButton;
    public TextMeshProUGUI coinsText;
    //public Text coinsText;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);

        // Seccion para comprar personajes
        skins[selectedCharacter].SetActive(true);

        foreach (Character c in character)
        {
            if (c.price == 0)
                c.isUnlocked = true;
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }

        UpdateUI();
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;

        skins[selectedCharacter].SetActive(true);

        // Seccion para comprar el personaje
        if (character[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        // Actualizar el boton de comprar el personaje
        UpdateUI();
    }

    public void ChangePrevios()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;

        skins[selectedCharacter].SetActive(true);

        // Seccion para comprar el personaje
        if (character[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        // Actualizar el boton de comprar el personaje
        UpdateUI();
    }

    // Funcion para desbloquear el buton de compra del personaje
    public void UpdateUI()
    {
        coinsText.text = "" + PlayerPrefs.GetInt("numCoins", 0);

        if (character[selectedCharacter].isUnlocked == true)
        {
            unlockButton.gameObject.SetActive(false);
        }
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "$ " + character[selectedCharacter].price;

            if (PlayerPrefs.GetInt("numCoins", 0) < character[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("numCoins", 0);
        int price = character[selectedCharacter].price;

        PlayerPrefs.SetInt("numCoins", coins - price);
        PlayerPrefs.SetInt(character[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        character[selectedCharacter].isUnlocked = true;

        UpdateUI();
    }
}