class Customer {
    private string _name;
    private Address	_address;

    public Customer(string name, Address address) {
        _name = name;
        _address = address;
    }

    public Customer(string name, string street, string city, string state, string country) : this(name, new Address(street, city, state, country)) {}

    public bool IsUs() {
        return _address.IsUs();
    }

    public string GetName() {
        return _name;
    }

    public Address GetAddress() {
        return _address;
    }
}