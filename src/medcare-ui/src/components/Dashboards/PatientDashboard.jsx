import { useContext } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';

const PatientDashboard = () => {
    const { currUser } = useContext(AuthContext);

    return (
      <div className="mt-15">
        <div className="bg-gray-50 min-h-screen flex flex-col">
            <header className="bg-green-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!</h1>
                <h2 className="text-2xl font-bold">Ваша роль: {currUser.userRole}</h2>
                <p className="mt-2 text-lg">Ваше здоровье — наша забота</p>
            </header>

            <section className="px-6 py-12 bg-white">
                <div className="max-w-7xl mx-auto text-center">
                    <h2 className="text-3xl font-semibold text-gray-800">Запись на прием</h2>
                    <p className="mt-4 text-lg text-gray-600">
                        Вы можете записаться на прием к специалистам в удобное для вас время.
                    </p>
                    <div className="mt-8 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
                        <div className="bg-green-50 p-6 rounded-lg shadow-lg">
                            <h3 className="text-xl font-semibold text-green-600">Кардиолог</h3>
                            <p className="mt-2 text-gray-600">
                                Запишитесь на консультацию к нашему опытному кардиологу.
                            </p>
                            <button className="mt-4 bg-green-600 text-white px-4 py-2 rounded-lg">Записаться</button>
                        </div>
                        <div className="bg-green-50 p-6 rounded-lg shadow-lg">
                            <h3 className="text-xl font-semibold text-green-600">Терапевт</h3>
                            <p className="mt-2 text-gray-600">
                                Проведите плановый осмотр и диагностику у нашего терапевта.
                            </p>
                            <button className="mt-4 bg-green-600 text-white px-4 py-2 rounded-lg">Записаться</button>
                        </div>
                        <div className="bg-green-50 p-6 rounded-lg shadow-lg">
                            <h3 className="text-xl font-semibold text-green-600">Офтальмолог</h3>
                            <p className="mt-2 text-gray-600">
                                Проверка зрения и консультация с офтальмологом.
                            </p>
                            <button className="mt-4 bg-green-600 text-white px-4 py-2 rounded-lg">Записаться</button>
                        </div>
                    </div>
                </div>
            </section>

            {/* Patient Info */}
            <section className="px-6 py-12 bg-gray-100">
                <div className="max-w-7xl mx-auto">
                    <h2 className="text-3xl font-semibold text-gray-800 text-center">Моя информация</h2>
                    <div className="mt-6 space-y-4">
                        <div className="flex justify-between items-center p-6 bg-white rounded-lg shadow-lg">
                            <span className="text-lg font-semibold text-gray-700">Дата рождения</span>
                            <span className="text-gray-600">1 января 1980</span>
                        </div>
                        <div className="flex justify-between items-center p-6 bg-white rounded-lg shadow-lg">
                            <span className="text-lg font-semibold text-gray-700">Полис</span>
                            <span className="text-gray-600">123456789012</span>
                        </div>
                        <div className="flex justify-between items-center p-6 bg-white rounded-lg shadow-lg">
                            <span className="text-lg font-semibold text-gray-700">Телефон</span>
                            <span className="text-gray-600">+1 234 567 890</span>
                        </div>
                    </div>
                </div>
            </section>

            {/* Medical History */}
            <section className="px-6 py-12 bg-white">
                <div className="max-w-7xl mx-auto text-center">
                    <h2 className="text-3xl font-semibold text-gray-800">Моя медицинская карта</h2>
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
                    </div>
                </div>
            </section>
            <Footer/>
        </div>
      </div>
    );
}

export default PatientDashboard;
