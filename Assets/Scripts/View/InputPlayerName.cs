using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputPlayerName : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _buttonOk;
    [SerializeField] private TMP_InputField _inputName;

    public TMP_Text Text => _text;

    public Button ButtonOk => _buttonOk;

    public TMP_InputField InputName => _inputName;
}
