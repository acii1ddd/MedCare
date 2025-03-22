import { useEffect, useState } from "react";
import Specialization from "./Specialization";
import GetSpecializationsForBranch from '../services/specializations';

export default function SpecializationList({ branchId }) {
    
    // Состояние для списка специализаций
    const [specializations, setSpecializations] = useState([]);

    useEffect(() => {
        const fetchSpecializationForBranch = async () => {
            // setSpecializations([]);
            const specializations = await GetSpecializationsForBranch(branchId);
            setSpecializations(specializations);   // компонент SpecialozationList перерендеривается
        };

        fetchSpecializationForBranch();

    }, [branchId]); // зависим от branchId

    return (
        <div className="specialization-list">
            <p className="text-3xl font-semibold mb-4">Направления</p>
            <div className="grid grid-cols-1 grid-rows-1 gap-4">
                {specializations.length ? (
                    specializations.map((specialization) => {
                        return <Specialization key={specialization.id} specialization={specialization} />;
                    })
                ) : (
                    <p>Загрузка специализаций...</p>
                )}
            </div>
        </div>
    );
}