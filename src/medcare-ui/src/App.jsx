import { useState } from 'react';
import './App.css'
import DoctorList from './components/DoctorList';
import PriceList from './components/PriceList';

function App() {

  const [activeSection, setActiveSection] = useState(""); // хук для отслеживания состояния выбранного пункта меню
  const [selectedBranch, setSelectedBranch] = useState(""); // хук для отслеживания состояния выбранного филиала
  
  const doctorsMenuItem = "Doctors";
  const pricesMenuItem = "Prices";
  
  const branches = ["МЦ \"Свагушка\" в Гомеле", "МЦ \"Свагушка\" в Речице"];

  const handleNavClick = (section) => {
    setActiveSection(section);
  };

  const handleBranchSelection = (branch) => {
    setSelectedBranch(branch);
  };

  return (
    <div>
      <nav className="bg-white shadow-md px-6 py-3 flex justify-between items-center fixed top-0 left-0 w-full">
        {/* Логотип */}
        <div className="text-green-600 font-bold text-lg">
          Медицинский Центр
        </div>

        {/* Навигация */}
        <div className="flex space-x-6 text-gray-700 font-medium">
          <a href="#" className="hover:text-green-600" onClick={() => handleNavClick(doctorsMenuItem)}>Врачи</a>
          <a href="#" className="hover:text-green-600" onClick={() => handleNavClick(pricesMenuItem)}>Цены</a>
        </div>

        {/* Кнопки Войти / Зарегистрироваться */}
        <div className="flex space-x-4">
          <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700">
            Войти
          </button>
          <button className="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700">
            Зарегистрироваться
          </button>
        </div>
      </nav>

    {/* ВЫНЕСТИ ОТДЕЛЬНО */}
      <main className="bg-green-500">
        {activeSection === doctorsMenuItem && !selectedBranch && (
          <div>
            {/* {Выбор филиала} */}
            <h2 className='text-xl font-semibold mb-2'>Выберите филиал: </h2>
            <div className='space-y-2'>
              {
                branches.map((branch, index) => {
                  return (
                    <button key={index} onClick={() => handleBranchSelection(branch)} 
                      className="bg-white text-green-600 px-4 py-2 rounded-lg w-full hover:bg-green-100">
                        {branch}
                    </button>
                  );
                }) 
              }
            </div>
          </div> 
        )}

        {activeSection === doctorsMenuItem && selectedBranch && (
          <div>
            <DoctorList branchName={selectedBranch}/>
          </div>
        )}

        {/* {activeSection === doctorsMenuItem && <DoctorList/>} */}
        {/* {activeSection === pricesMenuItem && <PriceList/>} */}
      </main>
    </div>
  );
}

export default App
