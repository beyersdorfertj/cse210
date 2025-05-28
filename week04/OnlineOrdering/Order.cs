class Order {
    private int _orderId;
    private Customer _customer;
    private List<Product> _products;
    private Address _shippingAddress;

    public Order(int orderId, Customer customer, Address shippingAddress) {
        _orderId = orderId;
        _customer = customer;
        _shippingAddress = shippingAddress;
        _products = new List<Product>();
    }
    
    public Order(int orderId, Customer customer) : this(orderId, customer, customer.GetAddress()) {}

    public void AddProduct(Product product) {
        _products.Add(product);
    }

    public int GetOrderId() {
        return _orderId;
    }

    public decimal GetTotalPrice() {
        decimal total = 0;
        foreach (var product in _products) {
            total += product.GetTotalPrice();
        }
        return total + (_customer.IsUs() ? 5 : 35);
    }

    public string GetShippingLabel() {
        return $"{_customer.GetName()}\n{_shippingAddress.GetFullAddress()}";
    }

    public string GetPackingLabel() {
        string label = "";
        foreach (var product in _products) {
            label += $"{product.GetQuantity()} x {product.GetName()} ({product.GetProductId()}) \n";
        }
        return label;
    }
}