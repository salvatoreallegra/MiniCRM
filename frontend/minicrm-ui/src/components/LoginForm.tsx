import { useState } from "react";
import { login } from "../api/customerApi";

interface LoginFormProps {
  onLoginSuccess: () => void;
}

function LoginForm({
  onLoginSuccess,
}: LoginFormProps) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  async function handleSubmit(
    event: React.FormEvent<HTMLFormElement>
  ) {
    event.preventDefault();

    try {
      setError("");

      await login({
        email,
        password,
      });

      onLoginSuccess();
    } catch (error) {
      console.error(error);
      setError("Login failed.");
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Login</h2>

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

      <div>
        <label>Password</label>

        <input
          type="password"
          value={password}
          onChange={(event) =>
            setPassword(event.target.value)
          }
        />
      </div>

      <button type="submit">
        Login
      </button>

      {error && <p>{error}</p>}
    </form>
  );
}

export default LoginForm;