import { useContext, useEffect, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';
import { Link } from "react-router-dom";
import Appointment from "../Items/Appointment";
import { GetAllForPatient } from "../../services/appointments.js";
import { AppointmentFilter, FilterAppoinements } from '../../utils/filters.js';

const PatientDashboard = () => {
    const { currUser } = useContext(AuthContext);
    const [appointments, setAppointments] = useState([]);
    const [statusFilter, setStatusFilter] = useState(AppointmentFilter.All);
    const [selectedDate, setSelectedDate] = useState("");

    useEffect(() => {
        const fetchAppointments = async () => {
            const appointments = await GetAllForPatient(currUser.id);
            setAppointments(appointments);
        };

        fetchAppointments();
    }, [currUser.id]);

    const filteredAppointments = FilterAppoinements(appointments, statusFilter, selectedDate);

    return (
        <div className="mt-15">
            <div className="bg-gray-50 min-h-screen flex flex-col">
            <header className="bg-emerald-600 text-white py-8 text-center">
                <h1 className="text-4xl font-bold">
                    Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!
                </h1>
                <p className="mt-2 text-lg">Ваше здоровье — наша забота</p>
            </header>

            <section className="px-6 py-12">
                <div className="max-w-7xl mx-auto text-center">
                <h2 className="text-3xl font-semibold text-gray-800 text-left">Запись на прием</h2>
                <p className="mt-4 text-lg text-gray-600 text-left">
                    Вы можете{" "}
                    <Link to="/appointment" className="text-green-600 font-semibold hover:underline">
                        записаться
                    </Link>{" "}
                        на прием к специалистам в удобное для вас время.
                </p>
                </div>
            </section>

            <section className="px-6 py-12 bg-white">
                <div className="max-w-7xl mx-auto">
                    <h2 className="text-3xl font-semibold text-gray-800 text-center">Медицинская история</h2>
                    <p className="mt-4 text-lg text-gray-600 text-center">
                        Ознакомьтесь с вашей медицинской историей, информацией о прошедших и предстоящих приемах.
                    </p>

                    <div className="flex justify-center gap-4 mt-6">
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
                            onClick={() => {
                                setStatusFilter(AppointmentFilter.Confirmed);
                                setSelectedDate("");
                            }} 
                            className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.Confirmed ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}>
                                Предстоящие
                        </button>
                        <button 
                            onClick={() => {
                                setStatusFilter(AppointmentFilter.Completed);
                                setSelectedDate("");
                            }} 
                            className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.Completed ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}>
                                Прошедшие
                        </button>
                        <button 
                            onClick={() => {
                                setStatusFilter(AppointmentFilter.All);
                                setSelectedDate("");
                            }}
                            className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.All ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}>
                                Все
                        </button>
                    </div>

                    <div className="mt-8 space-y-6">
                        {filteredAppointments && filteredAppointments.length > 0 ? (
                            filteredAppointments.map((appointment) => (
                                <Appointment key={appointment.id} appointment={appointment} />
                        ))
                        ) : (
                        <div
                            className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition"
                        >
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

export default PatientDashboard;
