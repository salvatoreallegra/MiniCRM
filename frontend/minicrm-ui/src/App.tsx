import { useEffect, useState } from "react";
import {
  getCustomers,
  getCustomerDetails,
  type Customer,
  type CustomerDetails,
  type Note,
} from "./api/customerApi";

import LoginForm from "./components/LoginForm";
import CreateCustomerForm from "./components/CreateCustomerForm";
import CustomerList from "./components/CustomerList";
import CustomerDetailsComponent from "./components/CustomerDetails";
import AddNoteForm from "./components/AddNoteForm";

function App() {
  const [loggedIn, setLoggedIn] =
    useState<boolean>(false);

  const [customers, setCustomers] =
    useState<Customer[]>([]);

  const [selectedCustomer, setSelectedCustomer] =
    useState<CustomerDetails | null>(null);

  const [error, setError] =
    useState<string>("");

  const [loading, setLoading] =
    useState<boolean>(false);

  useEffect(() => {
    if (!loggedIn) {
      return;
    }

    async function loadCustomers() {
      try {
        setLoading(true);
        setError("");

        const data = await getCustomers();

        setCustomers(data);
      } catch (error) {
        console.error(error);

        if (error instanceof Error) {
          setError(error.message);
        } else {
          setError("Could not load customers.");
        }
      } finally {
        setLoading(false);
      }
    }

    loadCustomers();
  }, [loggedIn]);

  function handleCustomerCreated(
    customer: Customer
  ) {
    setCustomers((currentCustomers) => [
      ...currentCustomers,
      customer,
    ]);
  }

  async function handleCustomerSelected(
    customerId: number
  ) {
    try {
      setLoading(true);
      setError("");

      const customer =
        await getCustomerDetails(customerId);

      setSelectedCustomer(customer);
    } catch (error) {
      console.error(error);

      setError(
        "Could not load customer details."
      );
    } finally {
      setLoading(false);
    }
  }

  function handleNoteCreated(note: Note) {
    setSelectedCustomer((currentCustomer) => {
      if (currentCustomer === null) {
        return null;
      }

      return {
        ...currentCustomer,
        notes: [
          ...currentCustomer.notes,
          note,
        ],
      };
    });
  }

  if (!loggedIn) {
    return (
      <LoginForm
        onLoginSuccess={() =>
          setLoggedIn(true)
        }
      />
    );
  }

  return (
    <div>
      <h1>MiniCRM</h1>

      <CreateCustomerForm
        onCustomerCreated={handleCustomerCreated}
      />

      {error && <p>{error}</p>}

      {loading && <p>Loading...</p>}

      <CustomerList
        customers={customers}
        onCustomerSelected={
          handleCustomerSelected
        }
      />

      {selectedCustomer && (
        <>
          <CustomerDetailsComponent
            customer={selectedCustomer}
          />

          <AddNoteForm
            customerId={selectedCustomer.id}
            onNoteCreated={handleNoteCreated}
          />
        </>
      )}
    </div>
  );
}

export default App;