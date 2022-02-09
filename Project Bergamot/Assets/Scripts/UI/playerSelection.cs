using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSelection : MonoBehaviour
{
    public GameObject playerCellPrefab;
    public GameObject carCellPrefab;

    public void showSelectedInSlot()
    {
        Image carCellImage = carCellPrefab.transform.Find("Model").GetComponent<Image>();
        Image selectedCarImage = playerCellPrefab.transform.Find("Image").GetComponent<Image>();
       
        selectedCarImage.sprite = carCellImage.sprite;
        Debug.Log("selected image: " + selectedCarImage.sprite);
        Debug.Log("playerCell: " + playerCellPrefab.name);
    }
}
