import {
    createContext,
    useContext,
    useEffect,
    useState,
    type ReactNode
} from "react";

interface AuthContextType {
    isAuthenticated: boolean;
    loading: boolean;
    refreshAuth: () => Promise<void>;
}

const AuthContext = createContext<AuthContextType | undefined>(
    undefined
);

export function AuthProvider({ children }: { children: ReactNode }) {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [loading, setLoading] = useState(true);

    async function refreshAuth(): Promise<void> {
        try {
            const response = await fetch(
                `${import.meta.env.VITE_API_BASE_URL}/api/auth/me`,
                { credentials: "include" }
            );

            setIsAuthenticated(response.ok);
        } catch {
            setIsAuthenticated(false);
        } finally {
            setLoading(false);
        }
    }

    useEffect(() => {
        void refreshAuth();
    }, []);

    return (
        <AuthContext.Provider
            value={{ isAuthenticated, loading, refreshAuth }}
        >
            {children}
        </AuthContext.Provider>
    );
}

export function useAuth() {
    const context = useContext(AuthContext);

    if (context === undefined) {
        throw new Error("useAuth must be used inside AuthProvider");
    }

    return context;
}