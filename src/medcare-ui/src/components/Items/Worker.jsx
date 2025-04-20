import getRole from '../../utils/roles';

export default function Worker({ worker, onDeleteClick }) {
    
    const daysOfWeek = ['Воскресенье', 'Понедельник', 'Вторник', 'Среда', 'Четверг', 'Пятница', 'Суббота'];

    return (
        <div className="border border-gray-300 bg-white p-6 rounded-2xl shadow-lg max-w-md mx-auto transition hover:shadow-xl flex flex-col h-full">
            <div className="mb-6 w-full h-64 overflow-hidden rounded-lg border">
                {worker.image && worker.image.length > 0 ? (
                    <img
                        src={`data:image/jpeg;base64, ${worker.image}`}
                        alt={`${worker.firstName} ${worker.lastName} ${worker.patronymic}`}
                        className="w-full h-full object-cover"
                    />
                ) : (
                    <div className="flex items-center justify-center w-full h-full bg-gray-100 text-gray-500 text-sm">
                        Изображение недоступно
                    </div>
                )}
            </div>

            <div className="text-left space-y-3 text-gray-800 flex-grow">
                <h2 className="text-2xl font-bold text-center">
                    {worker.lastName} {worker.firstName} {worker.patronymic}
                </h2>

                <div className="grid grid-cols-2 gap-x-4 gap-y-2 text-sm">
                    <p><span className="font-semibold">Дата рождения:</span> {new Date(worker.birthDate).toLocaleDateString()}</p>
                    <p><span className="font-semibold">Пол:</span> {worker.gender === 0 ? 'Мужской' : 'Женский'}</p>

                    <p><span className="font-semibold">Email:</span> {worker.email}</p>
                    <p><span className="font-semibold">Телефон:</span> {worker.phoneNumber}</p>

                    <p><span className="font-semibold">Должность:</span> {getRole(worker.role)}</p>
                    <p><span className="font-semibold">Специализация:</span> {worker.specializationName ?? '—'}</p>

                    <p><span className="font-semibold">Паспорт:</span> {worker.passportSeries} {worker.passportNumber}</p>

                    <div className="col-span-2">
                        <p className="font-semibold">Филиал:</p>
                        <p className="text-gray-700">{worker.branch.name}</p>
                        <p className="text-gray-700">{worker.branch.fullAddress}</p>
                    </div>
                </div>

                <div className="mt-4 min-h-[120px] flex flex-col justify-start">
                    <p className="font-semibold text-sm mb-1">График работы:</p>
                    {worker.schedules && worker.schedules.length > 0 ? (
                        <ul className="list-disc list-inside text-sm text-gray-700 space-y-1">
                            {worker.schedules
                                .sort((a, b) => a.dayOfWeek - b.dayOfWeek)
                                .map((schedule, index) => (
                                    <li key={index}>
                                        {daysOfWeek[schedule.dayOfWeek]}: {schedule.startTime} – {schedule.endTime}
                                    </li>
                                ))}
                        </ul>
                    ) : (
                        <p className="text-sm text-gray-500 italic">Нет информации о графике работы</p>
                    )}
                </div>
            </div>

            <button
                onClick={() => onDeleteClick(worker.id)}
                className="mt-6 bg-red-600 text-white w-full py-2 rounded-md hover:bg-red-700 transition"
            >
                Удалить
            </button>
        </div>
    );
}
