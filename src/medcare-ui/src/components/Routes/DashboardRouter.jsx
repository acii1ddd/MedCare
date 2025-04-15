import { useContext } from "react";
import { AuthContext } from "../Auth/AuthContext";
import PatientDashboard from "../Dashboards/PatientDashboard";
import DoctorDashboard from "../Dashboards/DoctorDashboard";
import ReceptionistDashboard from "../Dashboards/ReceptionistDashboard";
import DirectorDashboard from "../Dashboards/DirectorDashboard";
import { useLocation } from "react-router-dom";

export default function DashboardRouter() {
    const { currUser } = useContext(AuthContext);
    const location = useLocation()
    const queryParams = new URLSearchParams(location.search);
    const asParams = queryParams.get("as");

    if (asParams === "patient" && currUser.userRole === "Doctor") {
        return <PatientDashboard/>
    }
    if (asParams === "patient" && currUser.userRole === "Receptionist") {
        return <PatientDashboard/>
    }
    if (asParams === "patient" && currUser.userRole === "Director") {
        return <PatientDashboard/>
    }

    switch (currUser.userRole) {
        case "Patient":
            return <PatientDashboard/>
        case "Doctor":
            return <DoctorDashboard/>
        case "Receptionist":
            return <ReceptionistDashboard/>
        case "Director":
            return <DirectorDashboard/>
        default:
            return <div>Нет доступа</div>;
    }
}
