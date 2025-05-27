class Fraction {
    public int _top;
    public int _bottom;

    public Fraction() : this(1, 1) {} // Default to 1/1	

    public Fraction(int top) : this(top, 1) {} // Default bottom to 1

    public Fraction(int top, int bottom) {
        if (bottom == 0) {
            throw new ArgumentException("Bottom can not be zero.");
        }
        _top = top;
        _bottom = bottom;
    }

    public int GetTop() {
        return _top;
    }

    public void SetTop(int top) {
        _top = top;
    }

    public int GetBottom() {
        return _bottom;
    }

    public void SetBottom(int bottom) {
        if (bottom == 0) {
            throw new ArgumentException("Bottom can not be zero.");
        }
        _bottom = bottom;
    }

    public string GetFrationString() {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue() {
        return (double)_top / _bottom;
    }
}