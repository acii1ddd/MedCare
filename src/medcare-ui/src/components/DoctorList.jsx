import { useEffect, useState } from "react";
import Doctor from "./Doctor";
import GetDoctorsByBranch from '../services/doctors';

export default function DoctorList({ branchName }) {
    
    // Состояние для списка врачей
    const [doctors, setDoctors] = useState([]);

    useEffect(() => {
        const fetchDoctors = async () => {
            const doctorsWithImages = await GetDoctorsByBranch(branchName);
            setDoctors(doctorsWithImages);   // компонент DoctorList перерендеривается
        };

        fetchDoctors();

    }, [branchName]); // зависим от branchName

    return (
        <div className="doctor-list">
            <p className="text-4xl font-semibold mb-4">Cпециалисты:</p>
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