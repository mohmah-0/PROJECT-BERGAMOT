using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSelection : MonoBehaviour
{

    public GameObject playerCellPrefab;
    public GameObject carCellPrefab;
    public GameObject carPrefab;

    //[HideInInspector]
    public int carIndex;

    private int p1SelectedCarIndex;
    private int p2SelectedCarIndex;


    static bool isSelected = true; // player Select

    public void showSelectedInSlot()
    {
        //Change the playerCell image based on the selected car
        Image carCellImage = carCellPrefab.transform.Find("Model").GetComponent<Image>();
        Image selectedCarImage = playerCellPrefab.transform.Find("Image").GetComponent<Image>();
       
        selectedCarImage.sprite = carCellImage.sprite;
        
     //   Debug.Log("selected image: " + selectedCarImage.sprite);
       // Debug.Log("playerCell: " + playerCellPrefab.name);

        saveCarIndex();
    }

    void saveCarIndex()
    {
        //Store the playerPref to respective player  
        if(isSelected == true)
        {
            if (p1SelectedCarIndex >= 0)
            {
                //store the car to the respective player
                p1SelectedCarIndex = carIndex;
                PlayerPrefs.SetInt("PlayerSelected1", p1SelectedCarIndex);
                isSelected = false;
            }

        }

        //Player 2
        if (isSelected == false)
        {
            if (p2SelectedCarIndex >= 0)
            {
                p2SelectedCarIndex = carIndex;
                PlayerPrefs.SetInt("PlayerSelected2", p2SelectedCarIndex);
            }
        }
    }
}
