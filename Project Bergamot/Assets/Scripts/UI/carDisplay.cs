using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carDisplay : MonoBehaviour
{
    public List<createCar> carList = new List<createCar>();
    public GameObject carCellPrefab;


     private Text nameText;
     private Image artworkImage;

    private void Start()
    {
        foreach(createCar Car in carList)
        {
            spawnCarCellUI(Car);
        }
    }

    //function to display them
    private void spawnCarCellUI(createCar car)
    {
        GameObject carCell = Instantiate(carCellPrefab,transform);
        Debug.Log(carCell, carCell );   
        artworkImage = carCell.transform.Find("Model").GetComponent<Image>();
        nameText = carCell.transform.Find("Model_text").GetComponent<Text>();

        nameText.text = car.carText;
        artworkImage.sprite = car.carImage;
    }
}
