import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css'
import Navbar from './components/Navbar';
import DoctorsPage from './components/Pages/DoctorsPage';
import ServicesPage from './components/Pages/ServicesPage';
import ContactPage from './components/Pages/ContactPage';

function App() {
  return (
    <>
      <Navbar/>
        <Routes>
          <Route path="/doctors" element={<DoctorsPage/>}/>

          <Route path="/services" element={<ServicesPage/>}/>

          <Route path="/contacts" element={<ContactPage/>}/>
        </Routes>
    </>
  );
}

export default App
