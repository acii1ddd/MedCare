import { useContext, useEffect, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';
import { Link } from "react-router-dom";
import Worker from "../Items/Worker.jsx";
import { GetAll } from "../../services/users/workers.js";

const DirectorDashboard = () => {
    const { currUser } = useContext(AuthContext);
    const [workers, setWorkers] = useState([]);

    useEffect(() => {
        const fetchWorkers = async () => {
            const workers = await GetAll(currUser.id);
            setWorkers(workers);
        };

        fetchWorkers();
    }, [currUser.id]);

    const deleteClickHandler = async (id) => {
      alert("Сотрудник успешно удален");
      //await Delete(id);
    };

    return (
        <div className="mt-15">
            <div className="bg-gray-50 min-h-screen flex flex-col">
            <header className="bg-emerald-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">
                    Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!
                </h1>
            </header>

            <section className="px-6 pt-12 pb-3">
              <div className="max-w-7xl mx-auto text-center">
                <h2 className="text-3xl font-semibold text-gray-800 text-left">Управление мед центром</h2>
                <p className="text-lg text-gray-600 text-left">
                  Здесь вы можете управлять сотрудниками медицинского центра.
                </p>
              </div>
            </section>

            <section className="px-6 py-3 bg-white">
                <div className="max-w-7xl mx-auto">
                    <div className="flex items-center justify-between flex-wrap gap-4 mb-6">
                      <h2 className="text-left text-3xl font-semibold text-gray-800 text-center">Сотрудники</h2>

                      <Link
                          to="/workers/add"
                          className="inline-block bg-emerald-600 hover:bg-emerald-700 text-white text-lg font-medium py-2 px-4 rounded-lg transition duration-200"
                      >
                          Добавить сотрудника
                      </Link>
                    </div>

                    <div className="mt-8 grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                        {workers && workers.length > 0 ? (
                            workers .map((worker) => (
                                <Worker key={worker.id} worker={worker} onDeleteClick={deleteClickHandler}/>
                        ))
                        ) : (
                        <div
                            className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition"
                        >
                            <p className="text-center text-xl font-semibold">Нет данных о сотрудниках</p>
                        </div>
                        )}
                    </div>
                </div>
            </section>
            
            <Footer />
            </div>
        </div>
    );
}

export default DirectorDashboard;
