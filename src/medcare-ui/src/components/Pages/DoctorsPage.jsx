import { useEffect, useState } from "react";
import BranchSelection from "../BranchSelection";
import DoctorList from "../Lists/DoctorList";
import { useNavigate, useParams } from "react-router-dom";
import GetAllBranches from './../../services/branches';

export default function DoctorsPage() {
    // получаем название филиала из URLs
    const { branchName } = useParams();
    const [selectedBranch, setSelectedBranch] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchBranches = async () => {
            const branches = await GetAllBranches();
            console.log("Branches loaded:", branches);

            if (branches.length === 0) console.console.warn("Branches is empty");
        
            if (branchName) {
                const foundBranch = branches.find(branch => branch.name === branchName);
                if (foundBranch) {
                    setSelectedBranch(foundBranch);
                } else 
                {
                    console.warn(`Branch ${branchName} not found`);
                    navigate("/notFoundPage");
                }
            } else {
                // если нет branchName, устанавливаем первый филиал по умолчанию
                setSelectedBranch(branches[0]);
                navigate(`/doctors/${branches[0].name}`);
            }
        };

        fetchBranches();
    }, [branchName, navigate]);

    const handleBranchSelect = (branch) => {
        setSelectedBranch(branch);
        navigate(`/doctors/${branch.name}`);
    }

    return (
        <div className="bg-gray-50 p-5 mt-15 flex flex-row gap-20 rounded-lg">
            {/* для прохода по url браузера */}
            {selectedBranch !== null && (
                <BranchSelection
                    selectedBranch={selectedBranch}
                    setSelectedBranch={handleBranchSelect}
                />
            )}

            {selectedBranch ? (
                /* врачи выбранного филиала */
                <DoctorList branchName={selectedBranch.name}/>
            ) : 
            ( 
                <p>Выберите филиал</p>
            )}
        </div>
    );
}