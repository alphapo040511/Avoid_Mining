using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

// 현재 자원을 표시할 텍스트 정리
public class CurrencyFormatter
{
    private static readonly string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi" };

    public static string Format(BigInteger value)
    {
        if (value < 1000)
            return value.ToString();

        int suffixIndex = 0;
        decimal displayValue = (decimal)value;

        while (displayValue >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            displayValue /= 1000;
            suffixIndex++;
        }

        return $"{displayValue:F2}{suffixes[suffixIndex]}";
    }
}
