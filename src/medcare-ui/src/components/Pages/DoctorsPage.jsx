import { useState } from "react";
import BranchSelection from "../BranchSelection";
import DoctorList from "../DoctorList";

export default function DoctorsPage() {
    const [selectedBranch, setSelectedBranch] = useState(null);
    
    return (
        <div className="bg-gray-50 p-5 mt-15 flex flex-row gap-20 rounded-lg">
            <BranchSelection
                selectedBranch={selectedBranch}
                setSelectedBranch={setSelectedBranch}
            />
            <div>
                {selectedBranch ? (
                    /* Отображение врачей выбранного филиала */
                    <DoctorList branchName={selectedBranch.name}/>
                ) : 
                ( 
                    <p>Выберите филиал</p>
                )}
            </div>
        </div>
    );
}