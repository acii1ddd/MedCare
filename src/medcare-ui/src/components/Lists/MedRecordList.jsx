import { useEffect, useState } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { GetById } from "../../services/patients";
import { GetAllByPatient } from "../../services/medicalRecords";
import MedicalRecord from "../Items/MedicalRecord";

export default function MedRecordList() {
    const { id } = useParams();
    const [selectedPatient, setSelectedPatient] = useState(null);
    const [medicalRecords, setMedicalRecords] = useState(null);
    
    const location = useLocation();
    const currAppointmentId = location.state?.appointmentId;

    const navigate = useNavigate();

    useEffect(() => {
        if (!id) return;

        const fetchPatient = async () => {
            const patient = await GetById(id);
            setSelectedPatient(patient);
        };
        
        fetchPatient();
    }, [id]);

    useEffect(() => {
        const fetchMedicalRecords = async () => {
            const records = await GetAllByPatient(id);
            setMedicalRecords(records);
        };

        fetchMedicalRecords();
    }, [id]);

    return (
        <div className="p-6 mt-15">
            <div className="mb-6 flex justify-between items-center">
                <div>
                    <h1 className="text-2xl font-bold text-gray-800 mb-5">Медицинская карта пациента</h1>
                    {selectedPatient && (
                        <p className="text-4xl font-bold text-gray-800 mb-1">
                            {selectedPatient.lastName} {selectedPatient.firstName} {selectedPatient.patronymic}
                        </p>
                    )}
                </div>
                <button
                    type="submit"
                    className="bg-blue-500 text-white p-2 rounded-md hover:bg-blue-600"
                    onClick={() => {
                        navigate(`/med-card/${id}/add-record`, {
                            state: {appointmentId: currAppointmentId}
                        });
                    }}
                >
                    Добавить запись
                </button>
            </div>

            {medicalRecords && medicalRecords.length > 0 ? (
                <div className="grid gap-6 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-2">
                    {medicalRecords.map((record) => (
                        <MedicalRecord key={record.id} record={record} />
                    ))}
                </div>
            ) : (
                <div className="p-6 bg-gray-50 rounded-lg shadow hover:shadow-md transition">
                    <p className="text-center text-xl font-semibold">Нет записей</p>
                </div>
            )}
        </div>
    );
}
