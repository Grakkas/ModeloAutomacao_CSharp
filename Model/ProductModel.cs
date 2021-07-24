
namespace ModeloAutomacao_CSharp.Model
    {
    class ProductModel
        {

        private string _Name;
        public string Name { get => _Name; set => _Name = value; }

        private string _Price;
        public string Price { get => _Price; set => _Price = value; }

        private string _Quantity;
        public string Quantity { get => _Quantity; set => _Quantity = value; }

        public ProductModel(string name, string price = "", string quantity = "")
            {
            Name = name;
            Price = price;
            Quantity = quantity;
            }
        }
    }
