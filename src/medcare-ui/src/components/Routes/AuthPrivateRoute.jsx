import { useContext } from "react";
import { AuthContext } from "../Auth/AuthContext";
import { Navigate } from "react-router-dom";

export default function AuthPrivateRoute({ children, allowedRoles }) {
    const { currUser, loading } = useContext(AuthContext);
    
    if (loading) {
        return null; // ждем пока загрузится пользователь
    }

    // в dashboard если есть роли, иначе на страницу со входом
    // if (!currUser) {
    //     return <Navigate to="/sign-in"/>
    // }

    if (!currUser) {
        return null; // если пользователя нету - ничего не рендерим
    }
    if (!allowedRoles.includes(currUser.userRole)) {
        // const roles = allowedRoles.join(",");
        // console.warn(currUser.userRole, `ANOTHER: ${roles}`);
        // console.log("Тип userRole", typeof userRole);
        return <Navigate to="/forbidden"/>
    }

    // доступ получен
    return children;
}