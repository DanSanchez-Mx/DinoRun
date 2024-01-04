using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    int characterIndex;

    public static int numCoins;
    public TextMeshProUGUI coinsText;

    public CinemachineVirtualCamera VCam;

    private void Awake()
    {
        numCoins = PlayerPrefs.GetInt("numCoins", 0);

        // Seccion para cambiar el personaje
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(characterPrefabs[characterIndex], new Vector3(-5, -2, -1), Quaternion.identity);

        // Seccion para hacer que la camara siga al personaje independientemente del personaje seleccionado
        VCam.m_Follow = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Linea para regresar a 0 todos los prefabs
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "" + numCoins;
    }
}
