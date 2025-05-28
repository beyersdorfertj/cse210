class Product {
    private int _productId;
    private string _name;
    private decimal _price;
    private int _quantity;

    public Product(int productId, string name, decimal price, int quantity) {
        _productId = productId;
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalPrice() {
        return _price * _quantity;
    }

    public int GetProductId() {
        return _productId;
    }

    public string GetName() {
        return _name;
    }

    public int GetQuantity() {
        return _quantity;
    }
}