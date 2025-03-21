import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import './App.css'
import Navbar from './components/Navbar';
import DoctorsPage from './components/Pages/DoctorsPage';
import ServicesPage from './components/Pages/ServicesPage';
import ContactPage from './components/Pages/ContactPage';

function App() {

  // const [activeSection, setActiveSection] = useState(""); // хук для отслеживания состояния выбранного пункта меню
  // const [selectedBranch, setSelectedBranch] = useState(""); // хук для отслеживания состояния выбранного филиала
  
  // const doctorsMenuItem = "Doctors";
  // const pricesMenuItem = "Prices";
  
  // const branches = ["МЦ \"Свагушка\" в Гомеле", "МЦ \"Свагушка\" в Речице"];

  // const handleNavClick = (section) => {
  //   setActiveSection(section);
  // };

  // const handleBranchSelection = (branch) => {
  //   setSelectedBranch(branch);
  // };

  return (
    <>
      <Navbar/>
        <Routes>
          {/* <Route path="/"/> */}
          
          <Route path="/doctors" element={<DoctorsPage/>}/>

          <Route path="/services" element={<ServicesPage/>}/>

          <Route path="/contacts" element={<ContactPage/>}/>
        </Routes>
    </>
  );
}

export default App
