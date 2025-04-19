export default function MedicalRecord({ record }) {
    return (
        <div
            key={record.id}
            className="bg-white border border-gray-200 rounded-2xl shadow-md p-6 hover:shadow-lg transition-shadow duration-300"
        >
            <div className="mb-6">
                <p className="text-lg text-gray-500">Дата приёма</p>
                <h2 className="text-xl font-semibold text-blue-700">
                    {new Date(record.appointment.visitDate).toLocaleString()}
                </h2>
            </div>

            <div className="text-left grid grid-cols-1 gap-y-2 mb-6">
                <div>
                    <p className="text-lg text-gray-500">Диагноз</p>
                    <p className="text-xl font-semibold text-gray-800">{record.diagnosis}</p>
                </div>
                <div>
                    <p className="text-lg text-gray-500">Лечение</p>
                    <p className="text-xl font-semibold text-gray-800">{record.treatment}</p>
                </div>
                <div className="flex flex-col justify-between">
                    <p className="text-lg text-gray-500">Описание</p>
                    <p className="text-xl font-semibold text-gray-800">
                        {record.description && record.description.trim()
                        ? record.description
                        : "Нет описания"}
                </p>
                </div>
            </div>
                
            <div className="text-left grid grid-cols-2 border-t gap-6 pt-4">
                <div>
                    <p className="text-lg text-gray-500">Врач</p>
                    <p className="text-xl font-semibold text-gray-800">
                        {record.appointment.doctor.lastName} {record.appointment.doctor.firstName} {record.appointment.doctor.patronymic}
                    </p>
                    <p className="text-base text-gray-600">
                        {record.appointment.doctor.specializationName}
                    </p>
                </div>
                <div>
                    <p className="text-lg text-gray-500">Услуга</p>
                    <p className="text-xl font-semibold text-gray-800">
                        {record.appointment.service.name}
                    </p>
                </div>
            </div>
        </div>
    );
}
