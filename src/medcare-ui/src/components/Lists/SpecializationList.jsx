import { useEffect, useState } from "react";
import Specialization from "../Items/Specialization";
import GetSpecializationsForBranch from '../../services/specializations';

export default function SpecializationList({ branchId }) {
    
    // Состояние для списка специализаций
    const [specializations, setSpecializations] = useState([]);

    useEffect(() => {
        const fetchSpecializationForBranch = async () => {
            const specializations = await GetSpecializationsForBranch(branchId);
            console.log("Specializations loaded", specializations);
            setSpecializations(specializations);   // компонент SpecialozationList перерендеривается
        };

        fetchSpecializationForBranch();

    }, [branchId]); // зависим от branchId

    return (
        <div className="specialization-list">
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