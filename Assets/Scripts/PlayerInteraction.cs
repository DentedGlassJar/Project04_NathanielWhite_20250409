using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactableObj = null;

    public GameObject hamburgerObj;
    public GameObject billObj;

    public GameObject gemCoinObj;
    public GameObject billCoinObj;
    public GameObject marshCoinObj;

    public TMP_Text infoText;
    public TMP_Text coinText;
    public TMP_Text gemText;
    
    public int gemCount;
    public int coinCount;

    public bool marshmallowCollected;
    public bool billCollected;
    public bool chiselCollected;

    public void Start()
    {
        gemCount = 0;
        coinCount = 0;

        marshmallowCollected = false;
        billCollected = false;
        chiselCollected = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Player entered Interact Object!");
            interactableObj = collision.gameObject;
        }
    }

    private void Update()
    {
        if (hamburgerObj == null)
        {
            hamburgerObj = GameObject.Find("Hamburger");
        }

        if (billObj == null)
        {
            billObj = GameObject.Find("Bill");
        }

        if (gemCoinObj == null)
        {
            gemCoinObj = GameObject.Find("GemCoin");
        }

        if (billCoinObj == null)
        {
            billCoinObj = GameObject.Find("BillCoin");
        }

        if (marshCoinObj == null)
        {
            marshCoinObj = GameObject.Find("MarshCoin");
        }

        coinText.text = $"{coinCount} / 3";
        gemText.text = $"{gemCount} / 5";

        if (coinCount >= 3 && hamburgerObj != null)
        {
            hamburgerObj.transform.position = new Vector3(-6, 2.5f, 0);
        }

        if (chiselCollected == true && billObj != null)
        {
            billObj.transform.position = new Vector3(-2, 2, 0);
        }

        if (gemCount >= 5 && gemCoinObj != null)
        {
            gemCoinObj.transform.position = new Vector3(3.5f, 1.5f, 0);
        }

        if (billCollected == true && billCoinObj != null)
        {
            billCoinObj.transform.position = new Vector3(6.5f, 2, 0);
        }

        if (marshmallowCollected == true && marshCoinObj != null)
        {
            marshCoinObj.transform.position = new Vector3(0.25f, 2, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && interactableObj != null)
        {
            //Debug.Log($"Hey, the player is now interacting with {interactableObj}");
            interactableObj.GetComponent<InteractionObject>().Interact(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactableObj = null;
            infoText.text = "";
        }
    }
}
