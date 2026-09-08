import type { Customer } from "../api/customerApi";

interface CustomerListProps {
  customers: Customer[];
  onCustomerSelected: (customerId: number) => void;
}

function CustomerList({
  customers,
  onCustomerSelected
}: CustomerListProps) {
  return (
    <ul>
      {customers.map((customer) => (
        <li key={customer.id}>
          <button
            type="button"
            onClick={() =>
              onCustomerSelected(customer.id)
            }
          >
            {customer.name}
          </button>

          {" - "}
          {customer.email}
        </li>
      ))}
    </ul>
  );
}

export default CustomerList;