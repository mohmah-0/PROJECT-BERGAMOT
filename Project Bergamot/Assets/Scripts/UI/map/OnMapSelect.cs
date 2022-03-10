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
    [SerializeField] Animator animator;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        currentMapText = GameObject.Find("MapName").GetComponent<Text>();
        animator = GetComponentInParent<Animator>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        currentMapText.text = this.buttonText.text;
        mapDisplayer.SetActive(true);
        if(this.gameObject.name == "Map1Btn") { animator.SetBool("map1", true); } 
        else if (this.gameObject.name == "Map2Btn") { animator.SetBool("map2", true); }
           
    }
    public void OnDeselect(BaseEventData eventData)
    {
        mapDisplayer.SetActive(false);
        if (this.gameObject.name == "Map1Btn") { animator.SetBool("map1", false); }
        else if (this.gameObject.name == "Map2Btn") { animator.SetBool("map2", false); }
    }

}
