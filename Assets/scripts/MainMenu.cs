using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;
    public GameObject shopUI;
    public GameObject menuUI;

    void Start()
    {
        Sprite[] textures = Resources.LoadAll<Sprite>("Player Skins");
        foreach(Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);
        }
    }

    public void goToShop()
    {
        menuUI.SetActive(false);
        shopUI.SetActive(true);
        
    }

    public void gotoMenu()
    {
        shopUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
