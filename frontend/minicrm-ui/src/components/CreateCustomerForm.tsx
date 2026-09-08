import { useState } from "react";
import {
  createCustomer,
  type Customer
} from "../api/customerApi";

interface CreateCustomerFormProps {
  onCustomerCreated: (customer: Customer) => void;
}

function CreateCustomerForm({
  onCustomerCreated
}: CreateCustomerFormProps) {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");

  async function handleSubmit(
    event: React.FormEvent<HTMLFormElement>
  ) {
    event.preventDefault();

    const customer = await createCustomer({
      name,
      email
    });

    onCustomerCreated(customer);

    setName("");
    setEmail("");
  }

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Name</label>

        <input
          value={name}
          onChange={(event) =>
            setName(event.target.value)
          }
        />
      </div>

      <div>
        <label>Email</label>

        <input
          type="email"
          value={email}
          onChange={(event) =>
            setEmail(event.target.value)
          }
        />
      </div>

      <button type="submit">
        Create Customer
      </button>
    </form>
  );
}

export default CreateCustomerForm;