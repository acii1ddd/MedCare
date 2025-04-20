import { useContext, useEffect, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from '../Layout/Footer';
import { Link } from "react-router-dom";
import Appointment from "../Items/Appointment";
import { GetAllForPatient } from "../../services/appointments.js";
import { AppointmentFilter, FilterAppoinements } from '../../utils/filters.js';

const ReceptionistDashboard = () => {
    const { currUser } = useContext(AuthContext);
    const [appointments, setAppointments] = useState([]);
    const [statusFilter, setStatusFilter] = useState(AppointmentFilter.All);
    // const [selectedDate, setSelectedDate] = useState("");

    useEffect(() => {
        const fetchAppointments = async () => {
            const appointments = await GetAllForPatient(currUser.id);
            setAppointments(appointments);
        };

        fetchAppointments();
    }, [currUser.id]);

    const filteredAppointments = FilterAppoinements(appointments, statusFilter, new Date().toLocaleDateString("sv-SE"));

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
                    <h2 className="text-left text-3xl font-semibold text-gray-800 text-center">Неоплаченные записи</h2>

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

export default ReceptionistDashboard;
