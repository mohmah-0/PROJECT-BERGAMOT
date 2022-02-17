using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstantiateCar : MonoBehaviour
{
    public GameObject[] carAr; //create child object to the empty game object
    private int pickedCarIndex;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < carAr.Length; i++)
        {
            if(i == pickedCarIndex)
            {
                Debug.Log(pickedCarIndex);
                //carAr[i].gameObject.SetActive(false);
                selectedCar();
            }
           /* else
            {
                Debug.Log(pickedCarIndex);
                carAr[i].gameObject.SetActive(true);
            }*/
        }
        Debug.Log(pickedCarIndex);
    }

    void instantiatePlayerCar(int carindex)
    {
        Debug.Log(carindex);
        Instantiate(carAr[pickedCarIndex], transform.position, transform.rotation, transform); //instantiate the prefabs

    }

    void selectedCar()
    {
        //Debug.Log(pSelection.carIndex);
        //Debug.LogError("failed");
        pickedCarIndex = playerSelection.selectedIndex; //pSelection.carIndex; //static 
        instantiatePlayerCar(pickedCarIndex);
    }
}
