using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnMapSelect : MonoBehaviour,ISelectHandler,IDeselectHandler
{
    [SerializeField] Button button;
    [SerializeField] Text buttonText;
    [SerializeField] Text currentMapText;
    public GameObject mapDisplayer;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        currentMapText = GameObject.Find("MapName").GetComponent<Text>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
        currentMapText.text = this.buttonText.text;
        mapDisplayer.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was Deselected");
        mapDisplayer.SetActive(false);
    }
}
