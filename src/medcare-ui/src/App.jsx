import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css'
import Navbar from './components/Layout/Navbar';
import DoctorsPage from './components/Pages/DoctorsPage';
import ServicesPage from './components/Pages/ServicesPage';
import ContactPage from './components/Pages/ContactPage';
import NotFoundPage from './components/Pages/Auth/NotFoundPage';
import ForbiddenPage from './components/Pages/Auth/ForbiddenPage';
import LoginPage from './components/Pages/Auth/LoginPage';
import AuthPrivateRoute from './components/Routes/AuthPrivateRoute';
import AuthProvider from './components/Auth/AuthProvider';
import MainPage from './components/Pages/MainPage';
import DashboardRouter from './components/Routes/DashboardRouter';
import AppointmentForm from "./components/Forms/AppointmentForm/AppointmentForm";
import DoctorInfo from "./components/Items/DoctorInfo";
import MedRecordList from './components/Lists/MedRecordList';
import MedicalRecordForm from "./components/Forms/MedicalRecordForm";
import AddWorkerForm from './components/Forms/AddWorkerForm';
import StatisticsPage from './components/Statistics/StatisticsPage';

function Layout() {
  return(
      <div>
        <Navbar/>
            <Routes>
              <Route path="/" element={<MainPage/>}/>

              <Route path="/doctors" element={<DoctorsPage/>}/>
              <Route path="/doctors/:branchName" element={<DoctorsPage />} />
              <Route path="/doctors/info/:id" element={<DoctorInfo />} />

              <Route path="/services" element={<ServicesPage/>}/>
              <Route path="/services/:branchName" element={<ServicesPage/>}/>

              <Route path="/contacts" element={<ContactPage/>}/>

              <Route path="/sign-in" element={<LoginPage />} />

              {/* <Route path="/dashboard"
                element={
                  <AuthPrivateRoute allowedRoles={["Patient", "Receptionist", "Doctor", "Director"]}>
                    <PatientDashboard/>
                  </AuthPrivateRoute>
                } 
              /> */}

              <Route path="/dashboard"
                element={
                  <AuthPrivateRoute allowedRoles={["Patient", "Receptionist", "Doctor", "Director"]}> {/* успевает положить токен в localstorage при forbidden */}
                    <DashboardRouter/>
                  </AuthPrivateRoute>
                }
              />
              
              <Route path="/appointment"
                element={
                  <AuthPrivateRoute allowedRoles={["Patient", "Receptionist", "Doctor", "Director"]}> {/* успевает положить токен в localstorage при forbidden */}
                    <AppointmentForm/>
                  </AuthPrivateRoute>
                }
              />

              <Route path="/med-card/:id"
                element={
                  <AuthPrivateRoute allowedRoles={["Doctor"]}>
                    <MedRecordList/>
                  </AuthPrivateRoute>
                }
              />

              <Route path="/med-card/:id/add-record"
                element={
                  <AuthPrivateRoute allowedRoles={["Doctor"]}>
                    <MedicalRecordForm/>
                  </AuthPrivateRoute>
                }
              />

              <Route path="/workers/add"
                element={
                  <AuthPrivateRoute allowedRoles={["Director"]}>
                    <AddWorkerForm/>
                  </AuthPrivateRoute>
                }
              />

              <Route path="/statistics"
                element={
                  <AuthPrivateRoute allowedRoles={["Director"]}>
                    <StatisticsPage/>
                  </AuthPrivateRoute>
                }
              />

            </Routes>
      </div>
  );
}

function App() {
  return (
    <AuthProvider>
      <Routes>
        {/* * - для вложенных маршрутов */}
        <Route path="/*" element={<Layout/>}/>

        <Route path="/notFoundPage" element={<NotFoundPage />} />
        <Route path="/forbidden" element={<ForbiddenPage />} />

        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </AuthProvider>
  );
}

export default App
 