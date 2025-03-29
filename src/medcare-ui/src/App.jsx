import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css'
import Navbar from './components/Navbar';
import DoctorsPage from './components/Pages/DoctorsPage';
import ServicesPage from './components/Pages/ServicesPage';
import ContactPage from './components/Pages/ContactPage';
import NotFoundPage from './components/Pages/Auth/NotFoundPage';
import ForbiddenPage from './components/Pages/Auth/ForbiddenPage';
import LoginPage from './components/Pages/Auth/LoginPage';
import AuthPrivateRoute from './components/Routes/AuthPrivateRoute';
import Dashboard from './components/Dashboard';
import AuthProvider from './components/Auth/AuthProvider';
import MainPage from './components/Pages/MainPage';

function Layout() {
  return(
      <div>
        <Navbar/>
            <Routes>
              <Route path="/" element={<MainPage/>}/>

              <Route path="/doctors" element={<DoctorsPage/>}/>
              <Route path="/doctors/:branchName" element={<DoctorsPage />} />

              <Route path="/services" element={<ServicesPage/>}/>
              <Route path="/services/:branchName" element={<ServicesPage/>}/>

              <Route path="/contacts" element={<ContactPage/>}/>

              <Route path="/sign-in" element={<LoginPage />} />
              <Route path="/dashboard"
                element={
                  <AuthPrivateRoute allowedRoles={["Patient", "Receptionist", "Doctor", "Director"]}>
                    <Dashboard/>
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
 