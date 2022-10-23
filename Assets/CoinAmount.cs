using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAmount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("CoinsAmount") + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("Trésor Sauvegardé");
            PlayerPrefs.SetInt("CoinsAmount", int.Parse(gameObject.GetComponent<Text>().text));
        }
    }
}
