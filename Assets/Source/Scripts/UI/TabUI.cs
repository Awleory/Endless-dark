
using UnityEngine;

public class TabUI : MonoBehaviour
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void ChangeVisibilityState()
    {
        if (gameObject.activeSelf)
            Hide();
        else
            Show();
    }
}
