import { useContext } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';
import { Link } from "react-router-dom";

const PatientDashboard = () => {
    const { currUser } = useContext(AuthContext);

    return (
      <div className="mt-15">
        <div className="bg-gray-50 min-h-screen flex flex-col">
            <header className="bg-green-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!</h1>
                {/* <h2 className="text-2xl font-bold">Ваша роль: {currUser.userRole}</h2> */}
                <p className="mt-2 text-lg">Ваше здоровье — наша забота</p>
            </header>

            <section className="px-6 py-12 bg-white">
                <div className="max-w-7xl mx-auto text-center">
                    <h2 className="text-3xl font-semibold text-gray-800">Запись на прием</h2>
                    <p className="mt-4 text-lg text-gray-600">
                        Вы можете <Link to="/appointment" className="text-green-600 font-semibold hover:underline">записаться</Link> на прием к специалистам в удобное для вас время.
                    </p>
                    <div className="mt-8 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
                        <div className="bg-green-50 p-6 rounded-lg shadow-lg">
                            <h3 className="text-xl font-semibold text-green-600">Мои приемы</h3>
                            <p className="mt-2 text-gray-600">
                                Ознакомьтесь с вашими прошлыми и будущими записями на прием.
                            </p>
                            <button className="mt-4 bg-green-600 text-white px-4 py-2 rounded-lg">Ознакомиться</button>
                        </div>
                    </div>
                </div>
            </section>

            {/* Medical History */}
            <section className="px-6 py-12 bg-white">
                <div className="max-w-7xl mx-auto text-center">
                    <h2 className="text-3xl font-semibold text-gray-800">Медицинская карта</h2>
                    <p className="mt-4 text-lg text-gray-600">
                        Ознакомьтесь с вашей медицинской историей и записями о визитах к врачам.
                    </p>
                    <div className="mt-6 space-y-4">
                        <div className="flex justify-between items-center p-6 bg-gray-50 rounded-lg shadow-lg">
                            <span className="text-lg font-semibold text-gray-700">Последний визит</span>
                            <span className="text-gray-600">20 марта 2025, Терапевт</span>
                        </div>
                        <div className="flex justify-between items-center p-6 bg-gray-50 rounded-lg shadow-lg">
                            <span className="text-lg font-semibold text-gray-700">Диагноз</span>
                            <span className="text-gray-600">Гипертония</span>
                        </div>
                        <Link to="/contacts" className="block mt-4 bg-green-600 text-white px-4 py-2 rounded-lg w-max mx-auto">
                            Подробнее
                        </Link>
                    </div>
                </div>
            </section>
            <Footer/>
        </div>
      </div>
    );
}

export default PatientDashboard;
