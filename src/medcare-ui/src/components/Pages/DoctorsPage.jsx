import { useState } from "react";
import DoctorList from "../DoctorList";

export default function DoctorsPage() {
    const branches = ["МЦ \"Свагушка\" в Гомеле", "МЦ \"Свагушка\" в Речице"];

    const [selectedBranch, setSelectedBranch] = useState(branches[0]); // по умолчанию первый филиал

    return (
        <div className="bg-red-400 mt-15 flex flex-row gap-20">
            <div>
                <p className="text-4xl font-semibold mb-4">Выберите филиал:</p>
                    <select value={selectedBranch} onChange={e => setSelectedBranch(e.target.value)} className="border rounded p-2 mb-4">
                        {branches.map(
                            branch => (
                                <option key={branch} value={branch}>
                                    {branch}
                                </option>    
                            )
                        )}
                    </select>
            </div>

            <div>
                {/* Отображение врачей выбранного филиала */}
                <DoctorList branchName={selectedBranch}/>
            </div>
        </div>
    );
}