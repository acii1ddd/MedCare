import { useContext } from "react";
import { AuthContext } from "../Auth/AuthContext";
import PatientDashboard from "../Dashboards/PatientDashboard";
import DoctorDashboard from "../Dashboards/DoctorDashboard";
import ReceptionistDashboard from "../Dashboards/ReceptionistDashboard";
import DirectorDashboard from "../Dashboards/DirectorDashboard";

export default function DashboardRouter() {
    const { currUser } = useContext(AuthContext);
    
    switch (currUser.userRole) {
        case "Patient":
            return <PatientDashboard/>
        case "Doctor":
            return <DoctorDashboard/>
        case "Receptionist":
            return <ReceptionistDashboard/>
        case "Director":
            return <DirectorDashboard/>
    }
}
