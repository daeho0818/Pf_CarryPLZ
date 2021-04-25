using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    [SerializeField]
    private Image profileImage = null;
    [SerializeField]
    private Text name = null;
    [SerializeField]
    private Text text = null;

    public void setChat(string name, Sprite profile, string newText)
    {
        if (this.profileImage != null && profile != null)
            this.profileImage.sprite = profile;
        if (this.name != null && name != null)
            this.name.text = name;
        this.text.text = newText;
    }
}
