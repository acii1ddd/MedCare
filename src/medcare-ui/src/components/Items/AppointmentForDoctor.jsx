export default function AppointmentForDoctor({ appointment }) {
    const formatDate = (isoDate) => {
        return new Date(isoDate).toLocaleString('ru-RU', {
            day: '2-digit',
            month: 'long',
            year: 'numeric',
            hour: '2-digit',
            minute: '2-digit',
        });
    };

    const formatBirthDate = (isoDate) => {
        return new Date(isoDate).toLocaleDateString('ru-RU', {
            day: '2-digit',
            month: 'long',
            year: 'numeric',
        });
    };

    const genderToString = (gender) => {
        if (gender === 0) return "Мужской";
        if (gender === 1) return "Женский";
        return "Неизвестно";
    };

    return (
        <div
            key={appointment.id}
            className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition flex flex-col space-y-6 text-left"
        >
            {/* Верхняя часть: визит слева, пациент справа */}
            <div className="flex justify-between flex-wrap gap-6 text-left">
                {/* Левая колонка — информация о приеме */}
                <div className="flex-1 min-w-[260px]">
                    <h4 className="text-lg font-semibold text-gray-700 mb-2">Информация о приеме</h4>
                    <p><strong>Дата и время:</strong> {formatDate(appointment.visitDate)}</p>
                    <p><strong>Услуга:</strong> {appointment.service.name}</p>
                </div>

                <div className="flex-1 min-w-[260px]">
                    <h4 className="text-lg font-semibold text-gray-700 mb-2">Пациент</h4>
                    <p><strong>ФИО:</strong> {appointment.patient.lastName} {appointment.patient.firstName} {appointment.patient.patronymic}</p>
                    <p><strong>Дата рождения:</strong> {formatBirthDate(appointment.patient.birthDate)}</p>
                    <p><strong>Пол:</strong> {genderToString(appointment.patient.gender)}</p>
                    <p><strong>Email:</strong> {appointment.patient.email}</p>
                    <p><strong>Телефон:</strong> {appointment.patient.phoneNumber}</p>

                    {/* Переход на мед карту пациента */}
                    <button className="mt-4 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 transition">
                        Подробнее
                    </button>
                </div>
            </div>

            {/* Поменять статус приема на "Completed" */}
            <div className="pt-4 border-t border-gray-200 flex justify-end">
                <button className="px-6 py-2 bg-green-600 text-white rounded hover:bg-green-700 transition">
                    Закончить приём
                </button>
            </div>
        </div>
    );
}
