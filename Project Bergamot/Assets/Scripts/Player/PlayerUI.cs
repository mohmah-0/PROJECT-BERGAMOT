using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    PlayerDetails playerDetails;
    Canvas canvas;
    [SerializeField] Sprite[] helmets;

    [SerializeField] List<GameObject> helmetObj;

    [SerializeField] Sprite itemBorder;
    [SerializeField] Sprite itemIcon;
    public GameObject borderItem;

    private void Awake()
    {
        playerDetails = GetComponent<PlayerDetails>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        switch (playerDetails.playerID-1)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                    helmetObj.Add(AddImage(helmets[playerDetails.playerID-1], new Vector3(150*i+75, 1005, 0)));

                borderItem = AddImage(itemBorder, new Vector3(150, 855, 0));
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                    helmetObj.Add(AddImage(helmets[playerDetails.playerID-1], new Vector3(1845 - (150 * i), 1005, 0)));

                borderItem = AddImage(itemBorder, new Vector3(1770, 855, 0));
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                    helmetObj.Add(AddImage(helmets[playerDetails.playerID-1], new Vector3(150 * i + 75, 75, 0)));

                borderItem = AddImage(itemBorder, new Vector3(150, 225, 0));
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                    helmetObj.Add(AddImage(helmets[playerDetails.playerID-1], new Vector3(1845 - (150 * i), 75, 0)));

                borderItem = AddImage(itemBorder, new Vector3(1770, 225, 0));
                break;
        }
    }

    GameObject AddImage(Sprite sprite, Vector3 pos)
    {
        GameObject NewObj = new GameObject(); //Create the GameObject
        Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
        NewImage.sprite = sprite; //Set the Sprite of the Image Component on the new GameObject
        NewObj.GetComponent<RectTransform>().SetParent(canvas.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
        NewObj.GetComponent<RectTransform>().position = pos;
        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
        NewObj.SetActive(true); //Activate the GameObject

        return NewObj;
    }

    public GameObject AddImage(Sprite sprite, Transform parent)
    {
        GameObject NewObj = new GameObject(); //Create the GameObject
        Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
        NewImage.sprite = sprite; //Set the Sprite of the Image Component on the new GameObject
        NewObj.GetComponent<RectTransform>().SetParent(parent); //Assign the newly created Image GameObject as a Child of the Parent Panel.
        NewObj.GetComponent<RectTransform>().position = parent.position;
        NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
        NewObj.SetActive(true); //Activate the GameObject

        return NewObj;
    }

    public void RemoveLastImage()
    {
        Destroy(helmetObj[helmetObj.Count-1]);
        helmetObj.RemoveAt(helmetObj.Count - 1);
    }
}
