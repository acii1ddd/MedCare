import { useEffect, useState } from "react";
import Doctor from "../Items/Doctor";
import { GetDoctorsByBranch } from '../../services/doctors';
import { useNavigate } from "react-router-dom";

export default function DoctorList({ branchName }) {
    
    // состояние для списка врачей
    const [doctors, setDoctors] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchDoctors = async () => {
            const doctorsWithImages = await GetDoctorsByBranch(branchName);
            setDoctors(doctorsWithImages);   // компонент DoctorList перерендеривается
        };

        fetchDoctors();

    }, [branchName]); // зависим от branchName

    const handleDoctorClick = (id) => {
        navigate(`/doctors/info/${id}`);
    };

    return (    
        <div className="doctor-list">
            <p className="text-3xl font-semibold mb-4">Cпециалисты</p>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
                {
                    doctors.map((doctor) => {
                        return <Doctor key={doctor.id} doctor={doctor} onClick={handleDoctorClick}/>;
                    })
                }
            </div>
        </div>
    );
}