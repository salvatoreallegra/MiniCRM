export interface Customer {
  id: number;
  name: string;
  email: string;
}

export interface CreateCustomerRequest {
  name: string;
  email: string;
}

export interface Note {
  id: number;
  text: string;
  createdAtUtc: string;
}

export interface CustomerDetails {
  id: number;
  name: string;
  email: string;
  notes: Note[];
}

export interface CreateNoteRequest {
  text: string;
}

export interface LoginRequest {
  email: string;
  password: string;
}

//const API_BASE_URL = "https://localhost:7238";
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export async function getCustomers(): Promise<Customer[]> {
  const response = await fetch(
    `${API_BASE_URL}/api/customers?page=1&pageSize=100`,
    {
      credentials: "include",
    }
  );

  if (!response.ok) {
    throw new Error(
      `Failed to load customers: ${response.status}`
    );
  }

  return await response.json();
}

export async function createCustomer(
  request: CreateCustomerRequest
): Promise<Customer> {
  const response = await fetch(
    `${API_BASE_URL}/api/customers`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
      body: JSON.stringify(request),
    }
  );

  if (!response.ok) {
    throw new Error(
      `Failed to create customer: ${response.status}`
    );
  }

  return await response.json();
}

export async function getCustomerDetails(
  id: number
): Promise<CustomerDetails> {
  const response = await fetch(
    `${API_BASE_URL}/api/customers/${id}/details`,
    {
      credentials: "include",
    }
  );

  if (!response.ok) {
    throw new Error(
      `Failed to load customer details: ${response.status}`
    );
  }

  return await response.json();
}

export async function createNote(
  customerId: number,
  request: CreateNoteRequest
): Promise<Note> {
  const response = await fetch(
    `${API_BASE_URL}/api/customers/${customerId}/notes`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
      body: JSON.stringify(request),
    }
  );

  if (!response.ok) {
    throw new Error(
      `Failed to create note: ${response.status}`
    );
  }

  return await response.json();
}

export async function login(
  request: LoginRequest
): Promise<void> {
  const response = await fetch(
    `${API_BASE_URL}/login?useCookies=true`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
      body: JSON.stringify(request),
    }
  );

  if (!response.ok) {
    throw new Error(
      `Login failed: ${response.status}`
    );
  }
}