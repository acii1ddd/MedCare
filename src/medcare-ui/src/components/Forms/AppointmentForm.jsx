import { useState, useEffect } from "react";
import BranchSelector from "./BranchSelector";
import SpecializationSelector from "./SpecializationSelector";
import DoctorSelector from "./DoctorSelector";
import GetSpecializationsForBranch from '../../services/specializations';
import GetAllBranches from '../../services/branches';
import { GetDoctorsByBranchWithSpecializationFilter } from '../../services/doctors';

import Calendar from "./Calendar";

export default function AppointmentForm() {
    const [selectedBranch, setSelectedBranch] = useState(null);
    const [branches, setBranches] = useState([]);
    
    const [selectedSpecialization, setSelectedSpecialization] = useState(null);
    const [specializations, setSpecializations] = useState([]);
    
    const [selectedDoctor, setSelectedDoctor] = useState(null);
    const [doctors, setDoctors] = useState([]);
    
    const [availableDays, setAvailableDays] = useState([]);

    useEffect(() => {
        const fetchBranches = async () => {
            const branches = await GetAllBranches();
            console.log("Branches loaded:", branches);

            if (branches.length === 0) {
                console.console.warn("Branches is empty");
                return;
            }
            setBranches(branches);
        };

        fetchBranches();
    }, []);

    useEffect(() => {
        if (!selectedBranch) {
            return;
        }
        const fetchSpecializationForBranch = async () => {
            const specializations = await GetSpecializationsForBranch(selectedBranch.id);
            console.log("Specializations loaded", specializations);
            setSpecializations(specializations);
        };

        fetchSpecializationForBranch();

    }, [selectedBranch]); // зависим от branchId

    useEffect(() => {
        if (!selectedSpecialization || !selectedBranch) {
            return;
        }

        const fetchDoctorsForBranch = async () => {
            const doctors = await GetDoctorsByBranchWithSpecializationFilter(selectedBranch.name, selectedSpecialization.id);
            console.log("Doctors loaded", doctors);
            setDoctors(doctors);
        };

        fetchDoctorsForBranch();
    }, [selectedBranch, selectedSpecialization]);

  return (
    <div className="p-6 max-w-lg mx-auto mt-15">
        <BranchSelector branches={branches} selectedBranch={selectedBranch} setSelectedBranch ={setSelectedBranch} />
        
        <SpecializationSelector specializations={specializations} selectedSpecialization={selectedSpecialization} setSelectedSpecialization={setSelectedSpecialization} />

        <DoctorSelector doctors={doctors} selectedDoctor={selectedDoctor} setSelectedDoctor={setSelectedDoctor}/>

        {selectedDoctor && (
            <Calendar availableDays={availableDays} />
        )}
    </div>
  );
}
