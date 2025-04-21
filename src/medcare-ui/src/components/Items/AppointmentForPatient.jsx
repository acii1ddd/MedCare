import MedicalRecord from '../Items/MedicalRecord';
import { AppointmentFilter } from '../../utils/filters';

export default function AppointmentForPatient({ appointment }) {
    if (!appointment) {
        throw new Error("Параметр 'appointment' не определен");
    }
    
    console.log("appointment:", appointment);

    return (
        <div
            className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition"
        >
            <div className="flex justify-between items-center">
                <h3 className="text-xl font-semibold text-gray-700 text-left">
                    Прием: {new Date(appointment.visitDate).toLocaleString("ru-RU")}
                </h3>
                <span className="text-base text-gray-500 text-left">
                    Статус:{" "}
                    {
                        appointment.appointmentStatus === AppointmentFilter.Confirmed ? "Предстоит"
                        : appointment.appointmentStatus === AppointmentFilter.Completed ? "Пройден"
                        : "Неизвестно"
                    }
                </span>
            </div>

            <p className="mt-2 text-gray-600 text-left">
                Оплата: {appointment.paymentStatus === "Paid" ? "Оплачено" : "Не оплачено"}
            </p>

            <div className="mt-4 text-gray-700 text-left">
                <p>
                <strong>Врач:</strong> {appointment.doctor.lastName}{" "}
                    {appointment.doctor.firstName} {appointment.doctor.patronymic} ({appointment.doctor.specializationName})
                </p>
                <p>
                    <strong>Услуга:</strong> {appointment.service.name} – {appointment.service.price} BYN
                </p>
            </div>

            <div className="mt-4 text-left">
                <h4 className="text-lg font-semibold text-gray-700">Записи в медицинской карте:</h4>
                
                {appointment.medicalRecords.length === 0 ? (
                    <p className="text-gray-500 mt-2">Нет записей</p>
                ) : (
                    <ul className="mt-2 space-y-2">
                        {appointment.medicalRecords.map((record) => (
                            <MedicalRecord key={record.id} record={record} />
                        ))}
                    </ul>
                )}
            </div>
        </div>
    );
}
  