import { useEffect, useState } from "react";
import BranchSelection from "../BranchSelection";
import SpecializationList from "../SpecializationList";
import { useNavigate, useParams } from "react-router-dom";
import GetAllBranches from './../../services/branches';

export default function ServicesPage() {
    const [selectedBranch, setSelectedBranch] = useState(null);
    const { branchName } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const fetchBranches = async () => {
            const branches = await GetAllBranches();
            console.log("Branches loaded:", branches);
            
            if (branches.length === 0) console.console.warn("Branches is empty");

            // есть параметр в url
            if (branchName) {
                const foundBranch = branches.find(branch => branch.name === branchName)
                if (foundBranch) {
                    setSelectedBranch(foundBranch);
                } else {
                    console.warn(`Branch ${branchName} not found`);
                    navigate("/notFoundPage");
                }
            } else {
                // нет branchName, устанавливаем первый филиал по умолчанию
                setSelectedBranch(branches[0]);
                navigate(`/services/${branches[0].name}`);
            }
        };
        fetchBranches();
    }, [branchName, navigate])

    const handleBranchSelect = (branch) => {
        setSelectedBranch(branch);
        navigate(`/services/${branch.name}`);
    }

    return (
        <div className="bg-gray-50 mt-15 p-5 flex flex-row gap-20">
            {selectedBranch !== null && ( 
                <BranchSelection
                selectedBranch={selectedBranch}
                setSelectedBranch={handleBranchSelect}
            />)}
            
            <div className="flex-grow">
                {selectedBranch ? (
                    /* Отображение услуг выбранного филиала */
                    <SpecializationList branchId={selectedBranch.id}/>
                ) : 
                ( 
                    <p className="text-gray-600 text-lg font-semibold bg-gray-200 p-4 rounded-lg shadow-md text-center">
                        Выберите филиал
                    </p>
                )}
            </div>
        </div>
    );
}