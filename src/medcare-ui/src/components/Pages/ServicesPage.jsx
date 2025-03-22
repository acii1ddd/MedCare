import { useState } from "react";
import BranchSelection from "../BranchSelection";
import SpecializationList from "../SpecializationList";

export default function ServicesPage() {
    const [selectedBranch, setSelectedBranch] = useState(null);
    
    return (
        <div className="bg-gray-50 mt-15 p-5 flex flex-row gap-20 rounded-lg">
            <BranchSelection
                selectedBranch={selectedBranch}
                setSelectedBranch={setSelectedBranch}
            />
            <div>
                {selectedBranch ? (
                    /* Отображение услуг выбранного филиала */
                    <SpecializationList branchId={selectedBranch.id}/>

                    // <ServiceList branchName={selectedBranch.name}/>
                ) : 
                ( 
                    <p>Выберите филиал</p>
                )}
            </div>
        </div>
    );
}