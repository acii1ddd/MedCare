import { useEffect, useState } from "react";
import Doctor from "./Doctor";

export default function DoctorList() {
    
    // Состояние для списка врачей
    const [doctors, setDoctors] = useState([]);

    // const [loading, setLoading] = useState(true);

    useEffect(() => {

        // ВЫНЕСТИ В ДРУГОЕ МЕСТО
        const fetchDoctors = async () => {
            try {
                const branchName = "МЦ \"Свагушка\" в Гомеле";
                const response = await fetch(`https://localhost:7009/api/doctors/${branchName}`);
                const data = await response.json();

                const doctorsWithImages = data.map(doctor => {
                    let imageStartPart = "data:image/png;charset=utf-8;base64, "        
                    doctor.image = imageStartPart + doctor.image;
                    return doctor;
                });

                setDoctors(doctorsWithImages);   // компонент DoctorList перерендеривается
            } catch (error) {
                console.error("Ошибка при загрузке врачей:", error);
            }
            // finally {
            //     setLoading(false);  // Завершаем индикатор загрузки
            // }
        };

        fetchDoctors();

    }, []); // Пустой массив в зависимости, чтобы запрос выполнялся только один раз (нет тригера на хук)

    // if (loading) {
    //     return <p>Загрузка...</p>;  // Пока врачи загружаются, показываем сообщение
    //   }

    return (
        <div className="doctor-list">
            <h1 className="text-3xl font-bold mb-4">Наши врачи</h1>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
                {
                    doctors.map((doctor) => {
                        return <Doctor key={doctor.id} doctor={doctor}/>;
                    })
                }
            </div>
        </div>
    );
}