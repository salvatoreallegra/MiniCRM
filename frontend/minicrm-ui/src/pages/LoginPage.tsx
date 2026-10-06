import { useNavigate } from "react-router-dom";
import LoginForm from "../components/LoginForm";

function LoginPage() {
    const navigate = useNavigate();

    return (
        <LoginForm
            onLoginSuccess={() => navigate("/dashboard")}
        />
    );
}

export default LoginPage;