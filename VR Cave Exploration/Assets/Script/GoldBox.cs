using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GoldBox : MonoBehaviour
{
    [SerializeField] private Animator boxAnimator;
    [SerializeField] private TMP_Text guideText; // TextMeshPro text

    private int goldCount = 0;
    private List<GameObject> goldObjects = new List<GameObject>();
    private bool boxClosed = false;
    public GameManager gameManager;

    private void Start()
    {
        // Hide the guide text at the start
        if (guideText)
            guideText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            if (!goldObjects.Contains(collision.gameObject))
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                XRGrabInteractable grab = collision.gameObject.GetComponent<XRGrabInteractable>();

                if (rb) rb.isKinematic = true;
                if (grab) grab.enabled = false;

                goldObjects.Add(collision.gameObject);
                goldCount++;

                Debug.Log("Gold Count: " + goldCount);

                if (goldCount == 2 && !boxClosed)
                {
                    boxClosed = true;
                    StartCoroutine(CloseBoxAndShowText());
                }
            }
        }
    }

    private IEnumerator CloseBoxAndShowText()
    {
        // Small delay to make closing feel natural
        //yield return new WaitForSeconds(1f);

        // Play the closing animation
        boxAnimator.SetBool("closebox", true);
       

        //Debug.Log("HFuhgoeirgj...." + boxAnimator.GetCurrentAnimatorClipInfo(0));

        yield return new WaitForSeconds(5f);

        gameManager.ShowGrabTextPanel();


        // Disable gold visuals
        foreach (GameObject gold in goldObjects)
        {
            gold.SetActive(false);
        }

        // Wait for the animation to finish
        yield return new WaitForSeconds(1.5f);

        // Now show the text
        if (guideText)
        {
            guideText.text = "The box is now closed. Grab the box outside to complete the task.";
            guideText.gameObject.SetActive(true);
        }

        Debug.Log("Box closed — guide text shown.");
    }
}
