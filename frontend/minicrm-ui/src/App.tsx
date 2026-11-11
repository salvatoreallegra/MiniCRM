import {
    BrowserRouter,
    Routes,
    Route
} from "react-router-dom";

import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import DashboardPage from "./pages/DashboardPage";
import ProtectedRoute from "./auth/ProtectedRoute";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginPage />} />

                <Route element={<ProtectedRoute />}>
                    <Route
                        path="/dashboard"
                        element={<DashboardPage />}
                    />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

export default App;