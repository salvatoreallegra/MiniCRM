import { useState } from "react";
import { createNote, type Note } from "../api/customerApi";

interface AddNoteFormProps {
  customerId: number;
  onNoteCreated: (note: Note) => void;
}

function AddNoteForm({
  customerId,
  onNoteCreated,
}: AddNoteFormProps) {
  const [text, setText] = useState("");

  async function handleSubmit(
    event: React.FormEvent<HTMLFormElement>
  ) {
    event.preventDefault();

    const note = await createNote(customerId, {
      text: text,
    });

    onNoteCreated(note);

    setText("");
  }

  return (
    <form onSubmit={handleSubmit}>
      <input
        value={text}
        onChange={(event) => setText(event.target.value)}
        placeholder="Add note"
      />

      <button type="submit">Add Note</button>
    </form>
  );
}

export default AddNoteForm;