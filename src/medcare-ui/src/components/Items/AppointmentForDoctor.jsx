import { useNavigate } from 'react-router-dom';
import { CompleteAppointment } from '../../services/appointments';
import { formatDate, formatFullDateRuLocale } from '../../utils/date';
import { genderToString } from '../../utils/toString';

export default function AppointmentForDoctor({ appointment, onComplete }) {
    const navigate = useNavigate();
    
    const AppointmentStatuses = Object.freeze({
        Completed: "Completed"
    });

    return (
        <div
            key={appointment.id}
            className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition flex flex-col space-y-6 text-left"
        >
            <div className="flex justify-between flex-wrap gap-6 text-left">
                <div className="flex-1 min-w-[260px]">
                    <h4 className="text-lg font-semibold text-gray-700 mb-2">Информация о приеме</h4>
                    <p><strong>Дата и время:</strong> {formatDate(appointment.visitDate)}</p>
                    <p><strong>Услуга:</strong> {appointment.service.name}</p>
                </div>

                <div className="flex-1 min-w-[260px]">
                    <h4 className="text-lg font-semibold text-gray-700 mb-2">Пациент</h4>
                    <p><strong>ФИО:</strong> {appointment.patient.lastName} {appointment.patient.firstName} {appointment.patient.patronymic}</p>
                    <p><strong>Дата рождения:</strong> {formatFullDateRuLocale(appointment.patient.birthDate)}</p>
                    <p><strong>Пол:</strong> {genderToString(appointment.patient.gender)}</p>
                    <p><strong>Email:</strong> {appointment.patient.email}</p>
                    <p><strong>Телефон:</strong> {appointment.patient.phoneNumber}</p>

                    <button className="mt-4 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 transition"
                        onClick={() => navigate(`/med-card/${appointment.patient.id}`, {
                            state: {appointmentId: appointment.id}
                        })}
                    >
                        Мед карта пациента
                    </button>
                </div>
            </div>

            <div className="pt-4 border-t border-gray-200 flex justify-end">
                {appointment.appointmentStatus != AppointmentStatuses.Completed ? (
                    <button className="px-6 py-2 bg-green-600 text-white rounded hover:bg-green-700 transition"
                        onClick={async () => {
                            await CompleteAppointment(appointment.id);
                            onComplete();
                        }}
                    >
                        Закончить приём
                    </button>
                )
                : (
                    <div className="mt-4 text-base text-gray-600 italic">
                        Прием закончен
                    </div>
                )}
            </div>
        </div>
    );
}
