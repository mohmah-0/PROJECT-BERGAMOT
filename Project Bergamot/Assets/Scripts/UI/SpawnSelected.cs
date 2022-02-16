using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSelected : MonoBehaviour
{
    //Note the carAr is in ordered
    public GameObject[] carAr; //create child object to the empty game object
    private int pickedCarIndex1; //p1 seleceted car 
    private int pickedCarIndex2; //p2 selected car

    // Start is called before the first frame update
    void Start()
    {
        //Note: I haven't done the starting pos; so they will spawn at the same place
        //Instantiate the Selected car based on the player selected car index
            if (carAr[pickedCarIndex1])
            {
                selectedCar();
                instantiatePlayerCar(pickedCarIndex1);
            }

            if (carAr[pickedCarIndex2])
            {
                selectedCar();
                instantiatePlayerCar(pickedCarIndex2);
            }
    }

    void instantiatePlayerCar(int carindex)
    {
        //Set also starting position

        //instantiate the car with respective index of the carAr 
        Instantiate(carAr[carindex], transform.position, transform.rotation, transform); //instantiate the prefabs
        
    }

    void selectedCar()
    {
        //Get the stored index data from the playerSelect script through playerPref
        pickedCarIndex1 = PlayerPrefs.GetInt("PlayerSelected1");
        pickedCarIndex2 = PlayerPrefs.GetInt("PlayerSelected2");
    }
}
