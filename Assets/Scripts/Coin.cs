using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public AudioClip coin;

    private void Update()
    {
        //transform.Rotate(new Vector3(0, 1, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //SoundManager.Instance.EjecutarSonido(coin);

            PlayerManager.numCoins++;
            PlayerPrefs.SetInt("numCoins", PlayerManager.numCoins);
            Destroy(gameObject);
        }
    }
}
