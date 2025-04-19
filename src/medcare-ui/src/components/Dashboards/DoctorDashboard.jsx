import { useCallback, useContext, useEffect, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from "../Layout/Footer";
import AppointmentForDoctor from "../Items/AppointmentForDoctor";
import { GetAllForDoctor } from '../../services/appointments';
import { AppointmentFilter, FilterAppoinements } from '../../utils/filters';

const DoctorDashboard = () => {
  const { currUser } = useContext(AuthContext);
  const [selectedDate, setSelectedDate] = useState(new Date().toLocaleDateString("sv-SE"));
  const [appointments, setAppointments] = useState([]);
  const [statusFilter, setStatusFilter] = useState(AppointmentFilter.Date);

  const fetchAppointments = useCallback(async () => {
    const appointments = await GetAllForDoctor(currUser.id);
    setAppointments(appointments);
  }, [currUser.id]);
  
  useEffect(() => {
    fetchAppointments();
  }, [fetchAppointments]);

  const handleTodayFilter = () => {
    const today = new Date().toLocaleDateString("sv-SE");
    setStatusFilter(AppointmentFilter.Date);
    setSelectedDate(today);
  };

  const filteredAppointments = FilterAppoinements(appointments, statusFilter, selectedDate);

  return (
    <div className="mt-15 bg-gray-50 min-h-screen flex flex-col">
      <header className="bg-emerald-600 text-white py-8 text-center">
        <h1 className="text-4xl font-bold">
          Добро пожаловать, {currUser.firstName} {currUser.lastName} {currUser.patronymic}!
        </h1>
      </header>

      <section className="px-6 py-12 bg-white">
        <div className="max-w-7xl mx-auto">
          <h2 className="text-3xl font-semibold text-gray-800 text-center">Записи на прием</h2>
          <p className="mt-4 text-lg text-gray-600 text-center">
            Просмотривайте записи к себе на приём, а также информацию о пациенте.
          </p>

          <div className="flex justify-center items-center gap-4 mt-6 flex-wrap">
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
              onClick={handleTodayFilter}
              >
                Сегодня
            </button>
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
                  setStatusFilter(AppointmentFilter.All)
                  setSelectedDate("");
                }}
                className={`px-6 py-3 rounded-md text-lg font-medium ${statusFilter === AppointmentFilter.All ? "bg-emerald-600 text-white" : "bg-gray-200 text-gray-400 hover:bg-gray-300"}`}>
                    Все
            </button>
          </div>

          <div className="mt-8 space-y-6">
            {filteredAppointments.length > 0 ? (
              filteredAppointments.map((appointment) => (
                <AppointmentForDoctor key={appointment.id} appointment={appointment} onComplete={fetchAppointments} />
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
  );
};

export default DoctorDashboard;
