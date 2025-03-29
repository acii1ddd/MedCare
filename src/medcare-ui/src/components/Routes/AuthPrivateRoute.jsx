import { useContext } from "react";
import { AuthContext } from "../Auth/AuthContext";
import { Navigate } from "react-router-dom";

export default function AuthPrivateRoute({ children, allowedRoles }) {
    const { currUser } = useContext(AuthContext);
    
    // в dashboard если есть роли, иначе на страницу со входом
    if (!currUser) {
        return <Navigate to="/sign-in"/>
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