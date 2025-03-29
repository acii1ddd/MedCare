import { useContext } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';

const DirectorDashboard = () => {
    const { currUser } = useContext(AuthContext);

    return (
      <div className="mt-15">
        <div className="bg-gray-50 min-h-screen flex flex-col">
            <header className="bg-green-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!</h1>
                <h2 className="text-2xl font-bold">Ваша роль: {currUser.userRole}</h2>
                <p className="mt-2 text-lg">Ваше здоровье — наша забота</p>
            </header>
            <Footer/>
        </div>
      </div>
    );
}

export default DirectorDashboard;
