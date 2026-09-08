import { useEffect, useState } from "react";
import {
  getCustomers,
  getCustomerDetails,
  type Customer,
  type CustomerDetails
} from "./api/customerApi";

import CreateCustomerForm from "./components/CreateCustomerForm";
import CustomerList from "./components/CustomerList";

function App() {
  const [customers, setCustomers] =
    useState<Customer[]>([]);

  const [selectedCustomer, setSelectedCustomer] =
    useState<CustomerDetails | null>(null);

  const [error, setError] =
    useState<string>("");

  useEffect(() => {
    async function loadCustomers() {
      try {
        const data = await getCustomers();

        setCustomers(data);
      } catch (error) {
        console.error(error);

        if (error instanceof Error) {
          setError(error.message);
        } else {
          setError("Could not load customers.");
        }
      }
    }

    loadCustomers();
  }, []);

  function handleCustomerCreated(
    customer: Customer
  ) {
    setCustomers((currentCustomers) => [
      ...currentCustomers,
      customer
    ]);
  }

  async function handleCustomerSelected(
    customerId: number
  ) {
    try {
      const customer =
        await getCustomerDetails(customerId);

      setSelectedCustomer(customer);

      console.log(
        "Selected customer:",
        customer
      );
    } catch (error) {
      console.error(error);

      setError(
        "Could not load customer details."
      );
    }
  }

  return (
    <div>
      <h1>MiniCRM</h1>

      <CreateCustomerForm
        onCustomerCreated={handleCustomerCreated}
      />

      {error && <p>{error}</p>}

      <CustomerList
        customers={customers}
        onCustomerSelected={
          handleCustomerSelected
        }
      />

      {selectedCustomer && (
        <div>
          Selected: {selectedCustomer.name}
        </div>
      )}
    </div>
  );
}

export default App;