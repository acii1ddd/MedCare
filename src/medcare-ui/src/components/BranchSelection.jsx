import { useEffect, useState } from "react";
import GetAllBranches from '../services/branches';

// чтоб отметить выбранный филиал и захендлить нажатие
export default function BranchSelection({selectedBranch, setSelectedBranch}) {
    const [branches, setBranches] = useState([]);

    useEffect(() => {
        const fetchBranches = async () => {
            const data = await GetAllBranches();
            console.log("Branches loaded:", data);
            setBranches(data);
        };

        fetchBranches();
    }, []);

    return (
        <div>
            <p className="text-3xl font-semibold mb-4">Выберите филиал:</p>
                {branches.length > 0 ? (
                    <ul className="bg-white shadow-md rounded-lg p-4 w-64 ml-5 mt-5">
                        {branches.map(branch => (
                            <li key={branch.id} 
                            
                            className={"cursor-pointer p-3 border-b last:border-b-0 rounded-sm text-[17px] hover:bg-gray-200 " + (selectedBranch?.id === branch.id ? "bg-blue-300 text-white font-semibold" : "")}
                            onClick={() => setSelectedBranch(branch)}>
                                {branch.name}
                            </li>
                        ))}
                    </ul>
                ) : 
                (
                    <p>Загрузка филиалов...</p>
                )}
        </div>
    );
}
