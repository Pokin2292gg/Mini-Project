using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public DoorController door;
    public float eyeDistance = 5.0f;
    private Ray ray;
    private RaycastHit hitData;
    public Text msg;
    public int itemCount = 0;
    public GameObject itemToDrop;
    public GameObject itemToDropPrefab;
    public Text itemCountText;
    public GameObject endGameCanvas;

    void Start()
    {
        msg.gameObject.SetActive(false);
        UpdateItemCountText();
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);

        if (Physics.Raycast(ray, out hitData, eyeDistance))
        {
            switch (hitData.transform.gameObject.tag)
            {
                case "doors":
                    msg.text = "Press F to Open/Close";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door.control();
                    }
                    break;

                case "Monster":
                    msg.text = " kill him Left mouse";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.yellow);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Destroy(hitData.transform.gameObject);
                        DropItem(hitData.transform.position);
                    }
                    break;
                 case "Monster2":
                    msg.text = " kill him Left mouse";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.yellow);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Destroy(hitData.transform.gameObject);
                    }
                    break;
                 
                case "Silde":
                    msg.text = "Press F to Open/Close";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door.control();
                    }
                    break;
                
                case "Item":
                    msg.text = "Press E to Pick Up";
                    msg.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.blue);
                   
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        itemCount++;
                        UpdateItemCountText();

                        if(itemCount <= 5)
                        {
                            msg.text = itemCount + "/5Item";
                        }

                        
                    }
                    break;
            
                default:
                    msg.gameObject.SetActive(false);
                    break;
            }
        }
        else
        {
            msg.gameObject.SetActive(false);
        }


        
        if (itemCount == 5)
        {
            msg.text = "Game End";
            msg.gameObject.SetActive(true);
            EndGame();
        }
    }

    void DropItem(Vector3 position)
    {
        if (itemToDropPrefab != null)
        {
            Instantiate(itemToDropPrefab, position, Quaternion.identity);
        }
    }

    void UpdateItemCountText()
    {
        itemCountText.text = "Item Count: " + itemCount;
    }

    void EndGame()
    {
        if (endGameCanvas != null)
        {
            endGameCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("End Game Canvas is not assigned in the Inspector!");
        }
        Debug.Log("Game end");
    }
}
