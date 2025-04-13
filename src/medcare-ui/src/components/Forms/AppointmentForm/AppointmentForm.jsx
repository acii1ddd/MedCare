import { useState, useEffect } from "react";
import BranchSelector from "./BranchSelector";
import SpecializationSelector from "./SpecializationSelector";
import DoctorSelector from "./DoctorSelector";
import GetSpecializationsForBranch from '../../../services/specializations';
import GetAllBranches from '../../../services/branches';
import { GetDoctorsByBranchWithSpecializationFilter, GetAvailableDaysForDoctor, GetAvailableSlotsForDoctor } from '../../../services/doctors';
import TimeSlots from './TimeSlots';
import Calendar from "./Calendar";
import Note from "./Note";
import ServiceSelector from "./ServiceSelector";

export default function AppointmentForm() {
    const [selectedBranch, setSelectedBranch] = useState(null);
    const [branches, setBranches] = useState([]);
    
    const [selectedSpecialization, setSelectedSpecialization] = useState(null);
    const [specializations, setSpecializations] = useState([]);
    
    const [selectedDoctor, setSelectedDoctor] = useState(null);
    const [doctors, setDoctors] = useState([]);
    
    const [availableDays, setAvailableDays] = useState([]);
    const [monthBorders, setMonthBorders] = useState({
        startOfMonth: null,
        endOfMonth: null,
    });

    const [slot, selectedSlot] = useState(null);
    const [slots, setSlots] = useState([]);

    const [note, setNote] = useState("");

    const [selectedService, setSelectedService] = useState(null);

    const [appointmentData, setAppointmentData] = useState({
        day: "",
        time: "",
        note: "",
        doctorId: "",
        serviceId: "",
    });

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

            // первый выбранный по умолчанию
            setSelectedDoctor(doctors[0]);
        };

        fetchDoctorsForBranch();
    }, [selectedBranch, selectedSpecialization]);


    useEffect(() => {
        if (!selectedDoctor || !monthBorders) {
            return;
        }

        const fetchAvailableDaysForDoctor = async () => {
            let startOfMonthString = null;
            let endOfMonthString = null;

            if (monthBorders.startOfMonth && monthBorders.endOfMonth) {
                startOfMonthString = monthBorders.startOfMonth.toLocaleDateString("sv-SE");
                endOfMonthString = monthBorders.endOfMonth.toLocaleDateString("sv-SE");
            }

            console.log("monthBorders value is", startOfMonthString, "monthBorders value is", endOfMonthString);

            let days = await GetAvailableDaysForDoctor(selectedDoctor.id, startOfMonthString, endOfMonthString);
            console.log("Days loaded", days);
            console.log("Type of days: ", Array.isArray(days) ? "Array" : "Not Array");
            setAvailableDays(days);
        }

        fetchAvailableDaysForDoctor();
    }, [monthBorders, selectedDoctor]);

    const dayClickHandler = async (day) => {
        console.log("Дата записи ", day);
        console.log("Выбранный врач ", selectedDoctor);
        setAppointmentData((prev) => ({...prev, day: day}))

        const slots = await GetAvailableSlotsForDoctor(selectedDoctor.id, day);
        console.log("Свободные временные слоты: ", slots);
        setSlots(slots);
    };

    const slotClickHandler = (slot) => {
        console.log("Выбранный слот для записи ", slot);
        setAppointmentData((prev) => ({...prev, time: slot}));
        selectedSlot(slot);
    };

    const handleNoteChange = (e) => {
        const {value} = e.target;
        setNote(value);
    };

    const handleClick = () => {
        alert("Запись на прием");
        
        appointmentData.note = note;
        appointmentData.doctorId = selectedDoctor.id;
        appointmentData.serviceId = selectedService.id;
        console.log(appointmentData);    
    };

    return (
        <div className="p-6 max-w-lg mx-auto mt-15">
            <BranchSelector branches={branches} selectedBranch={selectedBranch} setSelectedBranch ={setSelectedBranch} />
            
            <SpecializationSelector specializations={specializations} selectedSpecialization={selectedSpecialization} setSelectedSpecialization={setSelectedSpecialization} />

            <DoctorSelector doctors={doctors} selectedDoctor={selectedDoctor} setSelectedDoctor={setSelectedDoctor}/>

            {selectedDoctor && (
                <ServiceSelector selectedBranch={selectedBranch} selectedSpecialization={selectedSpecialization} setSelectedService={setSelectedService}/>
            )}
            
            {selectedService && (
                <Calendar availableDays={availableDays} setMonthBorders={setMonthBorders} onDayClick={dayClickHandler}/>
            )}
        
            {slots.length > 0 && (
                <TimeSlots slots={slots} onClick={slotClickHandler}/>
            )}

            {slot && (
                <>
                    <Note value={note} handleChange={handleNoteChange}/>
                    <button
                        className="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-4 rounded"
                        onClick={() => handleClick()}
                    >
                        Записаться
                    </button>
                </>
            )}
        </div>
    );
}
