using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DecimalRuler : MonoBehaviour
{
    public const float ONE_INCH_MARK = -1.714f;
    public const float TWO_INCH_MARK = 1.716f;
    public const float LINE_TOP    = 4;
    public const float LINE_BOTTOM = 1.42f;

    public TMP_InputField inputField;
    public LineRenderer lr;

    private float decimalData;

    private void Start()
    {
        ResetLine();
        ReActivateField();
    }

    private float CalculateLinePosition(float percentage)
    {
        float range = TWO_INCH_MARK - ONE_INCH_MARK;

        return ONE_INCH_MARK + range*percentage;
    }

    private void ResetLine()
    {
        lr.SetPosition(0, new Vector3(ONE_INCH_MARK, LINE_TOP, 0));
        lr.SetPosition(1, new Vector3(ONE_INCH_MARK, LINE_BOTTOM, 0));
    }

    public void DrawLineFromDecimal()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            // Handle the case of null or empty string (e.g., return default value, throw exception)
            Debug.Log("String is null or empty.");
            ResetLine();
            return; // Or throw an exception
        }

        // Proceed with conversion only if the string is not null or empty
        if (!float.TryParse(inputField.text, out decimalData))
        {
            // Handle the case of invalid format or raise Exception
            Debug.Log("float.TryParse() failed: " + inputField.text);
            ResetLine();
            return;
        }

        // Only interested in fractional data
        decimalData -= (int)decimalData;

        float linePosition = CalculateLinePosition(decimalData);
        Debug.Log(linePosition);

        lr.SetPosition(0, new Vector3(linePosition, LINE_TOP, 0));
        lr.SetPosition(1, new Vector3(linePosition, LINE_BOTTOM, 0));
    }

    public void ReActivateField()
    {
        inputField.ActivateInputField();
    }
}
