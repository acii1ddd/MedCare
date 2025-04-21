import { useCallback, useContext, useEffect, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';
import { Link } from "react-router-dom";
import AppointmentForReceptionist from "../Items/AppointmentForReceptionist";
import { AppointmentFilter, FilterAppoinements } from '../../utils/filters.js';
import { GetAll, MarkAsPaid } from "../../services/appointments.js";

const ReceptionistDashboard = () => {
    const { currUser } = useContext(AuthContext);
    const [appointments, setAppointments] = useState([]);
    const [statusFilter, setStatusFilter] = useState(AppointmentFilter.Date);
    const [selectedDate, setSelectedDate] = useState(new Date().toLocaleDateString("sv-SE"));

    const fetchAppointments = useCallback(async () => {
        const appointments = await GetAll();
        setAppointments(appointments);
    }, []);

    useEffect(() => {
        fetchAppointments();
    }, [fetchAppointments]);

    const filteredAppointments = FilterAppoinements(appointments, statusFilter, selectedDate);

    const markAsPaidClickHandler = async (id) => {
        if(await MarkAsPaid(id)) {
            alert("Прием оплачен");
            fetchAppointments();
        } else {
            console.warn("Ошибка при оплате приема");
        }
    };

    return (
        <div className="mt-15">
            <div className="bg-gray-50 min-h-screen flex flex-col">
            <header className="bg-emerald-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">
                    Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!
                </h1>
            </header>

            <section className="px-6 pt-12">
              <div className="max-w-7xl mx-auto text-center">
                <h2 className="text-3xl font-semibold text-gray-800 text-left">Регистратура</h2>
                <p className="text-lg text-gray-600 text-left">
                  Здесь вы можете добавлять новых пациентов, просматривать неоплаченные приемы, 
                  а также отмечать факты оплаты. Вся информация будет автоматически отражена в системе.
                </p>
              </div>
            </section>

            <section className="px-6 pt-8 bg-white mt-5">
              <div className="max-w-7xl mx-auto flex items-center justify-between">
                    <h2 className="text-3xl font-semibold text-gray-800">Пациенты</h2>
                    <Link
                        to="/add-patient"
                        className="inline-block bg-emerald-600 hover:bg-emerald-700 text-white text-lg font-medium py-2 px-4 rounded-lg transition duration-200"
                    >
                        Добавить пациента
                    </Link>
                </div>
            </section>

            <section className="px-6 py-15 bg-white">
    
                <div className="max-w-7xl mx-auto">
                    <div className="flex flex-wrap md:flex-nowrap justify-between items-center gap-4">
                        <h2 className="text-3xl font-semibold text-gray-800">
                            Записи на прием
                        </h2>

                        <div className="flex justify-center items-center gap-4 mt-2 flex-wrap">
                            <input
                                type="date"
                                value={selectedDate}
                                onChange={(e) => {
                                    setSelectedDate(e.target.value);
                                    setStatusFilter(AppointmentFilter.Date);
                                }}
                                className="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-lg"
                            />
                            <button
                                className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.Date && selectedDate === new Date().toLocaleDateString("sv-SE") ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}
                                onClick={() => {
                                    setStatusFilter(AppointmentFilter.Date);
                                    setSelectedDate(new Date().toLocaleDateString("sv-SE"));
                                }}
                            >
                                Все на сегодня
                            </button>
                            <button 
                                onClick={() => {
                                    setStatusFilter(AppointmentFilter.Unpaid);
                                    setSelectedDate("");
                                }} 
                                className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.Unpaid ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}
                            >
                                Пройден и неоплачен
                            </button>
                            <button
                                onClick={() => {
                                    setStatusFilter(AppointmentFilter.Confirmed);
                                    setSelectedDate("");
                                }}
                                className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.Confirmed ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}
                            >
                                Предстоящие
                            </button>
                            <button 
                                onClick={() => {
                                    setStatusFilter(AppointmentFilter.All);
                                    setSelectedDate("");
                                }}
                                className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.All ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}
                            >
                                Все
                            </button>
                        </div>
                    </div>

                    <div className="mt-8 space-y-6">
                        {filteredAppointments && filteredAppointments.length > 0 ? (
                            filteredAppointments.map((appointment) => (
                                <AppointmentForReceptionist key={appointment.id} appointment={appointment} onMarkAsPaidClick={markAsPaidClickHandler}/>
                            ))
                        ) : (
                            <div className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition">
                                <p className="text-center text-xl font-semibold">Нет данных о приёмах</p>
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

export default ReceptionistDashboard;
