using NetDevPack.Domain;

namespace Delirio.Modules.Email.Domain.Models
{
    public class Order : Entity, IAggregateRoot
    {
        private IList<Store> _stores;
        
        private IList<Customer> _customers;
        
        public Order(int orderNumber, decimal totalValue)
        {
            Id = Id;
            _stores = new List<Store>();
            _customers = new List<Customer>();
            OrderNumber = orderNumber;
            TotalValue = totalValue;
            
        }

        public int? OrderNumber { get; private set; }

        public decimal? TotalValue { get; private set; }
             
        
        public Customer Customer { get; private set; }

        public Store Store { get; private set; }

        public Guid CustomerId { get; set; }

        public Guid StoreId { get; set; }

        public IReadOnlyCollection<Customer> Customers { get { return _customers.ToArray(); } }
        
        public DateTime OrderDate { get; private set; }

        public IReadOnlyCollection<Store> Stores { get { return _stores.ToArray(); } }
        
    }
}