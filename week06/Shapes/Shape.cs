abstract class Shape {

    public Shape(string color) {
        _color = color;
    }

    protected string _color;
    public string GetColor() {
        return _color;
    }
    protected void SetColor(string color) {
        _color = color;
    }

    public abstract double GetArea();
}