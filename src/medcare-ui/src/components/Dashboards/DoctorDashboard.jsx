import { useContext, useState } from "react";
import { AuthContext } from "../Auth/AuthContext";
import Footer from "../Layout/Footer";
import { Link } from "react-router-dom";
import AppointmentForDoctor from "../Items/AppointmentForDoctor";

const DoctorDashboard = () => {
  const { currUser } = useContext(AuthContext);
  const [selectedDate, setSelectedDate] = useState("");

  const appointments = [
    {
      id: "6fdef70d-0671-495b-a567-e9379aac52ed",
      visitDate: "2025-05-08T07:30:00Z",
      appointmentStatus: "Confirmed",
      paymentStatus: "Unpaid",
      note: "doctor",
      createdAt: "2025-04-15T09:14:48.341006Z",
      doctor: {
        id: "6e8a54d3-cb13-4066-b751-6da8421c35e0",
        firstName: "Екатерина",
        lastName: "Сидорова",
        patronymic: "Владимировна",
        specializationName: "Кардиология",
      },
      service: {
        id: "b014aac3-711b-4766-81ed-d32db438e62e",
        name: "Консультация врача-кардиолога второй квалификационной категории",
        price: 34,
      },
      patient: {
        firstName: "Дмитрий",
        lastName: "Сидоров",
        patronymic: "Андреевич",
        birthDate: "1995-07-29T21:00:00Z",
        gender: 0,
        email: "sidorov@gmail.com",
        phoneNumber: "+375447890123",
      },
      medicalRecords: [],
    },
    {
      id: "9a8725d4-8f4c-499e-8ee3-d7626d1679ad",
      visitDate: "2025-05-12T10:00:00Z",
      appointmentStatus: "Pending",
      paymentStatus: "Unpaid",
      note: "на консультацию",
      createdAt: "2025-04-16T11:12:48.000000Z",
      doctor: {
        id: "bd1e537a-d364-44e2-aaa5-2e22cc8c2175",
        firstName: "Иван",
        lastName: "Петров",
        patronymic: "Сергеевич",
        specializationName: "Дерматология",
      },
      service: {
        id: "d08a4219-8c65-469f-a24c-27f50a449f91",
        name: "Первичный прием дерматолога",
        price: 25,
      },
      patient: {
        firstName: "Мария",
        lastName: "Иванова",
        patronymic: "Павловна",
        birthDate: "1990-11-15T00:00:00Z",
        gender: 1,
        email: "m.ivanova@example.com",
        phoneNumber: "+375292223344",
      },
      medicalRecords: [],
    },
  ];

  const handleTodayFilter = () => {
    const today = new Date().toISOString().split("T")[0];
    setSelectedDate(today);
  };

  const filteredAppointments = appointments.filter((appointment) => {
    if (!selectedDate) return true;

    const visitDate = new Date(appointment.visitDate).toISOString().split("T")[0];
    return visitDate === selectedDate;
  });

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
              onChange={(e) => setSelectedDate(e.target.value)}
              className="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-lg"
            />
            <button
              onClick={handleTodayFilter}
              className="px-6 py-2 bg-emerald-600 text-white rounded-md text-lg hover:bg-emerald-700 transition"
            >
              Сегодня
            </button>
            <button
              onClick={() => setSelectedDate("")}
              className="px-6 py-2 bg-emerald-600 text-white rounded-md text-lg hover:bg-emerald-700 transition"
            >
              Сбросить
            </button>
          </div>

          <div className="mt-8 space-y-6">
            {filteredAppointments.length > 0 ? (
              filteredAppointments.map((appointment) => (
                <AppointmentForDoctor key={appointment.id} appointment={appointment} />
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
