using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carDisplay : MonoBehaviour
{
    //public createCar Car;
    public List<createCar> carList = new List<createCar>();
    public GameObject carCellPrefab;

    [Header("Properties") ]
    [SerializeField] private Text nameText;
    [SerializeField] private Image artworkImage;

    private void Start()
    {
        // Display all the car in the list 
        //loop through
        foreach(createCar Car in carList)
        {
            spawnCarCellUI(Car);

        }
       // nameText.text = Car.carText;
       // artworkImage.sprite = Car.carImage;
    }

    //function to display them
    private void spawnCarCellUI(createCar car)
    {
        GameObject carCell = Instantiate(carCellPrefab,transform);

        artworkImage = carCell.transform.Find("Model").GetComponent<Image>();
        nameText = carCell.transform.Find("Model_text").GetComponent<Text>();

        nameText.text = car.carText;
        artworkImage.sprite = car.carImage;
    }
}
