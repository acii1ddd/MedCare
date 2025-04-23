import { useContext, useEffect, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';
import { Link } from "react-router-dom";
import Worker from "../Items/Worker.jsx";
import { Delete, GetAll } from "../../services/users/workers.js";

const DirectorDashboard = () => {
    const { currUser } = useContext(AuthContext);
    const [workers, setWorkers] = useState([]);
    const [filteredWorkers, setFilteredWorkers] = useState([]);
    const [branchFilter, setBranchFilter] = useState("all");
    const [genderFilter, setGenderFilter] = useState("all");

    useEffect(() => {
        const fetchWorkers = async () => {
            const workers = await GetAll(currUser.id);
            setWorkers(workers);
        };

        fetchWorkers();
    }, [currUser.id]);

    useEffect(() => {
        // старые сотрудники
        let filtered = [...workers];
        if (branchFilter !== "all") {
            filtered = filtered.filter(w => w.branch.name === branchFilter);
        }
        if (genderFilter !== "all") {
            filtered = filtered.filter(w => w.gender === Number(genderFilter));
        }
        setFilteredWorkers(filtered);
    }, [workers, branchFilter, genderFilter]);

    const deleteClickHandler = async (id) => {
        const confirmed = confirm("Вы действительно хотите удалить данного сотрудника?");
        if (!confirmed) return;

        if (await Delete(id)) {
            setWorkers((prevWorkers) => prevWorkers.filter(x => x.id !== id));
        } else {
            console.log("Ошибка при удалении сотрудника");
        }
    };

    const uniqueBranchesNames = [...new Set(workers.map(w => w.branch.name))];

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
                    <div className="max-w-7xl mx-auto flex items-center justify-between">
                        <h2 className="text-3xl font-semibold text-gray-800">Статистика</h2>
                        <Link
                            to="/statistics"
                            className="inline-block bg-emerald-600 hover:bg-emerald-700 text-white text-lg font-medium py-2 px-4 rounded-lg transition duration-200"
                        >
                            Статистика
                        </Link>
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

                        <div className="flex gap-4 mb-6">
                            <div>
                                <label className="block mb-1 text-gray-700 font-medium">Филиал:</label>
                                <select
                                    value={branchFilter}
                                    onChange={(e) => setBranchFilter(e.target.value)}
                                    className="p-2 border rounded"
                                >
                                    <option value="all">Все</option>
                                    {uniqueBranchesNames.map(branchName => (
                                        <option key={branchName} value={branchName}>{branchName}</option>
                                    ))}
                                </select>
                            </div>

                            <div>
                                <label className="block mb-1 text-gray-700 font-medium">Пол:</label>
                                <select
                                    value={genderFilter}
                                    onChange={(e) => setGenderFilter(e.target.value)}
                                    className="p-2 border rounded"
                                >
                                    <option value="all">Все</option>
                                    <option value="0">Мужской</option>
                                    <option value="1">Женский</option>
                                </select>
                            </div>
                        </div>

                        <div className="mt-8 grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                            {filteredWorkers.length > 0 ? (
                                filteredWorkers.map((worker) => (
                                    <Worker key={worker.id} worker={worker} onDeleteClick={deleteClickHandler} />
                                ))
                            ) : (
                                <div className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition">
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
};

export default DirectorDashboard;
