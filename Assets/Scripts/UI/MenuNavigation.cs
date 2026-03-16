using UnityEngine;

using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour

{

    public Button[] buttons;

    int index = 0;

    void Start()

    {

        SelectButton();

    }

    void Update()

    {

        if (Input.GetKeyDown(KeyCode.DownArrow))

        {

            index++;

            if (index >= buttons.Length)

                index = 0;

            SelectButton();

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))

        {

            index--;

            if (index < 0)

                index = buttons.Length - 1;

            SelectButton();

        }

    }

    void SelectButton()

    {

        buttons[index].Select();

    }

}

