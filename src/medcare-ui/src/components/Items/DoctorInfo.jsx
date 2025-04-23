import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { GetById } from "../../services/doctors.js"

export default function DoctorInfo() {
    const { id } = useParams();
    const [doctor, setDoctor] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        if (!id) return;

        const fetchDoctor = async () => {
            const doctor = await GetById(id);
            setDoctor(doctor);
        };
        
        fetchDoctor();
    }, [id]);

    // const buttonClickHandle = (docotor) => { 
    const buttonClickHandle = () => {
        //alert(`Перейти в /appointment с выбранным доктором (${docotor.firstName})`);
        navigate("/appointment", {replace: true});
    };

    const DAYS_MAP = ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"];

    if (!doctor) return <p>Загрузка...</p> 

    return (
        <div className="max-w-5xl mt-15 mx-auto p-6 bg-white rounded-2xl shadow-lg flex flex-col md:flex-row gap-8 items-center md:items-start">
            <div className="w-full md:w-1/3 flex-shrink-0">
                {doctor.image ? (
                    <img 
                        src={doctor.image}
                        alt={`${doctor.firstName} ${doctor.lastName} ${doctor.patronymic}`}
                        className="w-full h-auto object-cover rounded-xl shadow-md"
                    />
                ) : (
                    <div className="w-full h-48 flex items-center justify-center bg-gray-100 rounded-xl text-gray-500">
                        Изображение не доступно
                    </div>
                )}
            </div>
            <div className="flex flex-col">
                <div className="flex flex-row">
                    <div className="w-full md:w-3/3">
                        <h2 className="text-3xl font-semibold mb-3 text-gray-800 text-left">
                            {doctor.firstName} {doctor.lastName} {doctor.patronymic}
                        </h2>

                        <div className="flex flex-col">
                            <p className="text-gray-600 text-lg text-left">
                                <span className="font-medium text-gray-700">Email:</span> {doctor.email}
                            </p>
                            <p className="text-gray-600 text-lg text-left">
                                <span className="font-medium text-gray-700">Телефон:</span> {doctor.phoneNumber}
                            </p>
                            <p className="text-gray-600 text-lg text-left">
                                <span className="font-medium text-gray-700">Специализация:</span> {doctor.specializationName}
                            </p>
                        </div>
                    </div>
            
                    {doctor.branch && (
                        <div className="mt-6 w-full">
                            <h3 className="font-medium text-lg">Филиал</h3>
                            <p className="text-lg text-gray-600">{doctor.branch.fullAddress}</p>

                            <button 
                                className="mt-6 bg-green-600 text-white px-6 py-3 rounded-xl hover:bg-green-700 transition-all duration-200 w-full md:w-auto"
                                    onClick={() => buttonClickHandle(doctor)}
                                >
                                    Записаться
                            </button>
                        </div>
                    )}
                </div>
        
                {doctor.schedules && doctor.schedules.length > 0 && (
                    <div className="mt-6 w-full text-left"> {/* Добавляем text-left здесь */}
                        <h3 className="font-medium text-lg">График работы</h3>
                        <ul className="text-lg list-disc list-inside">
                            {doctor.schedules
                                .sort((a, b) => a.dayOfWeek - b.dayOfWeek)
                                .map((daySchedule, idx) => (
                                <li key={idx}>
                                    {DAYS_MAP[daySchedule.dayOfWeek]}: {daySchedule.startTime} – {daySchedule.endTime}
                                </li>
                            ))}
                        </ul>
                    </div>
                )}
            </div>
        </div>
    );
}
