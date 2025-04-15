export default function MedicalRecord({ medicalRecord }) {
    return (
        <>
            <li key={medicalRecord.id}
                className="border-l-4 border-green-500 pl-4 py-2 bg-white rounded shadow"
            >
                <p className="text-sm text-gray-700">
                    <strong>Диагноз:</strong> {medicalRecord.diagnosis}
                </p>
                <p className="text-sm text-gray-700">
                    <strong>Лечение:</strong> {medicalRecord.treatment}
                </p>
                <p className="text-sm text-gray-700">
                    <strong>Описание:</strong> {medicalRecord.description}
                </p>
            </li>
        </>
    );
}
