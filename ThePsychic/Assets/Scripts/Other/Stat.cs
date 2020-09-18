using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField] private float _value, _valueMin, _valueMax, _coef;

    public Stat(float valueMax)
    {
        _value = valueMax;
        _valueMin = 0;
        _valueMax = valueMax;
        _coef = _value / _valueMax;
    }

    public Stat(float value, float valueMax)
    {
        _value = value;
        _valueMin = 0;
        _valueMax = valueMax;
        _coef = _value / _valueMax;
    }

    public Stat(float value, float valueMin, float valueMax)
    {
        _value = value;
        _valueMin = valueMin;
        _valueMax = valueMax;
        _coef = _value / _valueMax;
    }

    public void AddValue(float value)
    {
        float result = _value + value;

        if(result > _valueMax)  
        {
            _value = _valueMax;
        }
        else
        {
            _value = result;
        }
        _coef = _value / _valueMax; 
    }

    public void LessValue(float value)
    {
        float result = _value - value;

        if (result < _valueMin)
        {
            _value = _valueMin;
        }
        else
        {
            _value = result;
        }
        _coef = _value / _valueMax;
    }
}
