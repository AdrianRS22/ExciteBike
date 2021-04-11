using UnityEngine;
using System.Linq;

public class StartingMarksController : MonoBehaviour
{
    public void ClosingStartingMarks()
    {
        var animators = GetComponentsInChildren<Animator>().Where(x => x.CompareTag("StartingMark"));

        foreach (var animator in animators)
        {
            animator.SetBool("isClosing", true);
        }
    }
}
