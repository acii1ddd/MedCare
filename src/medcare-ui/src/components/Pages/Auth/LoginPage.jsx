import { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../Auth/AuthContext";

export default function LoginPage() {
    const [userLogin, setUserLogin] = useState("");
    const [userPassword, setUserPassword] = useState("");
    const { signIn } = useContext(AuthContext); // деструктуризация <AuthContext.Provider value={{userRole, signIn, logout}}>
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault(); 
        try {
            await signIn(userLogin, userPassword);
            console.log("Авторизация успешно проведена");
            navigate("/dashboard");
        } catch (error) {
            alert(error.message);
            console.log("Ошибка при входе ", error);
        }
    }

    return (
        <form onSubmit={handleSubmit} className="mt-15">
            <input type="text" placeholder="Введите логин" value={userLogin} onChange={(e) => setUserLogin(e.target.value)}/> 
            <input type="text" placeholder="Введите пароль" value={userPassword} onChange={(e) => setUserPassword(e.target.value)}/>
            <button type="submit" className="text-white">Войти</button>
        </form>
    );
}