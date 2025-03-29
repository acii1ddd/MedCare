import { useEffect, useState } from "react";
import { getCurrUser, signIn as apiSignIn, logout as apiLogout} from "../../services/Auth/auth";
import { AuthContext } from "./AuthContext";
import { useNavigate } from "react-router-dom";

export const AuthProvider = ({ children }) => {
    const [currUser, setCurrUser] = useState(null);
    const [loading, setLoading] = useState(true);
    const navigate = useNavigate();

    useEffect(() => {
        getCurrUser()
            .then((currUser) => 
            {
                setCurrUser(currUser);
                // console.log("Ответ от API:", currUser);
                // console.log("Роль пользователя ", currUser.userRole);
            })
            .catch(() => {
                setCurrUser(null);
            })
            .finally(() => {
                setLoading(false); // завершаем загрузку
            });
    }, []);

    const signIn = async (login, password) =>
    {
        const _ = await apiSignIn(login, password);
        const currUser = await getCurrUser();
        setCurrUser(currUser);
    };

    const logout = () => {
        apiLogout();
        console.log("Выход из аккаунта выполнен успешно");
        setCurrUser(null);
        navigate("/"); // на главную после выхода
    };

    return (
        <AuthContext.Provider value={{currUser, loading, signIn, logout}}>
            {children}
        </AuthContext.Provider>
    );
}

export default AuthProvider;