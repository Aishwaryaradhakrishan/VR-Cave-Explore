using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Hammer : MonoBehaviour
{
    public int hitsToBreak = 3;   // Number of hits needed
    private int currentHits = 0;
    [SerializeField] private XRGrabInteractable interactable;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveAllListeners();
        interactable.selectExited.RemoveAllListeners();
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
       transform.GetComponent<Rigidbody>().isKinematic = false;
    }


    private void OnSelectExited(SelectExitEventArgs args)
    {
        transform.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            currentHits++;
            
            Debug.Log("Rock hit: " + currentHits);

            // Child 0 = Whole rock
            // Child 1 = Cracked rock
            // Child 2 = Gold

            if (currentHits == hitsToBreak)
            {
                // Show cracked version
                collision.transform.GetChild(0).gameObject.SetActive(false);
                collision.transform.GetChild(1).gameObject.SetActive(true);
                gameManager.EnableGoldRocks();
            }
        }
    }
}
