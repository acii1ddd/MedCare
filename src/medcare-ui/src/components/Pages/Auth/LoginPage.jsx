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
        <div className="flex justify-center items-start min-h-[830px] bg-[oklch(97%_0.001_106.424)] pt-40 mt-15 rounded-lg">
            <form 
                onSubmit={handleSubmit} 
                className="bg-white p-8 rounded-xl shadow-md w-full max-w-md space-y-6"
            >
                <h2 className="text-3xl font-semibold text-center text-emerald-600">
                    Вход в систему
                </h2>

                <div>
                    <label className="text-left text-lg block mb-1 text-gray-700">Логин</label>
                    <input
                        type="text"
                        placeholder="Введите логин"
                        value={userLogin}
                        onChange={(e) => setUserLogin(e.target.value)}
                        className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-emerald-400 text-lg"
                        required
                    />
                </div>

                <div>
                    <label className="text-left text-lg block mb-1 text-gray-700">Пароль</label>
                    <input
                        type="password"
                        placeholder="Введите пароль"
                        value={userPassword}
                        onChange={(e) => setUserPassword(e.target.value)}
                        className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-emerald-400 text-lg"
                        required
                    />
                </div>

                <button
                    type="submit"
                    className="w-full bg-emerald-600 hover:bg-emerald-700 text-white py-3 rounded-md text-lg font-medium transition duration-300"
                >
                    Войти
                </button>
            </form>
        </div>
    );
}