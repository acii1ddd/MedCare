import { useEffect, useState } from "react";
import { getUserRole, signIn as apiSignIn, logout as apiLogout} from "../../services/Auth/auth";
import { AuthContext } from "./AuthContext";
import { useNavigate } from "react-router-dom";

export const AuthProvider = ({ children }) => {
    const [currUser, setCurrUser] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        getUserRole()
            .then((role) => 
            {
                setCurrUser(role)
                console.log("Роль пользователя ", role);
            })
    }, []);

    const signIn = async (login, password) =>
    {
        const _ = await apiSignIn(login, password);
        const currUser = await getUserRole();
        setCurrUser(currUser);
    }

    const logout = () => {
        apiLogout();
        setCurrUser(null);
        navigate("/"); // на главную после выхода 
    }

    return (
        <AuthContext.Provider value={{currUser, signIn, logout}}>
            {children}
        </AuthContext.Provider>
    );
}

export default AuthProvider;