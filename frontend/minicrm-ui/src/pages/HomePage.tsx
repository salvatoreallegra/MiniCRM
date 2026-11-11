import { Link } from "react-router-dom";

function HomePage() {
    return (
        <div>
            <h1>MiniCRM</h1>

            <p>Simple customer management.</p>

            <Link to="/login">Login</Link>
        </div>
    );
}

export default HomePage;