import type {
  CustomerDetails as CustomerDetailsType
} from "../api/customerApi";

interface CustomerDetailsProps {
  customer: CustomerDetailsType;
}

function CustomerDetails({
  customer
}: CustomerDetailsProps) {
  return (
    <div>
      <h2>{customer.name}</h2>

      <p>{customer.email}</p>

      <h3>Notes</h3>

      {customer.notes.length === 0 ? (
        <p>No notes yet.</p>
      ) : (
        <ul>
          {customer.notes.map((note) => (
            <li key={note.id}>
              {note.text}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default CustomerDetails;
