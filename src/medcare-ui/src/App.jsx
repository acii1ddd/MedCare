import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css'
import Navbar from './components/Navbar';
import DoctorsPage from './components/Pages/DoctorsPage';
import ServicesPage from './components/Pages/ServicesPage';
import ContactPage from './components/Pages/ContactPage';
import NotFoundPage from './components/Pages/NotFoundPage';

function Layout() {
  return(
      <div>
        <Navbar/>

          <Routes>
            <Route path="/doctors" element={<DoctorsPage/>}/>
            <Route path="/doctors/:branchName" element={<DoctorsPage />} />

            <Route path="/services" element={<ServicesPage/>}/>
            <Route path="/services/:branchName" element={<ServicesPage/>}/>

            <Route path="/contacts" element={<ContactPage/>}/>
          </Routes>
      </div>
  );
}

function App() {
  return (
      <Routes>
        {/* * - для вложенных маршрутов */}
        <Route path="/*" element={<Layout/>}/>
        
        <Route path="/notFoundPage" element={<NotFoundPage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
  );
}

export default App
 